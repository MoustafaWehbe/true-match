import { FaForward, FaPause, FaPlay } from "react-icons/fa";
import { useSelector } from "react-redux";
import { Box, Button } from "@chakra-ui/react";

import VideoControls from "../VideoControls";

import { RootState } from "~/lib/state/store";

interface RoomControlsProps {
  currentRound: number | null;
  isPaused: boolean;
  pauseRound: () => void;
  resumeRound: () => void;
  skipRound: () => void;
  onToggleVideo: () => void;
  onToggleMic: () => void;
  isMicOn: boolean;
  isVideoOn: boolean;
  isRoomOwner: boolean;
}

const RoomControls = ({
  currentRound,
  isPaused,
  pauseRound,
  skipRound,
  resumeRound,
  onToggleVideo,
  onToggleMic,
  isMicOn,
  isVideoOn,
  isRoomOwner,
}: RoomControlsProps) => {
  const { roomContent: rounds } = useSelector((state: RootState) => state.room);

  if (!rounds) {
    return null;
  }

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
      padding={4}
    >
      {isRoomOwner && (
        <Button
          aria-label="toggle mic"
          variant="outline"
          width={"205px"}
          colorScheme="blue"
          leftIcon={isPaused ? <FaPlay /> : <FaPause />}
          onClick={() => (isPaused ? resumeRound() : pauseRound())}
          size={"lg"}
          isDisabled={
            currentRound === undefined || currentRound! >= rounds.length - 1
          }
        >
          {isPaused ? "Resume Round" : "Pause Round"}
        </Button>
      )}
      <Box>
        <VideoControls
          onToggleMic={onToggleMic}
          onToggleVideo={onToggleVideo}
          isMicOn={isMicOn}
          isVideoOn={isVideoOn}
          isRoomOwner={isRoomOwner}
        />
      </Box>
      {isRoomOwner && (
        <Button
          aria-label="skip round"
          variant="outline"
          width={"205px"}
          colorScheme="red"
          leftIcon={<FaForward />}
          onClick={skipRound}
          size={"lg"}
          isDisabled={
            currentRound === undefined || currentRound! >= rounds.length - 1
          }
        >
          Skip Round
        </Button>
      )}
    </Box>
  );
};

export default RoomControls;
