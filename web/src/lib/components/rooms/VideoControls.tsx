import {
  FaMicrophone,
  FaMicrophoneSlash,
  FaVideo,
  FaVideoSlash,
} from "react-icons/fa";
import { IconButton, Stack } from "@chakra-ui/react";

interface VideoControlsProps {
  onToggleMic: () => void;
  onToggleVideo: () => void;
  isMicOn: boolean;
  isVideoOn: boolean;
  isRoomOwner: boolean;
}

const VideoControls = ({
  isMicOn,
  isVideoOn,
  isRoomOwner,
  onToggleMic,
  onToggleVideo,
}: VideoControlsProps) => {
  return (
    <Stack direction="row" spacing={4}>
      <IconButton
        onClick={onToggleMic}
        icon={isMicOn ? <FaMicrophone /> : <FaMicrophoneSlash />}
        variant="ghost"
        width={"48px"}
        size={"md"}
        height={"48px"}
        bg="blackAlpha.600"
        color="white"
        _hover={{ bg: "blackAlpha.400" }}
        aria-label="toggle mic"
      />
      {isRoomOwner && (
        <IconButton
          onClick={onToggleVideo}
          icon={isVideoOn ? <FaVideo /> : <FaVideoSlash />}
          variant="ghost"
          width={"48px"}
          size={"md"}
          height={"48px"}
          bg="blackAlpha.600"
          color="white"
          _hover={{ bg: "blackAlpha.400" }}
          aria-label="toggle video"
        />
      )}
    </Stack>
  );
};

export default VideoControls;
