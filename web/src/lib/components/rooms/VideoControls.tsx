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
}

const VideoControls = ({
  isMicOn,
  isVideoOn,
  onToggleMic,
  onToggleVideo,
}: VideoControlsProps) => {
  return (
    <Stack direction="row" spacing={4} top="74%" position="absolute" zIndex={1}>
      <IconButton
        onClick={onToggleMic}
        icon={isMicOn ? <FaMicrophone /> : <FaMicrophoneSlash />}
        variant="ghost"
        width={"48px"}
        height={"48px"}
        bg="blackAlpha.700"
        color="white"
        borderRadius="full"
        _hover={{ bg: "blackAlpha.800" }}
        aria-label="toggle mic"
      />
      <IconButton
        onClick={onToggleVideo}
        icon={isVideoOn ? <FaVideo /> : <FaVideoSlash />}
        variant="ghost"
        width={"48px"}
        height={"48px"}
        bg="blackAlpha.700"
        color="white"
        borderRadius="full"
        _hover={{ bg: "blackAlpha.800" }}
        aria-label="toggle video"
      />
    </Stack>
  );
};

export default VideoControls;
