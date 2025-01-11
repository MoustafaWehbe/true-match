import { FaForward, FaPause, FaPlay } from "react-icons/fa";
import { MdKeyboardArrowLeft } from "react-icons/md";
import { useSelector } from "react-redux";
import { Box, Button, Flex } from "@chakra-ui/react";

import VideoControls from "../VideoControls";

import { RootState } from "~/lib/state/store";
import isTruthy from "~/lib/utils/truthy";

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
  const { roomContent: rounds, isSkippingRound } = useSelector(
    (state: RootState) => state.room
  );

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
      justifyContent={"space-between"}
      width={"100%"}
      borderTop={"1px solid gray"}
      paddingY={4}
    >
      <Button
        aria-label="Exit room"
        colorScheme="red"
        variant="link"
        leftIcon={<MdKeyboardArrowLeft />}
        onClick={() => {
          window.location.href = "/browse-rooms";
        }}
        size={{ base: "xs", md: "lg" }}
        flex="1"
        display={"flex"}
        justifyContent={"start"}
        margin="0"
        css={{ padding: 0 }}
        style={{ padding: 0 }}
      >
        Exit room
      </Button>
      <VideoControls
        onToggleMic={onToggleMic}
        onToggleVideo={onToggleVideo}
        isMicOn={isMicOn}
        isVideoOn={isVideoOn}
        isRoomOwner={isRoomOwner}
      />
      {isRoomOwner && (
        <Flex
          gap={4}
          justifyContent={"end"}
          alignItems={{ base: "end", md: "end" }}
          flexDir={{ base: "column", md: "row" }}
          flex="1"
        >
          <Button
            aria-label="toggle mic"
            variant="outline"
            colorScheme="blue"
            leftIcon={isPaused ? <FaPlay /> : <FaPause />}
            onClick={onResumeToggleClicked}
            size={{ base: "xs", md: "md" }}
            isDisabled={
              !isTruthy(currentRound) ||
              currentRound! >= rounds.length - 1 ||
              peersCount === 0
            }
          >
            {isPaused ? "Resume round" : "Pause round"}
          </Button>
          <Button
            aria-label="skip round"
            variant="outline"
            colorScheme="red"
            leftIcon={<FaForward />}
            onClick={skipRound}
            size={{ base: "xs", md: "md" }}
            isDisabled={
              !isTruthy(currentRound) ||
              currentRound! >= rounds.length - 1 ||
              peersCount === 0 ||
              isSkippingRound
            }
          >
            Skip round
          </Button>
        </Flex>
      )}
    </Box>
  );
};

export default RoomControls;
