import { useEffect, useRef, useState } from "react";
import { RoomContentDto } from "../openApiGen";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../state/store";
import { getRoomContent } from "../state/room/roomSlice";

const useRound = () => {
  const [currentRound, setCurrentRound] = useState<number | null>(null);
  const [timer, setTimer] = useState(0);
  const [questions, setQuestions] = useState<string[]>([]);
  const [isPaused, setIsPaused] = useState(false);

  const dispatch = useDispatch<AppDispatch>();
  const { roomContent: rounds, roomContentLoading } = useSelector(
    (state: RootState) => state.room
  );
  const intervalRef = useRef<NodeJS.Timeout | null>(null);

  useEffect(() => {
    if (!rounds && !roomContentLoading) {
      dispatch(getRoomContent());
    }
  }, [dispatch, rounds, roomContentLoading]);

  useEffect(() => {
    if (currentRound !== null && rounds && !isPaused) {
      // Start the round timer when not paused
      const round = rounds[currentRound];
      setTimer(round.duration!);

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
  }, [currentRound, rounds]);

  useEffect(() => {
    if (currentRound === 2) {
      const randomQuestions = [
        "What's your hidden talent?",
        "If you could travel anywhere, where would it be?",
        "What's your favorite movie?",
      ];
      setQuestions(randomQuestions);
    }
  }, [currentRound]);

  const startRounds = () => {
    setCurrentRound(0);
  };

  const pauseRound = () => {
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
  };

  const skipRound = () => {
    setCurrentRound((cr) => cr! + 1);
  };

  return {
    timer,
    questions,
    currentRound,
    rounds,
    isPaused,
    startRounds,
    pauseRound,
    skipRound,
  };
};
export default useRound;
