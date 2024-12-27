import { FaForward, FaPause, FaPlay } from "react-icons/fa";
import { useSelector } from "react-redux";
import { Box, Button } from "@chakra-ui/react";

import VideoControls from "../VideoControls";

import { RootState } from "~/lib/state/store";

interface RoomControlsProps {
  currentRound: number | null;
  isPaused: boolean;
  isMicOn: boolean;
  isVideoOn: boolean;
  isRoomOwner: boolean;
  peersCount: number;
  pauseRound?: () => void;
  resumeRound?: () => void;
  skipRound?: () => void;
  onToggleVideo?: () => void;
  onToggleMic?: () => void;
}

const RoomControls = ({
  currentRound,
  isPaused,
  isMicOn,
  isVideoOn,
  isRoomOwner,
  peersCount,
  pauseRound,
  skipRound,
  resumeRound,
  onToggleVideo,
  onToggleMic,
}: RoomControlsProps) => {
  const { roomContent: rounds } = useSelector((state: RootState) => state.room);

  if (!rounds) {
    return null;
  }

  const onResumeToggleClicked = () => {
    if (isPaused && resumeRound) {
      resumeRound();
    } else if (pauseRound) {
      pauseRound();
    }
  };

  return (
    <Box
      display="flex"
      alignItems={"center"}
      justifyContent={isRoomOwner ? "space-between" : "center"}
      position={"absolute"}
      bottom={0}
      width={"100%"}
      left={0}
      borderTop={"1px solid gray"}
      paddingY={4}
    >
      {isRoomOwner && (
        <Button
          aria-label="toggle mic"
          variant="outline"
          colorScheme="blue"
          leftIcon={isPaused ? <FaPlay /> : <FaPause />}
          onClick={onResumeToggleClicked}
          size={{ base: "xs", md: "lg" }}
          isDisabled={
            currentRound === undefined ||
            currentRound! >= rounds.length - 1 ||
            peersCount === 0
          }
        >
          {isPaused ? "Resume Round" : "Pause Round"}
        </Button>
      )}
      <VideoControls
        onToggleMic={onToggleMic}
        onToggleVideo={onToggleVideo}
        isMicOn={isMicOn}
        isVideoOn={isVideoOn}
        isRoomOwner={isRoomOwner}
      />
      {isRoomOwner && (
        <Button
          aria-label="skip round"
          variant="outline"
          colorScheme="red"
          leftIcon={<FaForward />}
          onClick={skipRound}
          size={{ base: "xs", md: "lg" }}
          isDisabled={
            currentRound === undefined ||
            currentRound! >= rounds.length - 1 ||
            peersCount === 0
          }
        >
          Skip Round
        </Button>
      )}
    </Box>
  );
};

export default RoomControls;
