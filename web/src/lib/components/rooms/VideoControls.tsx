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
    <Stack
      direction="row"
      spacing={4}
      // bottom={6}
      position="absolute"
      zIndex={1}
      top={8}
      right={8}
      // left="50%"
      // transform="translate(-50%, -50%)"
    >
      <IconButton
        onClick={onToggleMic}
        icon={isMicOn ? <FaMicrophone /> : <FaMicrophoneSlash />}
        variant="ghost"
        width={"28px"}
        size={"xs"}
        height={"28px"}
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
        width={"28px"}
        size={"xs"}
        height={"28px"}
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
