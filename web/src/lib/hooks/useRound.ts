import { useCallback, useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";

import { getSystemQuestions } from "../state/question/questionSlice";
import { getRoomContent } from "../state/room/roomSlice";
import { AppDispatch, RootState } from "../state/store";

const useRound = () => {
  const [currentRound, setCurrentRound] = useState<number | null>(null);
  const [timer, setTimer] = useState(0);
  const [isPaused, setIsPaused] = useState(false);

  const dispatch = useDispatch<AppDispatch>();
  const {
    roomContent: rounds,
    roomContentLoading,
    activeRoom,
  } = useSelector((state: RootState) => state.room);
  const { systemQuestions } = useSelector((state: RootState) => state.question);

  const intervalRef = useRef<NodeJS.Timeout | null>(null);

  useEffect(() => {
    if (!rounds && !roomContentLoading) {
      dispatch(getRoomContent());
    }
  }, [dispatch, rounds, roomContentLoading]);

  useEffect(() => {
    if (currentRound !== null && rounds && !isPaused) {
      intervalRef.current = setInterval(() => {
        setTimer((prevTimer) => {
          if (prevTimer <= 1) {
            clearInterval(intervalRef.current!);
            if (currentRound < rounds.length - 1) {
              setCurrentRound((prevRound) => prevRound! + 1);
            } else {
              setCurrentRound(null);
            }
            return 0;
          }
          return prevTimer - 1;
        });
      }, 1000);
    }

    return () => {
      if (intervalRef.current) clearInterval(intervalRef.current);
    };
  }, [currentRound, isPaused, rounds]);

  const startRounds = useCallback(() => {
    setCurrentRound(0);
    if (rounds) {
      setTimer(rounds[0].duration!);
    }
    if (activeRoom && activeRoom.questionsCategories) {
      dispatch(
        getSystemQuestions({ categories: activeRoom.questionsCategories })
      );
    }
  }, [activeRoom, dispatch, rounds]);

  const pauseRound = useCallback(() => {
    setIsPaused((prevIsPaused) => {
      if (!prevIsPaused) {
        if (intervalRef.current) clearInterval(intervalRef.current);
      } else if (rounds && currentRound !== null) {
        intervalRef.current = setInterval(() => {
          setTimer((prevTimer) => {
            if (prevTimer <= 1) {
              clearInterval(intervalRef.current!);
              if (currentRound < rounds.length - 1) {
                setCurrentRound((prevRound) => prevRound! + 1);
              } else {
                setCurrentRound(null);
              }
              return 0;
            }
            return prevTimer - 1;
          });
        }, 1000);
      }
      return !prevIsPaused;
    });
  }, [currentRound, rounds]);

  const skipRound = () => {
    setCurrentRound((cr) => cr! + 1);
  };

  return {
    timer,
    systemQuestions,
    currentRound,
    rounds,
    isPaused,
    startRounds,
    pauseRound,
    skipRound,
  };
};
export default useRound;
