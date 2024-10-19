import { useCallback, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";

import { socketEventTypes } from "@dapp/shared/src/types/custom";

import { getSystemQuestions } from "../state/question/questionSlice";
import { getRoomContent } from "../state/room/roomSlice";
import { AppDispatch, RootState } from "../state/store";

import { socket } from "~/lib/utils/socket/socket";

const useRound = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { roomContent: rounds, activeRoom } = useSelector(
    (state: RootState) => state.room
  );
  const { systemQuestions } = useSelector((state: RootState) => state.question);
  const { currentRound, timer, isPaused } = useSelector(
    (state: RootState) => state.round
  );

  useEffect(() => {
    if (!rounds) {
      dispatch(getRoomContent());
    }
  }, [dispatch, rounds]);

  const startRounds = useCallback(async () => {
    if (activeRoom && activeRoom.questionsCategories) {
      await dispatch(
        getSystemQuestions({
          categories: activeRoom.questionsCategories,
          roomId: activeRoom.id!,
        })
      );
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
      timeRemaining: timer,
      roomId: activeRoom?.id,
    } as socketEventTypes.PauseRoundPayload);
  }, [activeRoom?.id, timer]);

  const resumeCurrentRound = useCallback(() => {
    socket.emit("resume-round", {
      roomId: activeRoom?.id,
    } as socketEventTypes.PauseRoundPayload);
  }, [activeRoom?.id]);

  const skipCurrentRound = useCallback(() => {
    if (currentRound !== null) {
      socket.emit("skip-round", {
        roomId: activeRoom?.id!,
      } as socketEventTypes.SkipRoundPayload);
    }
  }, [activeRoom?.id, currentRound]);

  return {
    timer,
    systemQuestions,
    currentRound,
    rounds,
    isPaused,
    startRounds,
    pauseCurrentRound,
    skipCurrentRound,
    resumeCurrentRound,
  };
};

export default useRound;
