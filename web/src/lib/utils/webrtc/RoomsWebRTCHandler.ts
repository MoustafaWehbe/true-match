import { SOCKET_EVENTS } from "@dapp/shared/src/consts/socketEvents";
import { socketEventTypes } from "@dapp/shared/src/types/custom";
import { UserDto } from "@dapp/shared/src/types/openApiGen";

import { PeerItem } from "~/lib/components/rooms/Room";
import { peerConfiguration } from "~/lib/consts/webrtc";
import { roomSocket as socket } from "~/lib/utils/socket/socket";

export class RoomsWebRTCHandler {
  private stream: MediaStream | null = null;
  private peers: PeerItem[] = [];
  private roomId: string;
  private config: { roomOwner: boolean };
  private onPeersChanged: (peers: PeerItem[]) => void;
  private onRoundsStarted: (
    payload: socketEventTypes.RoundsStartedPayload
  ) => void;
  private onTimerUpdated: (
    payload: socketEventTypes.TimerUpdatedPayload
  ) => void;
  private onRoundPaused: (payload: socketEventTypes.RoundPausedPayload) => void;
  private onRoundResumed: (
    payload: socketEventTypes.RoundResumedPayload
  ) => void;
  private onRoundSkiped: (payload: socketEventTypes.RoundSkipedPayload) => void;
  private onRoundsEnded: (payload: socketEventTypes.RoundsEndedPayload) => void;
  private onGoToNextQuestion: (
    payload: socketEventTypes.NextQuestionClickedPayload
  ) => void;
  private onRoomStateReceived: (
    payload: socketEventTypes.NextQuestionClickedPayload
  ) => void;
  private onServerError: (payload: socketEventTypes.EmitErrorPayload) => void;
  private onFetchUserMediaError: (event: any) => void;
  private onNewMatch: (payload: socketEventTypes.AddNewMatchPayload) => void;

  constructor(
    roomId: string,
    callbacks: {
      onPeersChanged: (peers: PeerItem[]) => void;
      onRoundsStarted: (payload: socketEventTypes.RoundsStartedPayload) => void;
      onTimerUpdated: (payload: socketEventTypes.TimerUpdatedPayload) => void;
      onRoundPaused: (payload: socketEventTypes.RoundPausedPayload) => void;
      onRoundResumed: (payload: socketEventTypes.RoundResumedPayload) => void;
      onRoundSkiped: (payload: socketEventTypes.RoundSkipedPayload) => void;
      onRoundsEnded: (payload: socketEventTypes.RoundsEndedPayload) => void;
      onGoToNextQuestion: (
        payload: socketEventTypes.NextQuestionClickedPayload
      ) => void;
      onRoomStateReceived: (
        payload: socketEventTypes.SendRoomStatePayload
      ) => void;
      onServerError: (payload: socketEventTypes.EmitErrorPayload) => void;
      onFetchUserMediaError: (payload: any) => void;
      onNewMatch: (payload: socketEventTypes.AddNewMatchPayload) => void;
    },
    config: { roomOwner: boolean }
  ) {
    this.roomId = roomId;
    this.config = config;
    this.peers = [];

    this.onPeersChanged = callbacks.onPeersChanged;
    this.onRoundsStarted = callbacks.onRoundsStarted;
    this.onTimerUpdated = callbacks.onTimerUpdated;
    this.onRoundPaused = callbacks.onRoundPaused;
    this.onRoundResumed = callbacks.onRoundResumed;
    this.onRoundSkiped = callbacks.onRoundSkiped;
    this.onRoundsEnded = callbacks.onRoundsEnded;
    this.onGoToNextQuestion = callbacks.onGoToNextQuestion;
    this.onRoomStateReceived = callbacks.onRoomStateReceived;

    this.handleUserJoined = this.handleUserJoined.bind(this);
    this.handleIncomingOffer = this.handleIncomingOffer.bind(this);
    this.handleAnswer = this.handleAnswer.bind(this);
    this.handleICECandidate = this.handleICECandidate.bind(this);
    this.onSocketDisconnected = this.onSocketDisconnected.bind(this);
    this.handleUserRemoved = this.handleUserRemoved.bind(this);

    this.onServerError = callbacks.onServerError.bind(this);
    this.onFetchUserMediaError = callbacks.onFetchUserMediaError.bind(this);

    this.onNewMatch = callbacks.onNewMatch.bind(this);
  }

  async init(
    localVideoRef: React.RefObject<HTMLVideoElement>,
    localAudioRef: React.RefObject<HTMLAudioElement>
  ) {
    socket.connect();
    try {
      this.stream = await this.fetchUserMedia(true, this.config.roomOwner);
    } catch (error) {
      this.onFetchUserMediaError(error);
    }
    if (localVideoRef.current && this.config.roomOwner) {
      localVideoRef.current.srcObject = this.stream;
    } else if (localAudioRef.current && !this.config.roomOwner) {
      localAudioRef.current.srcObject = this.stream;
    }
    this.registerSocketEvents();
    socket.emit(SOCKET_EVENTS.CLIENT.JOIN_ROOM_EVENT, {
      roomId: this.roomId,
    } as socketEventTypes.JoinRoomPayload);
  }

  closeConnections() {
    this.peers.forEach(({ peer }) => peer.close());

    socket.off(SOCKET_EVENTS.SERVER.JOIN_ROOM_EVENT, this.handleUserJoined);
    socket.off(SOCKET_EVENTS.SERVER.SEND_OFFER_EVENT, this.handleIncomingOffer);
    socket.off(SOCKET_EVENTS.SERVER.SEND_ANSWER_EVENT, this.handleAnswer);
    socket.off(
      SOCKET_EVENTS.SERVER.SEND_ICE_CANDIDATE_EVENT,
      this.handleICECandidate
    );
    socket.off(SOCKET_EVENTS.SERVER.START_ROUND_EVENT, this.onRoundsStarted);
    socket.off(SOCKET_EVENTS.SERVER.UPDATE_TIMER_EVENT, this.onTimerUpdated);
    socket.off(SOCKET_EVENTS.SERVER.PAUSE_ROUND_EVENT, this.onRoundPaused);
    socket.off(SOCKET_EVENTS.SERVER.RESUME_ROUND_EVENT, this.onRoundResumed);
    socket.off(SOCKET_EVENTS.SERVER.SKIP_ROUND_EVENT, this.onRoundSkiped);
    socket.off(SOCKET_EVENTS.SERVER.END_ROUNDS_EVENT, this.onRoundsEnded);
    socket.off(
      SOCKET_EVENTS.SERVER.GO_TO_NEXT_QUESTION_EVENT,
      this.onGoToNextQuestion
    );
    socket.off(
      SOCKET_EVENTS.SERVER.SEND_ROOM_STATE_EVENT,
      this.onRoomStateReceived
    );
    socket.off(SOCKET_EVENTS.SERVER.EMIT_ERROR, this.onServerError);
    socket.off(
      SOCKET_EVENTS.SERVER.EMIT_SOCKET_DISCONNECTED,
      this.onSocketDisconnected
    );
    socket.off(SOCKET_EVENTS.SERVER.REMOVE_USER, this.handleUserRemoved);
    socket.off(SOCKET_EVENTS.SERVER.ADD_NEW_MATCH, this.onNewMatch);

    socket.disconnect();
    const tracks = this.stream?.getTracks();
    tracks?.forEach((track) => track.stop());
    this.peers = [];
    this.updatePeers();
  }

  // private method section
  private updatePeers() {
    this.onPeersChanged(this.peers);
  }

  private async fetchUserMedia(
    audio: boolean,
    video: boolean
  ): Promise<MediaStream> {
    return navigator.mediaDevices.getUserMedia({
      video,
      audio,
    });
  }

  private createPeerConnection(userToSignal: string): RTCPeerConnection {
    const peer = new RTCPeerConnection(peerConfiguration);

    peer.onicecandidate = (event) => {
      if (event.candidate) {
        socket.emit(SOCKET_EVENTS.CLIENT.SEND_ICE_CANDIDATE_EVENT, {
          targetSocketId: userToSignal,
          iceCandidateSenderSocketId: socket.id,
          candidate: event.candidate,
        } as socketEventTypes.IceCandidatePayload);
      }
    };

    if (this.config.roomOwner) {
      this.stream
        ?.getTracks()
        .forEach((track) => peer.addTrack(track, this.stream!));
    } else {
      this.stream
        ?.getAudioTracks()
        .forEach((track) => peer.addTrack(track, this.stream!));
    }
    return peer;
  }

  private async handleUserJoined(payload: socketEventTypes.UserJoinedPayload) {
    const peer = this.createPeerConnection(payload.userToSignal);

    const offer = await peer.createOffer({
      offerToReceiveAudio: true,
      offerToReceiveVideo: true,
    });
    await peer.setLocalDescription(offer);

    socket.emit(SOCKET_EVENTS.CLIENT.SEND_OFFER_EVENT, {
      targetSocketId: payload.userToSignal,
      offerSenderSocketId: socket.id!,
      sdp: peer.localDescription,
    } as socketEventTypes.OfferPayload);

    const peerObj = {
      peerID: payload.userToSignal,
      peer,
      user: payload.user,
    };

    this.pushToPeers(peerObj);
    this.updatePeers();
  }

  private async handleIncomingOffer(
    payload: socketEventTypes.OfferProducedPayload
  ) {
    const peer = this.createPeerConnection(payload.offerSenderSocketId);

    // set the offer to the remote description
    await peer.setRemoteDescription(payload.sdp);

    const answer = await peer.createAnswer();

    await peer.setLocalDescription(answer);

    socket.emit(SOCKET_EVENTS.CLIENT.SEND_ANSWER_EVENT, {
      targetSocketId: payload.offerSenderSocketId,
      answerSenderSocketId: socket.id,
      sdp: peer.localDescription,
    } as socketEventTypes.AnswerPayload);

    const peerObj = {
      peerID: payload.offerSenderSocketId,
      peer,
      user: payload.user,
    };

    this.pushToPeers(peerObj);
    this.updatePeers();
  }

  private handleAnswer = (payload: socketEventTypes.AnswerPayload) => {
    const item = this.peers.find(
      (p) => p.peerID === payload.answerSenderSocketId
    );
    item?.peer.setRemoteDescription(payload.sdp);
    this.updatePeers();
  };

  private handleICECandidate(payload: socketEventTypes.IceCandidatePayload) {
    const item = this.peers.find(
      (p) => p.peerID === payload.iceCandidateSenderSocketId
    );
    if (item) {
      const candidate = new RTCIceCandidate(payload.candidate);
      try {
        item.peer.addIceCandidate(candidate);
      } catch (e) {
        console.error("Failed to add ICE candidate.", e);
      }
      this.updatePeers();
    }
  }

  private handleUserRemoved(payload: socketEventTypes.UserRemovedPayload) {
    this.removeUser(payload.userSocketId);
  }

  private onSocketDisconnected(
    payload: socketEventTypes.EmitDisconnectPayload
  ): void {
    this.removeUser(payload.disconnectedSocketId);
  }

  private removeUser(socketId: string) {
    const peer = this.peers.find((peer) => peer.peerID === socketId);
    if (peer) {
      this.peers = this.peers.filter((p) => p.peerID !== socketId);
      this.updatePeers();
    }

    if (socket.id === socketId) {
      window.location.href = "/";
    }
  }

  private pushToPeers(peerObj: {
    peerID: string;
    peer: RTCPeerConnection;
    user: UserDto;
  }) {
    const userAlreadyExists = this.peers.findIndex(
      (u) => u.user.id === peerObj.user.id
    );

    if (userAlreadyExists !== -1) {
      this.peers[userAlreadyExists] = peerObj;
    } else {
      this.peers.push(peerObj);
    }
  }

  private registerSocketEvents() {
    socket.on(SOCKET_EVENTS.SERVER.JOIN_ROOM_EVENT, this.handleUserJoined);
    socket.on(SOCKET_EVENTS.SERVER.SEND_OFFER_EVENT, this.handleIncomingOffer);
    socket.on(SOCKET_EVENTS.SERVER.SEND_ANSWER_EVENT, this.handleAnswer);
    socket.on(
      SOCKET_EVENTS.SERVER.SEND_ICE_CANDIDATE_EVENT,
      this.handleICECandidate
    );

    // rounds events
    socket.on(SOCKET_EVENTS.SERVER.START_ROUND_EVENT, this.onRoundsStarted);
    socket.on(SOCKET_EVENTS.SERVER.UPDATE_TIMER_EVENT, this.onTimerUpdated);
    socket.on(SOCKET_EVENTS.SERVER.PAUSE_ROUND_EVENT, this.onRoundPaused);
    socket.on(SOCKET_EVENTS.SERVER.RESUME_ROUND_EVENT, this.onRoundResumed);
    socket.on(SOCKET_EVENTS.SERVER.SKIP_ROUND_EVENT, this.onRoundSkiped);
    socket.on(SOCKET_EVENTS.SERVER.END_ROUNDS_EVENT, this.onRoundsEnded);
    socket.on(
      SOCKET_EVENTS.SERVER.GO_TO_NEXT_QUESTION_EVENT,
      this.onGoToNextQuestion
    );
    socket.on(
      SOCKET_EVENTS.SERVER.SEND_ROOM_STATE_EVENT,
      this.onRoomStateReceived
    );
    socket.on(SOCKET_EVENTS.SERVER.REMOVE_USER, this.handleUserRemoved);
    // errors
    socket.on(SOCKET_EVENTS.SERVER.EMIT_ERROR, this.onServerError);
    socket.on(
      SOCKET_EVENTS.SERVER.EMIT_SOCKET_DISCONNECTED,
      this.onSocketDisconnected
    );
    socket.on(SOCKET_EVENTS.SERVER.ADD_NEW_MATCH, this.onNewMatch);
  }
}
