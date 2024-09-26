import { FaForward, FaPause, FaPlay } from "react-icons/fa";
import { useSelector } from "react-redux";
import { Box, IconButton } from "@chakra-ui/react";

import CustomTooltip from "../../shared/CutsomTooltip";

import { RootState } from "~/lib/state/store";

interface TimerControlsProps {
  currentRound: number | null;
  isPaused: boolean;
  pauseRound: () => void;
  skipRound: () => void;
}

const TimerControls = ({
  currentRound,
  isPaused,
  pauseRound,
  skipRound,
}: TimerControlsProps) => {
  const { roomContent: rounds } = useSelector((state: RootState) => state.room);

  if (rounds && currentRound !== null && currentRound >= rounds.length - 1) {
    return null;
  }
  return (
    <Box
      display="flex"
      alignItems={"center"}
      justifyContent={"center"}
      flexDirection={"column"}
    >
      <CustomTooltip label="Skip round">
        <IconButton
          onClick={skipRound}
          colorScheme="red"
          color="red.600"
          icon={<FaForward />}
          variant="ghost"
          size={"sm"}
          aria-label="toggle mic"
        />
      </CustomTooltip>
      <CustomTooltip label="Pause round">
        <IconButton
          onClick={pauseRound}
          colorScheme="yellow"
          color="yellow"
          icon={isPaused ? <FaPlay /> : <FaPause />}
          variant="ghost"
          size={"sm"}
          aria-label="toggle mic"
        />
      </CustomTooltip>
    </Box>
  );
};

export default TimerControls;
