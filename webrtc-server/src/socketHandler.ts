import { Server as SocketIOServer, Socket } from "socket.io";

import { socketEventTypes } from "@dapp/shared/src/types/custom";
import { RoomState, UserDto } from "@dapp/shared/src/types/openApiGen";

import { roomService } from "./services";

class SocketHandler {
  private io: SocketIOServer;
  private timersMap: Map<
    string,
    { timer: NodeJS.Timeout; timeRemaining: number }
  >;

  constructor(io: SocketIOServer) {
    this.io = io;
    this.timersMap = new Map();
    this.handleConnection();
  }

  private handleConnection(): void {
    this.io.on("connection", socket => {
      console.log("New client connected");

      socket.on("join", (payload: socketEventTypes.JoinRoomPayload) =>
        this.handleOnJoin(payload, socket)
      );

      socket.on("offer", (payload: socketEventTypes.OfferPayload) =>
        this.handleOffer(payload, socket)
      );

      socket.on("answer", (payload: socketEventTypes.AnswerPayload) =>
        this.handleAnswer(payload, socket)
      );

      socket.on(
        "ice-candidate",
        (payload: socketEventTypes.IceCandidatePayload) =>
          this.handleIceCandidate(payload, socket)
      );

      socket.on("leave-room", (payload: socketEventTypes.LeaveRoomPayload) =>
        this.handleDisconnect(socket, payload)
      );

      socket.on("disconnect", reason => {
        console.log(`User disconnected: ${socket.id}, Reason: ${reason}`);
        this.handleDisconnect(socket);
      });

      socket.on("start-round", (payload: socketEventTypes.StartRoundPayload) =>
        this.handleStartRound(payload, socket)
      );

      socket.on("pause-round", (payload: socketEventTypes.PauseRoundPayload) =>
        this.handlePauseRound(payload, socket)
      );

      socket.on(
        "resume-round",
        (payload: socketEventTypes.ResumeRoundPayload) =>
          this.handleResumeRound(payload, socket)
      );

      socket.on("skip-round", (payload: socketEventTypes.SkipRoundPayload) =>
        this.handleSkipRound(payload, socket)
      );

      socket.on(
        "go-to-next-question",
        (payload: socketEventTypes.GoToNextQuestionPayload) =>
          this.handleGoToNextQuestion(payload, socket)
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
        const joinRes = await roomService.joinRoom(token, roomId, socket.id);
        if (joinRes?.statusCode !== 200 && joinRes?.statusCode !== 201) {
          throw Error(joinRes?.message || "Failed to join room.");
        }
        socket.join(roomId.toString());
        // notify everyone that this user has joined
        socket.broadcast.to(roomId.toString()).emit("user-joined", {
          userToSignal: socket.id,
          user,
        } as socketEventTypes.UserJoinedPayload);
        // send the current room state to this user
        const previousTimer = this.timersMap.get(roomId.toString());
        socket.emit("room-state-sent", {
          roomState: {
            ...room.data?.roomState,
            timeRemainingForRoundBeforePause: previousTimer?.timeRemaining || 0,
          },
        } as socketEventTypes.SendRoomStatePayload);
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      socket.disconnect(true);
      console.error(e);
    }
  }

  private handleOffer(payload: socketEventTypes.OfferPayload, socket: Socket) {
    this.io.to(payload.targetSocketId).emit("offer-produced", {
      ...payload,
      user: socket.data.user,
    } as socketEventTypes.OfferProducedPayload);
  }

  private handleAnswer(
    payload: socketEventTypes.AnswerPayload,
    _socket: Socket
  ) {
    this.io.to(payload.targetSocketId).emit("answer", payload);
  }

  private handleIceCandidate(
    payload: socketEventTypes.IceCandidatePayload,
    _socket: Socket
  ) {
    this.io.to(payload.targetSocketId).emit("ice-candidate", payload);
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
      }
      const rooms = Array.from(socket.rooms).filter(room => room !== socket.id); // Filter out the socket's own room

      rooms.forEach(room => {
        // Get the number of clients in the room before disconnection
        const roomClients = this.io.sockets.adapter.rooms.get(room);
        const clientCount = roomClients ? roomClients.size : 0;

        console.log(`Room: ${room}, Clients before disconnect: ${clientCount}`);

        // Perform actions based on the number of remaining clients
        if (clientCount <= 1) {
          console.log(`Room ${room} is now empty or has only one client left.`);
          const previousTimer = this.timersMap.get(room);
          clearInterval(previousTimer?.timer);
          this.timersMap.delete(socket.id);
        }
      });

      socket.disconnect(true);
    } catch (e) {
      socket.disconnect(true);
      console.error("Failde to leave room!", e);
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
        this.io.in(payload.roomId.toString()).emit("rounds-started", {
          roomState: finalRoomState,
        } as socketEventTypes.RoundsStartedPayload);

        this.setTimer(room.data.id!, finalRoomState, token, socket.id);
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      console.error("failed to start round..", e);
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
        this.io.in(payload.roomId.toString()).emit("round-paused", {
          roomState: finalRoomState,
        } as socketEventTypes.RoundPausedPayload);

        await roomService.updateRoom(
          token,
          { roomState: finalRoomState },
          room?.data?.id!
        );
        clearInterval(this.timersMap.get(payload.roomId.toString())?.timer);
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      console.error("failed to pause/resume round..", e);
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
        this.io.in(payload.roomId.toString()).emit("round-resumed", {
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
      console.error("failed to pause/resume round..", e);
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
        this.io.in(payload.roomId.toString()).emit("round-skiped", {
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
      console.error("failed to skip round..", e);
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
        const existingRoomState = room.data.roomState as RoomState;
        if (
          existingRoomState.questionIndex! <
          existingRoomState.roundQuestions?.length! - 1
        ) {
          existingRoomState.questionIndex =
            existingRoomState.questionIndex! + 1;
          this.io.in(payload.roomId.toString()).emit("next-question-clicked", {
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
      console.error("failed to go to next question..", e);
    }
  }

  // helpers
  private async setTimer(
    roomId: number,
    roomState: RoomState,
    token: string,
    socketId: string
  ) {
    const previousTimer = this.timersMap.get(roomId.toString());
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
        this.io.in(roomId.toString()).emit("rounds-ended", {
          roomState,
        } as socketEventTypes.RoundsEndedPayload);
      } else {
        this.io.in(roomId.toString()).emit("timer-updated", {
          roomState,
        } as socketEventTypes.TimerUpdatedPayload);
        if (goToNextRound) {
          this.setTimer(roomId, roomState, token, socketId);
        }
      }

      if (timer) {
        this.timersMap.set(roomId.toString(), {
          timer,
          timeRemaining: roomState.timeRemainingForRoundBeforePause,
        });
      }
    }, 1000);
  }
}

export default SocketHandler;
