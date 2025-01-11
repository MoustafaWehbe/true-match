import { Server as SocketIOServer, Socket } from "socket.io";

import { SOCKET_EVENTS } from "@truematch/shared/src/consts/socketEvents";
import { socketEventTypes } from "@truematch/shared/src/types/custom";
import { RoomState, UserDto } from "@truematch/shared/src/types/openApiGen";

import { roomService } from "../services";
import { maxAllowedUsersTojoin } from "../utils/consts";

class RoomHandler {
  private io: SocketIOServer;
  private timersMap: Map<
    string,
    { timer: NodeJS.Timeout; timeRemaining: number }
  >;
  private socketRooms: Map<string, string[]>;

  constructor(
    io: SocketIOServer,
    socketRooms: Map<string, string[]>,
    timersMap: Map<string, { timer: NodeJS.Timeout; timeRemaining: number }>
  ) {
    this.io = io;
    this.timersMap = timersMap;
    this.socketRooms = socketRooms;
  }

  public setupListeners(socket: Socket): void {
    socket.on(
      SOCKET_EVENTS.CLIENT.JOIN_ROOM_EVENT,
      (payload: socketEventTypes.JoinRoomPayload) =>
        this.handleOnJoin(payload, socket)
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
      SOCKET_EVENTS.CLIENT.REMOVE_USER,
      (payload: socketEventTypes.RemoveUserPayload) =>
        this.removeUser(payload, socket)
    );

    socket.on(
      SOCKET_EVENTS.CLIENT.ADD_NEW_MATCH,
      (payload: socketEventTypes.AddNewMatchPayload) =>
        this.handleNewMatch(payload, socket)
    );
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
        const roomNamespace = this.io.of("/room");
        const roomClients = roomNamespace.adapter.rooms.get(roomId);

        const clientCount = roomClients ? roomClients.size : 0;
        // Check if the room exceeds the maximum allowed users
        if (clientCount >= maxAllowedUsersTojoin) {
          throw Error("The maximum number of allowed users has been reached.");
        }

        if (
          room.data?.roomState?.currentRound &&
          room.data.roomState.currentRound >= 4
        ) {
          throw Error("Too late to join.");
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

  private async handleDisconnect(socket: Socket) {
    const token = socket.handshake.auth.token;
    const rooms = this.socketRooms.get(socket.id) || [];
    const firstRoom = rooms[0]; // for now one user can only be in one room at once.
    try {
      const leaveRes = await roomService.leaveRoom(firstRoom, token);
      if (leaveRes?.statusCode !== 200 && leaveRes?.statusCode !== 201) {
        throw Error(leaveRes?.message || "Failed to leave room.");
      }
      const roomNamespace = this.io.of("/room");
      const roomClients = roomNamespace.adapter.rooms.get(firstRoom);

      const clientCount = roomClients ? roomClients.size : 0;
      if (clientCount <= 1) {
        console.log(
          `Room ${firstRoom} is now empty or has only one client left.`
        );
        const previousTimer = this.timersMap.get(firstRoom);
        clearInterval(previousTimer?.timer);
        this.timersMap.delete(firstRoom);
      }
    } catch (e) {
      console.error("Failde to leave room!", e);
    } finally {
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
          .of("/room")
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
          .of("/room")
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
          .of("/room")
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
        const existingRoomState = room.data.roomState as RoomState;
        const roomNamespace = this.io.of("/room");
        const roomClients = roomNamespace.adapter.rooms.get(room.data.id!);

        const socketsCount = roomClients ? roomClients.size : 0;

        const roundNumber =
          existingRoomState.currentRound === 3 && socketsCount <= 2
            ? existingRoomState.rounds?.length! - 1
            : existingRoomState.currentRound! + 1;
        const finalRoomState: RoomState = {
          ...existingRoomState,
          isRoundPaused: false,
          currentRound: roundNumber,
          timeRemainingForRoundBeforePause:
            existingRoomState?.rounds![roundNumber]?.duration!,
        };
        await roomService.updateRoom(
          token,
          { roomState: finalRoomState },
          room?.data?.id!
        );

        await this.setTimer(room.data.id!, finalRoomState, token, socket.id);

        this.io
          .of("/room")
          .in(payload.roomId)
          .emit(SOCKET_EVENTS.SERVER.SKIP_ROUND_EVENT, {
            roomState: finalRoomState,
          } as socketEventTypes.RoundSkipedPayload);
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
            .of("/room")
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

  private async removeUser(
    payload: socketEventTypes.RemoveUserPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;
    const senderId = (socket.data.user as UserDto).id;

    try {
      const room = await roomService.getRoomById(token, payload.roomId);
      if (room?.data) {
        if (room.data.user?.id !== senderId) {
          throw Error("Unauthorized!");
        }

        const socketToKick = this.io
          .of("/room")
          .sockets.get(payload.socketIdToRemove);

        if (socketToKick) {
          socketToKick.leave(payload.roomId);

          // notify everyone about the user who has been removed
          this.io
            .of("/room")
            .in(payload.roomId)
            .emit(SOCKET_EVENTS.SERVER.REMOVE_USER, {
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

  private async handleNewMatch(
    payload: socketEventTypes.AddNewMatchPayload,
    socket: Socket
  ) {
    socket.broadcast
      .to(payload.roomId)
      .emit(SOCKET_EVENTS.SERVER.ADD_NEW_MATCH, payload);
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
        this.io
          .of("/room")
          .in(roomId)
          .emit(SOCKET_EVENTS.SERVER.END_ROUNDS_EVENT, {
            roomState,
          } as socketEventTypes.RoundsEndedPayload);
      } else {
        this.io
          .of("/room")
          .in(roomId)
          .emit(SOCKET_EVENTS.SERVER.UPDATE_TIMER_EVENT, {
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

export default RoomHandler;
