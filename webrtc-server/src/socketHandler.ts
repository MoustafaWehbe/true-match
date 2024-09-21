import { Server as SocketIOServer, Socket } from "socket.io";

import { socketEventTypes } from "@dapp/shared/src/types/custom";

import { roomService } from "./services";

class SocketHandler {
  private io: SocketIOServer;

  constructor(io: SocketIOServer) {
    this.io = io;
    this.handleConnection();
  }

  private handleConnection(): void {
    this.io.on("connection", socket => {
      console.log("New client connected");

      socket.on("join", (payload: socketEventTypes.JoinRoomPayload) =>
        this.handleOnJoin(payload, socket),
      );

      socket.on("offer", (payload: socketEventTypes.OfferPayload) =>
        this.handleOffer(payload, socket),
      );

      socket.on("answer", (payload: socketEventTypes.AnswerPayload) =>
        this.handleAnswer(payload, socket),
      );

      socket.on(
        "ice-candidate",
        (payload: socketEventTypes.IceCandidatePayload) =>
          this.handleIceCandidate(payload, socket),
      );

      socket.on("leave-room", (payload: socketEventTypes.LeaveRoomPayload) =>
        this.handleDisconnect(payload, socket),
      );
    });
  }

  private async handleOnJoin(
    { roomId }: socketEventTypes.JoinRoomPayload,
    socket: Socket,
  ) {
    const token = socket.handshake.auth.token;
    try {
      const room = await roomService.getRoomById(token, roomId);
      if (room) {
        await roomService.joinRoom(token, roomId, socket.id);
        socket.join(roomId.toString());
        socket.broadcast.to(roomId.toString()).emit("user-joined", socket.id);
      } else {
        throw Error("Could not find room");
      }
    } catch (e) {
      socket.disconnect(true);
      console.error(e);
      throw Error("Failde to update room!");
    }
  }

  private handleOffer(payload: socketEventTypes.OfferPayload, _socket: Socket) {
    this.io.to(payload.targetSocketId).emit("offer", payload);
  }

  private handleAnswer(
    payload: socketEventTypes.AnswerPayload,
    _socket: Socket,
  ) {
    this.io.to(payload.targetSocketId).emit("answer", payload);
  }

  private handleIceCandidate(
    payload: socketEventTypes.IceCandidatePayload,
    _socket: Socket,
  ) {
    this.io.to(payload.targetSocketId).emit("ice-candidate", payload);
  }

  private async handleDisconnect(
    { roomId }: socketEventTypes.LeaveRoomPayload,
    socket: Socket,
  ) {
    const token = socket.handshake.auth.token;
    try {
      await roomService.leaveRoom(roomId, token);
      console.log("Client disconnected");
    } catch {
      socket.disconnect(true);
      throw Error("Failde to leave room!");
    }
  }
}

export default SocketHandler;
