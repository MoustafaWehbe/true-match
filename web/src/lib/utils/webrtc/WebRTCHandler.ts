import { socketEventTypes } from "@dapp/shared/src/types/custom";

import { PeerItem } from "~/lib/components/rooms/Room";
import { socket } from "~/lib/utils/socket/socket";

export class WebRTCHandler {
  private stream: MediaStream | null = null;
  private peers: PeerItem[] = [];
  private roomId: string;
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
    }
  ) {
    this.roomId = roomId;

    this.onPeersChanged = callbacks.onPeersChanged;
    this.onRoundsStarted = callbacks.onRoundsStarted;
    this.onTimerUpdated = callbacks.onTimerUpdated;
    this.onRoundPaused = callbacks.onRoundPaused;
    this.onRoundResumed = callbacks.onRoundResumed;
    this.onRoundSkiped = callbacks.onRoundSkiped;
    this.onRoundsEnded = callbacks.onRoundsEnded;

    this.handleUserJoined = this.handleUserJoined.bind(this);
    this.handleIncomingOffer = this.handleIncomingOffer.bind(this);
    this.handleAnswer = this.handleAnswer.bind(this);
    this.handleICECandidate = this.handleICECandidate.bind(this);
  }

  async init(localVideoRef: React.RefObject<HTMLVideoElement>) {
    this.stream = await this.fetchUserMedia();
    if (localVideoRef.current) {
      localVideoRef.current.srcObject = this.stream;
    }
    this.registerSocketEvents();
    socket.emit("join", {
      roomId: parseInt(this.roomId),
    } as socketEventTypes.JoinRoomPayload);
  }

  closeConnections() {
    this.peers.forEach(({ peer }) => peer.close());

    socket.emit("leave-room", {
      roomId: parseInt(this.roomId),
    } as socketEventTypes.LeaveRoomPayload);

    socket.off("user-joined", this.handleUserJoined);
    socket.off("offer-produced", this.handleIncomingOffer);
    socket.off("answer", this.handleAnswer);
    socket.off("ice-candidate", this.handleICECandidate);

    const tracks = this.stream?.getTracks();
    tracks?.forEach((track) => track.stop());
  }

  // private method section
  private updatePeers() {
    this.onPeersChanged(this.peers);
  }

  private async fetchUserMedia(): Promise<MediaStream> {
    return navigator.mediaDevices.getUserMedia({
      video: true,
      audio: true,
    });
  }

  private createPeerConnection(userToSignal: string): RTCPeerConnection {
    const peer = new RTCPeerConnection({
      iceServers: [{ urls: "stun:stun.stunprotocol.org" }],
    });

    peer.onicecandidate = (event) => {
      if (event.candidate) {
        socket.emit("ice-candidate", {
          targetSocketId: userToSignal,
          iceCandidateSenderSocketId: socket.id,
          candidate: event.candidate,
        } as socketEventTypes.IceCandidatePayload);
      }
    };

    this.stream
      ?.getTracks()
      .forEach((track) => peer.addTrack(track, this.stream!));

    return peer;
  }

  private handleUserJoined(payload: socketEventTypes.UserJoinedPayload): void {
    const peer = this.createPeerConnection(payload.userToSignal);

    peer.createOffer().then((offer) => {
      peer.setLocalDescription(offer).then(() => {
        socket.emit("offer", {
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
            socket.emit("answer", {
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
    }
    // TODO: do we need to update peers here???
  }

  private registerSocketEvents() {
    socket.on("user-joined", this.handleUserJoined);
    socket.on("offer-produced", this.handleIncomingOffer);
    socket.on("answer", this.handleAnswer);
    socket.on("ice-candidate", this.handleICECandidate);

    // rounds events
    socket.on("rounds-started", this.onRoundsStarted);
    socket.on("timer-updated", this.onTimerUpdated);
    socket.on("round-paused", this.onRoundPaused);
    socket.on("round-resumed", this.onRoundResumed);
    socket.on("round-skiped", this.onRoundSkiped);
    socket.on("rounds-ended", this.onRoundsEnded);
  }
}
