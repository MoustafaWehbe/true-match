import { socket } from "~/lib/utils/socket/socket";
import { socketEventTypes } from "@dapp/shared/src/types/custom";

export class WebRTCHandler {
  private stream: MediaStream | null = null;
  private peers: { peerID: string; peer: RTCPeerConnection }[] = [];
  private roomId: string;
  private onPeersChanged: (
    peers: { peerID: string; peer: RTCPeerConnection }[]
  ) => void;

  constructor(
    roomId: string,
    onPeersChanged: (
      peers: { peerID: string; peer: RTCPeerConnection }[]
    ) => void
  ) {
    this.roomId = roomId;

    this.onPeersChanged = onPeersChanged;

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
    socket.off("offer", this.handleIncomingOffer);
    socket.off("answer", this.handleAnswer);
    socket.off("ice-candidate", this.handleICECandidate);
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

  private handleUserJoined(userToSignal: string): void {
    const peer = this.createPeerConnection(userToSignal);

    peer.createOffer().then((offer) => {
      peer.setLocalDescription(offer).then(() => {
        socket.emit("offer", {
          targetSocketId: userToSignal,
          offerSenderSocketId: socket.id!,
          sdp: peer.localDescription,
        } as socketEventTypes.OfferPayload);
      });
    });

    this.peers.push({ peerID: userToSignal, peer });
    this.updatePeers();
  }

  private handleIncomingOffer(payload: socketEventTypes.OfferPayload): void {
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

    this.peers.push({ peerID: payload.offerSenderSocketId, peer });
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
  }

  private registerSocketEvents() {
    socket.on("user-joined", this.handleUserJoined);
    socket.on("offer", this.handleIncomingOffer);
    socket.on("answer", this.handleAnswer);
    socket.on("ice-candidate", this.handleICECandidate);
  }
}
