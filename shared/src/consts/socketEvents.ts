// the string is three parts:
// first part is the type of the source that emits the event (client or server)
// second part is the group the event belongs to (room, chat, video)...
// third part is the name of the event
export const SOCKET_EVENTS = {
  CLIENT: {
    JOIN_ROOM_EVENT: "client:room:user-joined",
    SEND_OFFER_EVENT: "client:video:send-offer",
    SEND_ANSWER_EVENT: "client:viedo:send-answer",
    SEND_ICE_CANDIDATE_EVENT: "client:video:send-ice-candidate",
    LEAVE_ROOM_EVENT: "client:room:leave",
    START_ROUND_EVENT: "client:room:start-round",
    PAUSE_ROUND_EVENT: "client:room:pause-round",
    RESUME_ROUND_EVENT: "client:room:resume-round",
    SKIP_ROUND_EVENT: "client:room:skip-round",
    GO_TO_NEXT_QUESTION_EVENT: "client:room:go-to-next-question",
  },
  SERVER: {
    JOIN_ROOM_EVENT: "server:room:user-joined",
    SEND_ROOM_STATE_EVENT: "server:room:send-room-state",
    SEND_OFFER_EVENT: "server:video:send-offer",
    SEND_ANSWER_EVENT: "server:video:send-answer",
    SEND_ICE_CANDIDATE_EVENT: "server:video:send-ice-candidate",
    START_ROUND_EVENT: "server:room:start-round",
    PAUSE_ROUND_EVENT: "server:room:pause-round",
    RESUME_ROUND_EVENT: "server:room:resume-round",
    SKIP_ROUND_EVENT: "server:room:skip-round",
    GO_TO_NEXT_QUESTION_EVENT: "server:room:go-to-next-question",
    END_ROUNDS_EVENT: "server:room:end-rounds",
    UPDATE_TIMER_EVENT: "server:room:update-timer",
  },
};
