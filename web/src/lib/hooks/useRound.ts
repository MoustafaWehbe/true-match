import { useCallback, useEffect, useRef } from "react";
import { useDispatch, useSelector } from "react-redux";

import { getSystemQuestions } from "../state/question/questionSlice";
import { getRoomContent } from "../state/room/roomSlice";
import {
  pauseRound,
  resetRound,
  setTimer,
  skipRound,
  startRound,
} from "../state/round/roundSlice";
import { AppDispatch, RootState } from "../state/store";

const useRound = () => {
  const dispatch = useDispatch<AppDispatch>();
  const {
    roomContent: rounds,
    roomContentLoading,
    activeRoom,
  } = useSelector((state: RootState) => state.room);
  const { systemQuestions } = useSelector((state: RootState) => state.question);
  const { currentRound, timer, isPaused } = useSelector(
    (state: RootState) => state.round
  );

  const intervalRef = useRef<NodeJS.Timeout | null>(null);

  useEffect(() => {
    if (!rounds && !roomContentLoading) {
      dispatch(getRoomContent());
    }
  }, [dispatch, rounds, roomContentLoading]);

  useEffect(() => {
    if (currentRound !== null && rounds && !isPaused) {
      intervalRef.current = setInterval(() => {
        dispatch(setTimer(timer - 1));
        if (timer <= 1) {
          clearInterval(intervalRef.current!);
          if (currentRound < rounds.length - 1) {
            dispatch(startRound(currentRound + 1));
            dispatch(setTimer(rounds[currentRound + 1].duration!));
          } else {
            dispatch(resetRound());
          }
        }
      }, 1000);
    }

    return () => {
      if (intervalRef.current) clearInterval(intervalRef.current);
    };
  }, [currentRound, isPaused, rounds, timer, dispatch]);

  const startRounds = useCallback(() => {
    dispatch(startRound(0));
    if (rounds) {
      dispatch(setTimer(rounds[0].duration!));
    }
    if (activeRoom && activeRoom.questionsCategories) {
      dispatch(
        getSystemQuestions({ categories: activeRoom.questionsCategories })
      );
    }
  }, [activeRoom, dispatch, rounds]);

  const pauseCurrentRound = useCallback(() => {
    dispatch(pauseRound());
  }, [dispatch]);

  const skipCurrentRound = () => {
    if (currentRound !== null) {
      dispatch(skipRound(currentRound + 1));
      dispatch(setTimer(rounds![currentRound! + 1].duration!));
    }
  };

  return {
    timer,
    systemQuestions,
    currentRound,
    rounds,
    isPaused,
    startRounds,
    pauseCurrentRound,
    skipCurrentRound,
  };
};

export default useRound;
