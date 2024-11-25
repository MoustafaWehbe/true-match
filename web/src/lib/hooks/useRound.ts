import { useCallback, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";

import { SOCKET_EVENTS } from "@dapp/shared/src/consts/socketEvents";
import { socketEventTypes } from "@dapp/shared/src/types/custom";

import { getRoomContent } from "../state/room/roomSlice";
import { AppDispatch, RootState } from "../state/store";

import { socket } from "~/lib/utils/socket/socket";

const useRound = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { roomContent: rounds, activeRoom } = useSelector(
    (state: RootState) => state.room
  );
  const { systemQuestions } = useSelector((state: RootState) => state.question);

  useEffect(() => {
    if (!rounds) {
      dispatch(getRoomContent());
    }
  }, [dispatch, rounds]);

  const startRounds = useCallback(async () => {
    if (rounds) {
      socket.emit(SOCKET_EVENTS.CLIENT.START_ROUND_EVENT, {
        rounds,
        roomId: activeRoom?.id!,
      } as socketEventTypes.StartRoundPayload);
    }
  }, [activeRoom, rounds]);

  const pauseCurrentRound = useCallback(() => {
    socket.emit(SOCKET_EVENTS.CLIENT.PAUSE_ROUND_EVENT, {
      timeRemaining: activeRoom?.roomState?.timeRemainingForRoundBeforePause,
      roomId: activeRoom?.id,
    } as socketEventTypes.PauseRoundPayload);
  }, [activeRoom?.id, activeRoom?.roomState?.timeRemainingForRoundBeforePause]);

  const resumeCurrentRound = useCallback(() => {
    socket.emit(SOCKET_EVENTS.CLIENT.RESUME_ROUND_EVENT, {
      roomId: activeRoom?.id,
    } as socketEventTypes.PauseRoundPayload);
  }, [activeRoom?.id]);

  const skipCurrentRound = useCallback(() => {
    if (activeRoom?.roomState?.currentRound !== null) {
      socket.emit(SOCKET_EVENTS.CLIENT.SKIP_ROUND_EVENT, {
        roomId: activeRoom?.id!,
      } as socketEventTypes.SkipRoundPayload);
    }
  }, [activeRoom?.id, activeRoom?.roomState?.currentRound]);

  const nextQuestionClicked = useCallback(() => {
    socket.emit(SOCKET_EVENTS.CLIENT.GO_TO_NEXT_QUESTION_EVENT, {
      roomId: activeRoom?.id!,
    } as socketEventTypes.GoToNextQuestionPayload);
  }, [activeRoom?.id]);

  return {
    systemQuestions,
    rounds,
    startRounds,
    pauseCurrentRound,
    skipCurrentRound,
    resumeCurrentRound,
    nextQuestionClicked,
  };
};

export default useRound;
