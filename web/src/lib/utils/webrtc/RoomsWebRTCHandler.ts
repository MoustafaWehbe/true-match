import { SOCKET_EVENTS } from "@dapp/shared/src/consts/socketEvents";
import { socketEventTypes } from "@dapp/shared/src/types/custom";

import { PeerItem } from "~/lib/components/rooms/Room";
import { socket } from "~/lib/utils/socket/socket";

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
    },
    config: { roomOwner: boolean }
  ) {
    this.roomId = roomId;
    this.config = config;

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
  }

  async init(
    localVideoRef: React.RefObject<HTMLVideoElement>,
    localAudioRef: React.RefObject<HTMLAudioElement>
  ) {
    socket.connect();
    this.stream = await this.fetchUserMedia(true, this.config.roomOwner);
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

    socket.emit(SOCKET_EVENTS.CLIENT.LEAVE_ROOM_EVENT, {
      roomId: this.roomId,
    } as socketEventTypes.LeaveRoomPayload);

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

    socket.disconnect();
    const tracks = this.stream?.getTracks();
    tracks?.forEach((track) => track.stop());
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
    const peer = new RTCPeerConnection({
      iceServers: [{ urls: "stun:stun.l.google.com:19302" }],
    });

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

  private handleUserJoined(payload: socketEventTypes.UserJoinedPayload): void {
    const peer = this.createPeerConnection(payload.userToSignal);

    peer.createOffer().then((offer) => {
      peer.setLocalDescription(offer).then(() => {
        socket.emit(SOCKET_EVENTS.CLIENT.SEND_OFFER_EVENT, {
          targetSocketId: payload.userToSignal,
          offerSenderSocketId: socket.id!,
          sdp: peer.localDescription,
        } as socketEventTypes.OfferPayload);
      });
    });

    this.peers.push({ peerID: payload.userToSignal, peer, user: payload.user });
    this.updatePeers();
  }

  private handleIncomingOffer(
    payload: socketEventTypes.OfferProducedPayload
  ): void {
    const peer = this.createPeerConnection(payload.offerSenderSocketId);
    peer
      .setRemoteDescription(new RTCSessionDescription(payload.sdp))
      .then(() => {
        peer.createAnswer().then((answer) => {
          peer.setLocalDescription(answer).then(() => {
            socket.emit(SOCKET_EVENTS.CLIENT.SEND_ANSWER_EVENT, {
              targetSocketId: payload.offerSenderSocketId,
              answerSenderSocketId: socket.id,
              sdp: peer.localDescription,
            } as socketEventTypes.AnswerPayload);
          });
        });
      });

    this.peers.push({
      peerID: payload.offerSenderSocketId,
      peer,
      user: payload.user,
    });
    this.updatePeers();
  }

  private handleAnswer = (payload: socketEventTypes.AnswerPayload) => {
    const item = this.peers.find(
      (p) => p.peerID === payload.answerSenderSocketId
    );
    item?.peer.setRemoteDescription(new RTCSessionDescription(payload.sdp));
    this.updatePeers();
  };

  private handleICECandidate(payload: socketEventTypes.IceCandidatePayload) {
    const item = this.peers.find(
      (p) => p.peerID === payload.iceCandidateSenderSocketId
    );
    if (item) {
      const candidate = new RTCIceCandidate(payload.candidate);
      item.peer.addIceCandidate(candidate);
      this.updatePeers();
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
  }
}
