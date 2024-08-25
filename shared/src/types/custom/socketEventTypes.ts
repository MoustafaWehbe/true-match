interface JoinRoomPayload {
  roomId: number;
}

interface LeaveRoomPayload {
  roomId: number;
}

interface OfferPayload {
  targetSocketId: string;
  offerSenderSocketId: string;
  sdp: RTCSessionDescription;
}

interface AnswerPayload {
  targetSocketId: string;
  answerSenderSocketId: string;
  sdp: RTCSessionDescription;
}

interface IceCandidatePayload {
  targetSocketId: string;
  iceCandidateSenderSocketId: string;
  candidate: RTCIceCandidate;
}

export {
  JoinRoomPayload,
  LeaveRoomPayload,
  OfferPayload,
  AnswerPayload,
  IceCandidatePayload,
};
