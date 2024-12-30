import { Server as SocketIOServer, Socket } from "socket.io";

import { SOCKET_EVENTS } from "@dapp/shared/src/consts/socketEvents";
import { socketEventTypes } from "@dapp/shared/src/types/custom";
import { UserDto } from "@dapp/shared/src/types/openApiGen";

import { messageService } from "../services";

class MessageHandler {
  private io: SocketIOServer;
  // TODO: move to redis
  private userSocketsMap: Map<string, string>;

  constructor(io: SocketIOServer) {
    this.io = io;
    this.userSocketsMap = new Map();
  }

  public setupListeners(socket: Socket): void {
    const userId = (socket.data.user as UserDto).id;

    this.userSocketsMap.set(`user_socket:${userId}`, socket.id);

    socket.on(
      SOCKET_EVENTS.CLIENT.SEND_MESSAGE,
      (payload: socketEventTypes.SendMessagePayload) =>
        this.handleMessageSent(payload, socket)
    );
  }

  // individual users chat
  private async handleMessageSent(
    payload: socketEventTypes.SendMessagePayload,
    socket: Socket
  ) {
    const { receiverId, content } = payload;
    const token = socket.handshake.auth.token;
    const senderId = (socket.data.user as UserDto).id;
    const chatNamespace = this.io.of("/chat");

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
      chatNamespace
        .to(receiverSocketId)
        .emit(
          SOCKET_EVENTS.SERVER.SEND_MESSAGE,
          messageData as socketEventTypes.MessageSentPayload
        );
    }
  }
}

export default MessageHandler;
