import { Server as SocketIOServer, Socket } from "socket.io";
import { UserApi, UserApiResponse } from "./openApiGen";
import { userService } from "./services";

class SocketHandler {
  private io: SocketIOServer;
  private rooms: any = {};

  constructor(io: SocketIOServer) {
    this.io = io;
    this.handleConnection();
  }

  private handleConnection(): void {
    this.io.on("connection", (socket) => {
      console.log("New client connected");

      socket.on("join", (room: string) => this.handleOnJoin(room, socket));

      // payload: { target, user, sdp }
      socket.on("offer", (payload) => this.handleOffer(payload, socket));

      // payload: { target, sdp }
      socket.on("answer", (payload) => this.handleAnswer(payload, socket));

      // incoming: { target: userToSignal, user, candidate: event.candidate }
      socket.on("ice-candidate", (incoming) =>
        this.handleIceCandidate(incoming, socket)
      );

      socket.on("disconnect", () => this.handleDisconnect(socket));
    });
  }

  private async handleOnJoin(room: string, socket: Socket) {
    if (!this.rooms[room]) {
      this.rooms[room] = [];
    }
    this.rooms[room].push(socket.id);
    socket.join(room);
    socket.broadcast.to(room).emit("user-joined", socket.id);
  }

  private handleOffer(payload: any, socket: Socket) {
    this.io.to(payload.target).emit("offer", payload);
  }

  private handleAnswer(payload: any, socket: Socket) {
    this.io.to(payload.target).emit("answer", payload);
  }

  private handleIceCandidate(incoming: any, socket: Socket) {
    this.io.to(incoming.target).emit("ice-candidate", incoming);
  }

  private handleDisconnect(socket: Socket) {
    for (const room in this.rooms) {
      this.rooms[room] = this.rooms[room].filter((id: any) => id !== socket.id);
    }
    console.log("Client disconnected");
  }
}

export default SocketHandler;
