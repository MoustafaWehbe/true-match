import { Server as SocketIOServer, Socket } from "socket.io";

import { SOCKET_EVENTS } from "@dapp/shared/src/consts/socketEvents";
import { socketEventTypes } from "@dapp/shared/src/types/custom";
import { RoomState, UserDto } from "@dapp/shared/src/types/openApiGen";

import { maxAllowedUsersTojoin } from "./utils/consts";
import { messageService, roomService } from "./services";

class SocketHandler {
  private io: SocketIOServer;
  // TODO: move to redis
  private timersMap: Map<
    string,
    { timer: NodeJS.Timeout; timeRemaining: number }
  >;
  // TODO: move to redis
  private userSocketsMap: Map<string, string>;

  // TODO: move to redis
  private socketRooms: Map<string, string[]>;

  constructor(io: SocketIOServer) {
    this.io = io;
    this.timersMap = new Map();
    this.userSocketsMap = new Map();
    this.socketRooms = new Map();
    this.handleConnection();
  }

  private handleConnection(): void {
    this.io.on("connection", socket => {
      console.log("New client connected");
      const userId = (socket.data.user as UserDto).id;
      this.userSocketsMap.set(`user_socket:${userId}`, socket.id);

      socket.on(
        SOCKET_EVENTS.CLIENT.JOIN_ROOM_EVENT,
        (payload: socketEventTypes.JoinRoomPayload) =>
          this.handleOnJoin(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.SEND_OFFER_EVENT,
        (payload: socketEventTypes.OfferPayload) =>
          this.handleOffer(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.SEND_ANSWER_EVENT,
        (payload: socketEventTypes.AnswerPayload) =>
          this.handleAnswer(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.SEND_ICE_CANDIDATE_EVENT,
        (payload: socketEventTypes.IceCandidatePayload) =>
          this.handleIceCandidate(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.LEAVE_ROOM_EVENT,
        (payload: socketEventTypes.LeaveRoomPayload) =>
          this.handleDisconnect(socket, payload)
      );

      socket.on("disconnect", reason => {
        console.log(`User disconnected: ${socket.id}, Reason: ${reason}`);
        this.handleDisconnect(socket);
      });

      socket.on(
        SOCKET_EVENTS.CLIENT.START_ROUND_EVENT,
        (payload: socketEventTypes.StartRoundPayload) =>
          this.handleStartRound(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.PAUSE_ROUND_EVENT,
        (payload: socketEventTypes.PauseRoundPayload) =>
          this.handlePauseRound(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.RESUME_ROUND_EVENT,
        (payload: socketEventTypes.ResumeRoundPayload) =>
          this.handleResumeRound(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.SKIP_ROUND_EVENT,
        (payload: socketEventTypes.SkipRoundPayload) =>
          this.handleSkipRound(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.GO_TO_NEXT_QUESTION_EVENT,
        (payload: socketEventTypes.GoToNextQuestionPayload) =>
          this.handleGoToNextQuestion(payload, socket)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.SEND_MESSAGE,
        (payload: socketEventTypes.SendMessagePayload) =>
          this.handleMessageSent(payload, socket, userId!)
      );

      socket.on(
        SOCKET_EVENTS.CLIENT.REMOVE_USER,
        (payload: socketEventTypes.RemoveUserPayload) =>
          this.removeUser(payload, socket, userId!)
      );
    });
  }

  private async handleOnJoin(
    { roomId }: socketEventTypes.JoinRoomPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;
    const user = socket.data.user as UserDto;
    try {
      const room = await roomService.getRoomById(token, roomId);
      if (room) {
        const roomClients = this.io.sockets.adapter.rooms.get(roomId);
        const clientCount = roomClients ? roomClients.size : 0;
        // Check if the room exceeds the maximum allowed users
        if (clientCount >= maxAllowedUsersTojoin) {
          throw Error("The maximum number of allowed users has been reached.");
        }

        const joinRes = await roomService.joinRoom(token, roomId, socket.id);
        if (joinRes?.statusCode !== 200 && joinRes?.statusCode !== 201) {
          throw Error(joinRes?.message || "Failed to join room.");
        }
        await socket.join(roomId);
        // notify everyone that this user has joined
        setImmediate(() => {
          socket.broadcast
            .to(roomId)
            .emit(SOCKET_EVENTS.SERVER.JOIN_ROOM_EVENT, {
              userToSignal: socket.id,
              user,
            } as socketEventTypes.UserJoinedPayload);
        });
        // send the current room state to this user
        const previousTimer = this.timersMap.get(roomId);
        socket.emit(SOCKET_EVENTS.SERVER.SEND_ROOM_STATE_EVENT, {
          roomState: {
            ...room.data?.roomState,
            timeRemainingForRoundBeforePause: previousTimer?.timeRemaining || 0,
          },
        } as socketEventTypes.SendRoomStatePayload);
        const rooms = this.socketRooms.get(socket.id) || [];
        rooms.push(roomId);
        this.socketRooms.set(socket.id, rooms);
      } else {
        throw Error("Could not find room");
      }
    } catch (e: any) {
      socket.emit(SOCKET_EVENTS.SERVER.EMIT_ERROR, {
        status: e?.status,
        message: e?.response?.data || e.message,
        action: "JOIN",
      } as socketEventTypes.EmitErrorPayload);
      socket.disconnect(true);
      console.error(e);
    }
  }

  private handleOffer(payload: socketEventTypes.OfferPayload, socket: Socket) {
    this.io
      .to(payload.targetSocketId)
      .emit(SOCKET_EVENTS.SERVER.SEND_OFFER_EVENT, {
        ...payload,
        user: socket.data.user,
      } as socketEventTypes.OfferProducedPayload);
  }

  private handleAnswer(
    payload: socketEventTypes.AnswerPayload,
    _socket: Socket
  ) {
    this.io
      .to(payload.targetSocketId)
      .emit(SOCKET_EVENTS.SERVER.SEND_ANSWER_EVENT, payload);
  }

  private handleIceCandidate(
    payload: socketEventTypes.IceCandidatePayload,
    _socket: Socket
  ) {
    this.io
      .to(payload.targetSocketId)
      .emit(SOCKET_EVENTS.SERVER.SEND_ICE_CANDIDATE_EVENT, payload);
  }

  private async handleDisconnect(
    socket: Socket,
    payload?: socketEventTypes.LeaveRoomPayload
  ) {
    const token = socket.handshake.auth.token;
    try {
      if (payload) {
        const leaveRes = await roomService.leaveRoom(payload.roomId, token);
        if (leaveRes?.statusCode !== 200 && leaveRes?.statusCode !== 201) {
          throw Error(leaveRes?.message || "Failed to leave room.");
        }
        const roomClients = this.io.sockets.adapter.rooms.get(payload.roomId);
        const clientCount = roomClients ? roomClients.size : 0;
        if (clientCount <= 1) {
          console.log(
            `Room ${payload.roomId} is now empty or has only one client left.`
          );
          const previousTimer = this.timersMap.get(payload.roomId);
          clearInterval(previousTimer?.timer);
          this.timersMap.delete(payload.roomId);
        }
      }
    } catch (e) {
      console.error("Failde to leave room!", e);
    } finally {
      const rooms = this.socketRooms.get(socket.id) || [];
      const firstRoom = rooms[0]; // for now one user can only be in one room at once.

      if (firstRoom) {
        socket.broadcast
          .to(firstRoom)
          .emit(SOCKET_EVENTS.SERVER.EMIT_SOCKET_DISCONNECTED, {
            disconnectedSocketId: socket.id,
          } as socketEventTypes.EmitDisconnectPayload);
        this.socketRooms.delete(socket.id);
      }

      socket.disconnect(true);
    }
  }

  private async handleStartRound(
    payload: socketEventTypes.StartRoundPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;
    try {
      const room = await roomService.getRoomById(token, payload.roomId);
      if (room?.data) {
        const existingRoomState = room.data.roomState as RoomState | undefined;
        const finalRoomState: RoomState = {
          ...existingRoomState,
          roundStartTime: new Date(),
          currentRound: 0,
          isRoundPaused: false,
          rounds: payload.rounds,
          timeRemainingForRoundBeforePause: payload.rounds![0].duration!,
        };
        await roomService.updateRoom(
          token,
          { roomState: finalRoomState },
          room?.data?.id!
        );
        this.io
          .in(payload.roomId)
          .emit(SOCKET_EVENTS.SERVER.START_ROUND_EVENT, {
            roomState: finalRoomState,
          } as socketEventTypes.RoundsStartedPayload);

        this.setTimer(room.data.id!, finalRoomState, token, socket.id);
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      const errorMessage = "An error occured while starting the rounds";
      socket.emit(SOCKET_EVENTS.SERVER.EMIT_ERROR, {
        status: 400,
        message: errorMessage,
        action: "START_ROUND",
      } as socketEventTypes.EmitErrorPayload);
      console.error(errorMessage, e);
    }
  }

  private async handlePauseRound(
    payload: socketEventTypes.PauseRoundPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;

    try {
      const room = await roomService.getRoomById(token, payload.roomId);
      if (room?.data) {
        const existingRoomState = room.data.roomState as RoomState | undefined;
        const finalRoomState: RoomState = {
          ...existingRoomState,
          isRoundPaused: true,
          timeRemainingForRoundBeforePause: payload.timeRemaining,
        };
        this.io
          .in(payload.roomId)
          .emit(SOCKET_EVENTS.SERVER.PAUSE_ROUND_EVENT, {
            roomState: finalRoomState,
          } as socketEventTypes.RoundPausedPayload);

        await roomService.updateRoom(
          token,
          { roomState: finalRoomState },
          room?.data?.id!
        );
        clearInterval(this.timersMap.get(payload.roomId)?.timer);
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      const errorMessage = "Failed to pause round..";
      socket.emit(SOCKET_EVENTS.SERVER.EMIT_ERROR, {
        status: 400,
        message: errorMessage,
        action: "PAUSE_ROUND",
      } as socketEventTypes.EmitErrorPayload);
      console.error(errorMessage, e);
    }
  }

  private async handleResumeRound(
    payload: socketEventTypes.ResumeRoundPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;

    try {
      const room = await roomService.getRoomById(token, payload.roomId);
      if (room?.data) {
        const existingRoomState = room.data.roomState as RoomState | undefined;
        const finalRoomState: RoomState = {
          ...existingRoomState,
          isRoundPaused: false,
        };
        this.io
          .in(payload.roomId)
          .emit(SOCKET_EVENTS.SERVER.RESUME_ROUND_EVENT, {
            roomState: finalRoomState,
          } as socketEventTypes.RoundResumedPayload);

        await roomService.updateRoom(
          token,
          { roomState: finalRoomState },
          room?.data?.id!
        );
        this.setTimer(room.data.id!, finalRoomState, token, socket.id);
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      const errorMessage = "Failed to resume round..";
      socket.emit(SOCKET_EVENTS.SERVER.EMIT_ERROR, {
        status: 400,
        message: errorMessage,
        action: "RESUME_ROUND",
      } as socketEventTypes.EmitErrorPayload);
      console.error(errorMessage, e);
    }
  }

  private async handleSkipRound(
    payload: socketEventTypes.SkipRoundPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;

    try {
      const room = await roomService.getRoomById(token, payload.roomId);
      if (room?.data) {
        const existingRoomState = room.data.roomState as RoomState | undefined;
        const finalRoomState: RoomState = {
          ...existingRoomState,
          isRoundPaused: false,
          currentRound: existingRoomState?.currentRound! + 1,
          timeRemainingForRoundBeforePause:
            existingRoomState?.rounds![existingRoomState?.currentRound! + 1]
              .duration!,
        };
        this.io.in(payload.roomId).emit(SOCKET_EVENTS.SERVER.SKIP_ROUND_EVENT, {
          roomState: finalRoomState,
        } as socketEventTypes.RoundSkipedPayload);

        await roomService.updateRoom(
          token,
          { roomState: finalRoomState },
          room?.data?.id!
        );

        this.setTimer(room.data.id!, finalRoomState, token, socket.id);
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      const errorMessage = "Failed to skip round..";
      socket.emit(SOCKET_EVENTS.SERVER.EMIT_ERROR, {
        status: 400,
        message: errorMessage,
        action: "SKIP_ROUND",
      } as socketEventTypes.EmitErrorPayload);
      console.error(errorMessage, e);
    }
  }

  private async handleGoToNextQuestion(
    payload: socketEventTypes.GoToNextQuestionPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;
    try {
      const room = await roomService.getRoomById(token, payload.roomId);
      if (room?.data) {
        const user = socket.data.user as UserDto;

        if (room.data.user?.id !== user.id) {
          throw Error("Unauthorized!");
        }
        const existingRoomState = room.data.roomState as RoomState;
        if (
          existingRoomState.questionIndex! <
          existingRoomState.roundQuestions?.length! - 1
        ) {
          existingRoomState.questionIndex =
            existingRoomState.questionIndex! + 1;
          this.io
            .in(payload.roomId)
            .emit(SOCKET_EVENTS.SERVER.GO_TO_NEXT_QUESTION_EVENT, {
              roomState: existingRoomState,
            } as socketEventTypes.NextQuestionClickedPayload);
        } else {
          this.handleSkipRound({ roomId: payload.roomId }, socket);
        }
        await roomService.updateRoom(
          token,
          { roomState: existingRoomState },
          room?.data?.id!
        );
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      const errorMessage = "Failed to go to the next question..";
      socket.emit(SOCKET_EVENTS.SERVER.EMIT_ERROR, {
        status: 400,
        message: errorMessage,
        action: "NEXT_QUESTION",
      } as socketEventTypes.EmitErrorPayload);
      console.error(errorMessage, e);
    }
  }

  // individual users chat
  private async handleMessageSent(
    payload: socketEventTypes.SendMessagePayload,
    socket: Socket,
    senderId: string
  ) {
    const { receiverId, content } = payload;
    const token = socket.handshake.auth.token;

    const messageData = {
      senderId,
      receiverId,
      content,
    };

    try {
      await messageService.saveMessage(messageData, token);
    } catch {
      console.log("unable to save message!!");
    }
    const receiverSocketId = this.userSocketsMap.get(
      `user_socket:${receiverId}`
    );
    if (receiverSocketId) {
      this.io
        .to(receiverSocketId)
        .emit(
          SOCKET_EVENTS.SERVER.SEND_MESSAGE,
          messageData as socketEventTypes.MessageSentPayload
        );
    }
  }

  private async removeUser(
    payload: socketEventTypes.RemoveUserPayload,
    socket: Socket,
    senderId: string
  ) {
    const token = socket.handshake.auth.token;
    try {
      const room = await roomService.getRoomById(token, payload.roomId);
      if (room?.data) {
        if (room.data.user?.id !== senderId) {
          throw Error("Unauthorized!");
        }

        const socketToKick = this.io.sockets.sockets.get(
          payload.socketIdToRemove
        );
        if (socketToKick) {
          socketToKick.leave(payload.roomId);

          // notify everyone about the user who has been removed
          this.io.in(payload.roomId).emit(SOCKET_EVENTS.SERVER.REMOVE_USER, {
            userSocketId: payload.socketIdToRemove,
          } as socketEventTypes.UserRemovedPayload);

          //notify the user who has been removed
          socketToKick.emit(SOCKET_EVENTS.SERVER.REMOVE_USER, {
            userSocketId: payload.socketIdToRemove,
          } as socketEventTypes.UserRemovedPayload);
        }
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      const errorMessage = "Failed to remove user from the room..";
      socket.emit(SOCKET_EVENTS.SERVER.EMIT_ERROR, {
        status: 400,
        message: errorMessage,
        action: "REMOVE_USER",
      } as socketEventTypes.EmitErrorPayload);
      console.error(errorMessage, e);
    }
  }

  // helpers
  private async setTimer(
    roomId: string,
    roomState: RoomState,
    token: string,
    socketId: string
  ) {
    const previousTimer = this.timersMap.get(roomId);
    clearInterval(previousTimer?.timer);
    previousTimer?.timer?.unref();
    let theEnd = false;
    let goToNextRound = false;
    const timer = setInterval(async () => {
      roomState.timeRemainingForRoundBeforePause =
        roomState.timeRemainingForRoundBeforePause! - 1;
      if (roomState.timeRemainingForRoundBeforePause < 1) {
        clearInterval(timer!);
        if (roomState.currentRound! < roomState.rounds?.length! - 1) {
          roomState.currentRound = roomState.currentRound! + 1;
          roomState.timeRemainingForRoundBeforePause =
            roomState.rounds![roomState.currentRound].duration!;
          goToNextRound = true;
        } else {
          // reset round
          roomState.currentRound = null;
          roomState.timeRemainingForRoundBeforePause = 0;
          roomState.isRoundPaused = false;
          theEnd = true;
        }
        // only update room if the rounds end or we move to the next round.
        try {
          await roomService.updateRoom(token, { roomState }, roomId);
        } catch {
          console.error("failed to update room state...");
        }
      }
      if (theEnd) {
        this.io.in(roomId).emit(SOCKET_EVENTS.SERVER.END_ROUNDS_EVENT, {
          roomState,
        } as socketEventTypes.RoundsEndedPayload);
      } else {
        this.io.in(roomId).emit(SOCKET_EVENTS.SERVER.UPDATE_TIMER_EVENT, {
          roomState,
        } as socketEventTypes.TimerUpdatedPayload);
        if (goToNextRound) {
          this.setTimer(roomId, roomState, token, socketId);
        }
      }

      if (timer) {
        this.timersMap.set(roomId, {
          timer,
          timeRemaining: roomState.timeRemainingForRoundBeforePause,
        });
      }
    }, 1000);
  }
}

export default SocketHandler;
