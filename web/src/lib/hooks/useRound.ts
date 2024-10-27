import { useCallback, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";

import { socketEventTypes } from "@dapp/shared/src/types/custom";

import { getSystemQuestions } from "../state/question/questionSlice";
import { getRoomContent, updateSystemQuestions } from "../state/room/roomSlice";
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
    if (activeRoom && activeRoom.questionsCategories) {
      const newQuestions = await dispatch(
        getSystemQuestions({
          categories: activeRoom.questionsCategories,
          roomId: activeRoom.id!,
        })
      );
      dispatch(updateSystemQuestions(newQuestions.payload));
    }
    if (rounds) {
      socket.emit("start-round", {
        rounds,
        roomId: activeRoom?.id!,
      } as socketEventTypes.StartRoundPayload);
    }
  }, [activeRoom, dispatch, rounds]);

  const pauseCurrentRound = useCallback(() => {
    socket.emit("pause-round", {
      timeRemaining: activeRoom?.roomState?.timeRemainingForRoundBeforePause,
      roomId: activeRoom?.id,
    } as socketEventTypes.PauseRoundPayload);
  }, [activeRoom?.id, activeRoom?.roomState?.timeRemainingForRoundBeforePause]);

  const resumeCurrentRound = useCallback(() => {
    socket.emit("resume-round", {
      roomId: activeRoom?.id,
    } as socketEventTypes.PauseRoundPayload);
  }, [activeRoom?.id]);

  const skipCurrentRound = useCallback(() => {
    if (activeRoom?.roomState?.currentRound !== null) {
      socket.emit("skip-round", {
        roomId: activeRoom?.id!,
      } as socketEventTypes.SkipRoundPayload);
    }
  }, [activeRoom?.id, activeRoom?.roomState?.currentRound]);

  const nextQuestionClicked = useCallback(() => {
    socket.emit("go-to-next-question", {
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
