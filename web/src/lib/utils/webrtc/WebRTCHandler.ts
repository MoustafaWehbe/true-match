import { socket } from "~/lib/utils/socket/socket";

export class WebRTCHandler {
  private stream: MediaStream | null = null;
  private peers: { peerID: string; peer: RTCPeerConnection }[] = [];
  private roomID: string;
  private onPeersChanged: (
    peers: { peerID: string; peer: RTCPeerConnection }[]
  ) => void;

  constructor(
    roomID: string,
    onPeersChanged: (
      peers: { peerID: string; peer: RTCPeerConnection }[]
    ) => void
  ) {
    this.roomID = roomID;

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
    socket.emit("join", this.roomID);
  }

  closeConnections() {
    this.peers.forEach(({ peer }) => peer.close());
    socket.emit("leave-room", this.roomID);
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
          target: userToSignal,
          user: socket.id,
          candidate: event.candidate,
        });
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
          target: userToSignal,
          user: socket.id!,
          sdp: peer.localDescription,
        });
      });
    });

    this.peers.push({ peerID: userToSignal, peer });
    this.updatePeers();
  }

  private handleIncomingOffer(incoming: {
    sdp: RTCSessionDescriptionInit;
    user: string;
  }): void {
    const peer = this.createPeerConnection(incoming.user);
    peer
      .setRemoteDescription(new RTCSessionDescription(incoming.sdp))
      .then(() => {
        peer.createAnswer().then((answer) => {
          peer.setLocalDescription(answer).then(() => {
            socket.emit("answer", {
              target: incoming.user,
              user: socket.id,
              sdp: peer.localDescription,
            });
          });
        });
      });

    this.peers.push({ peerID: incoming.user, peer });
    this.updatePeers();
  }

  private handleAnswer = (message: {
    sdp: RTCSessionDescriptionInit;
    user: string;
  }) => {
    const item = this.peers.find((p) => p.peerID === message.user);
    item?.peer.setRemoteDescription(new RTCSessionDescription(message.sdp));
    this.updatePeers();
  };

  private handleICECandidate(incoming: {
    user: string;
    target: string;
    candidate: RTCIceCandidateInit;
  }) {
    const item = this.peers.find((p) => p.peerID === incoming.user);
    if (item) {
      const candidate = new RTCIceCandidate(incoming.candidate);
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
