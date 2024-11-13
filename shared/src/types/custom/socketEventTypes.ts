import {
  RoomContentDto,
  RoomState,
  UserDto,
} from "@dapp/shared/src/types/openApiGen";

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

interface UserJoinedPayload {
  userToSignal: string; // socketId
  user: UserDto;
}

interface OfferProducedPayload {
  targetSocketId: string;
  offerSenderSocketId: string;
  sdp: RTCSessionDescription;
  user: UserDto;
}

// round events
interface StartRoundPayload {
  roomId: number;
  rounds?: Array<RoomContentDto>;
}

interface PauseRoundPayload {
  roomId: number;
  timeRemaining: number;
}

interface SkipRoundPayload {
  roomId: number;
}

interface GoToNextQuestionPayload {
  roomId: number;
}

interface ResumeRoundPayload {
  roomId: number;
}

interface RoundPausedPayload {
  roomState: RoomState;
}

interface SendRoomStatePayload {
  roomState: RoomState;
}

interface RoundResumedPayload {
  roomState: RoomState;
}

interface RoundsEndedPayload {
  roomState: RoomState;
}

interface TimerUpdatedPayload {
  roomState: RoomState;
}

interface RoundsStartedPayload {
  roomState: RoomState;
}

interface RoundSkipedPayload {
  roomState: RoomState;
}

interface NextQuestionClickedPayload {
  roomState: RoomState;
}

interface SendMessagePayload {
  receiverId: string;
  content: string;
}

interface MessageSentPayload {
  senderId: string;
  receiverId: string;
  content: string;
}
// end round events

export type {
  JoinRoomPayload,
  LeaveRoomPayload,
  OfferPayload,
  AnswerPayload,
  IceCandidatePayload,
  StartRoundPayload,
  PauseRoundPayload,
  ResumeRoundPayload,
  RoundPausedPayload,
  RoundResumedPayload,
  RoundsEndedPayload,
  TimerUpdatedPayload,
  RoundsStartedPayload,
  RoundSkipedPayload,
  SkipRoundPayload,
  UserJoinedPayload,
  OfferProducedPayload,
  GoToNextQuestionPayload,
  NextQuestionClickedPayload,
  SendRoomStatePayload,
  SendMessagePayload,
  MessageSentPayload,
};
