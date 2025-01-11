import {
  RoomContentDto,
  RoomState,
  UserDto,
} from "@truematch/shared/src/types/openApiGen";

interface JoinRoomPayload {
  roomId: string;
}

interface LeaveRoomPayload {
  roomId: string;
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
  roomId: string;
  rounds?: Array<RoomContentDto>;
}

interface PauseRoundPayload {
  roomId: string;
  timeRemaining: number;
}

interface SkipRoundPayload {
  roomId: string;
}

interface GoToNextQuestionPayload {
  roomId: string;
}

interface ResumeRoundPayload {
  roomId: string;
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

interface UserRemovedPayload {
  userSocketId: string;
}

// end round events

// error response
interface EmitErrorPayload {
  message?: any;
  status?: number;
  action?: string;
}

interface EmitDisconnectPayload {
  disconnectedSocketId: string;
}

interface RemoveUserPayload {
  socketIdToRemove: string;
  roomId: string;
}

interface AddNewMatchPayload {
  matchId: string;
  roomId: string;
}

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
  EmitErrorPayload,
  EmitDisconnectPayload,
  RemoveUserPayload,
  UserRemovedPayload,
  AddNewMatchPayload,
};
