import { Server as SocketIOServer, Socket } from "socket.io";

import MessageHandler from "./handlers/MessageHandler";
import RoomHandler from "./handlers/RoomHandler";
import WebRTCHandler from "./handlers/WebRTCHandler";
import authMiddleware from "./middlwares/authMiddleware";

class SocketHandler {
  private io: SocketIOServer;
  // TODO: move to redis
  private timersMap: Map<
    string,
    { timer: NodeJS.Timeout; timeRemaining: number }
  >;

  // TODO: move to redis
  private socketRooms: Map<string, string[]>;

  private webRTCHandler: WebRTCHandler;
  private messageHandler: MessageHandler;
  private roomHandler: RoomHandler;

  constructor(io: SocketIOServer) {
    this.io = io;

    this.timersMap = new Map();
    this.socketRooms = new Map();

    this.webRTCHandler = new WebRTCHandler(io);
    this.messageHandler = new MessageHandler(io);
    this.roomHandler = new RoomHandler(io, this.socketRooms, this.timersMap);

    this.setupNamespaces();
  }

  private setupNamespaces(): void {
    const roomNamespace = this.io.of("/room");
    roomNamespace.use(authMiddleware);
    roomNamespace.on("connection", (socket: Socket) => {
      console.log("New user connected to room namespace");
      this.webRTCHandler.setupListeners(socket);
      this.roomHandler.setupListeners(socket);
    });

    const chatNamespace = this.io.of("/chat");
    chatNamespace.use(authMiddleware);
    chatNamespace.on("connection", (socket: Socket) => {
      console.log("New user connected to chat namespace");
      this.messageHandler.setupListeners(socket);
    });
  }
}

export default SocketHandler;
