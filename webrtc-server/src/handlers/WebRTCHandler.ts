import { Server as SocketIOServer, Socket } from "socket.io";

import { SOCKET_EVENTS } from "@truematch/shared/src/consts/socketEvents";
import { socketEventTypes } from "@truematch/shared/src/types/custom";

class WebRTCHandler {
  private io: SocketIOServer;

  constructor(io: SocketIOServer) {
    this.io = io;
  }

  public setupListeners(socket: Socket): void {
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
  }

  private handleOffer(payload: socketEventTypes.OfferPayload, socket: Socket) {
    this.io
      .of("/room")
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
      .of("/room")
      .to(payload.targetSocketId)
      .emit(SOCKET_EVENTS.SERVER.SEND_ANSWER_EVENT, payload);
  }

  private handleIceCandidate(
    payload: socketEventTypes.IceCandidatePayload,
    _socket: Socket
  ) {
    this.io
      .of("/room")
      .to(payload.targetSocketId)
      .emit(SOCKET_EVENTS.SERVER.SEND_ICE_CANDIDATE_EVENT, payload);
  }
}

export default WebRTCHandler;
