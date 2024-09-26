import { useSelector } from "react-redux";
import {
  Box,
  CircularProgress,
  CircularProgressLabel,
  keyframes,
  Text,
} from "@chakra-ui/react";

import { RootState } from "~/lib/state/store";

interface TimerProps {
  progressCircleSize: number;
  progressCircleThickness: number;
  currentRound: number | null;
  timer: number;
}

const heartBackground = keyframes`
  0% { background-position: 0% 50%; }
  50% { background-position: 100% 50%; }
  100% { background-position: 0% 50%; }
`;

const Timer = ({
  progressCircleSize,
  progressCircleThickness,
  currentRound,
  timer,
}: TimerProps) => {
  const { roomContent: rounds } = useSelector((state: RootState) => state.room);

  return (
    rounds &&
    currentRound !== null &&
    rounds[currentRound]?.duration && (
      <Box
        display="flex"
        alignItems="center"
        justifyContent="center"
        width={`${progressCircleSize}px`}
        height={`${progressCircleSize}px`}
        borderRadius="50%"
        overflow="hidden"
        position={"relative"}
      >
        <Box
          position="absolute"
          top="0"
          left="0"
          width="100%"
          height="100%"
          bg="url(/images/pink-hearts.jpg)"
          backgroundSize="150% 150%"
          animation={`${heartBackground} 5s ease infinite`}
          zIndex="0" // Ensure it's beneath the progress bar
        />

        <CircularProgress
          value={(timer / rounds[currentRound].duration!) * 100}
          size={`${progressCircleSize + 0.18 * progressCircleSize}px`}
          thickness={`${progressCircleThickness}px`}
          color="pink.400"
          trackColor="pink.200"
          capIsRound
          zIndex="1" // Ensure it's above the background and glow
        >
          <CircularProgressLabel>
            <Text
              fontSize="lg"
              fontWeight="bold"
              color="pink.600"
              fontFamily="'Pacifico', cursive"
            >
              {timer}s
            </Text>
          </CircularProgressLabel>
        </CircularProgress>
      </Box>
    )
  );
};

export default Timer;
