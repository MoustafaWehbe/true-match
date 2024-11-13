import { SOCKET_EVENTS } from "@dapp/shared/src/consts/socketEvents";
import { socketEventTypes } from "@dapp/shared/src/types/custom";

import { socket } from "~/lib/utils/socket/socket";

export class IndividualChatWebRTCHandler {
  private handleSendMessage: (
    message: socketEventTypes.MessageSentPayload
  ) => void;

  constructor(callbacks: {
    handleSendMessage: (message: socketEventTypes.MessageSentPayload) => void;
  }) {
    this.handleSendMessage = callbacks.handleSendMessage;
  }

  async init() {
    socket.connect();
    this.registerSocketEvents();
  }

  closeConnections() {
    socket.off(SOCKET_EVENTS.SERVER.SEND_MESSAGE, this.handleSendMessage);
    socket.disconnect();
  }

  private registerSocketEvents() {
    socket.on(SOCKET_EVENTS.SERVER.SEND_MESSAGE, this.handleSendMessage);
  }
}
