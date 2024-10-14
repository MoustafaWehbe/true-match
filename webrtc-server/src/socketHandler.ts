import { Server as SocketIOServer, Socket } from "socket.io";

import { socketEventTypes } from "@dapp/shared/src/types/custom";
import { RoomMetaData } from "@dapp/shared/src/types/openApiGen";

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
        this.handleDisconnect(payload, socket)
      );

      socket.on(
        "update-room-data",
        (payload: RoomMetaData & { roomId: number }) =>
          this.handleUpdateRoomData(payload, socket)
      );
    });
  }

  private async handleOnJoin(
    { roomId }: socketEventTypes.JoinRoomPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;
    try {
      const room = await roomService.getRoomById(token, roomId);
      if (room) {
        const joinRes = await roomService.joinRoom(token, roomId, socket.id);
        if (joinRes?.statusCode !== 200 && joinRes?.statusCode !== 201) {
          throw Error(joinRes?.message || "Failed to join room.");
        }
        socket.join(roomId.toString());
        // notify everyone that this user has joined
        socket.broadcast.to(roomId.toString()).emit("user-joined", socket.id);
        // send the current room meta data to this user
        socket.emit("update-room-data", room.data?.roomMetaData);
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
    { roomId }: socketEventTypes.LeaveRoomPayload,
    socket: Socket
  ) {
    const token = socket.handshake.auth.token;
    try {
      const leaveRes = await roomService.leaveRoom(roomId, token);
      if (leaveRes?.statusCode !== 200 && leaveRes?.statusCode !== 201) {
        throw Error(leaveRes?.message || "Failed to leave room.");
      }
      socket.disconnect(true);
      console.log("Client disconnected");
    } catch {
      socket.disconnect(true);
      throw Error("Failde to leave room!");
    }
  }

  private async handleUpdateRoomData(
    payload: RoomMetaData & { roomId: number },
    socket: Socket
  ) {
    // Broadcast the new action to all users except the owner
    socket.to(payload.roomId.toString()).emit("update-room-data", payload);
  }
}

export default SocketHandler;
