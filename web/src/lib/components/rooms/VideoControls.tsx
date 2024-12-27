import {
  FaMicrophone,
  FaMicrophoneSlash,
  FaVideo,
  FaVideoSlash,
} from "react-icons/fa";
import { IconButton, Stack } from "@chakra-ui/react";

interface VideoControlsProps {
  isMicOn: boolean;
  isVideoOn: boolean;
  isRoomOwner: boolean;
  onToggleMic?: () => void;
  onToggleVideo?: () => void;
}

const VideoControls = ({
  isMicOn,
  isVideoOn,
  isRoomOwner,
  onToggleMic,
  onToggleVideo,
}: VideoControlsProps) => {
  return (
    <Stack direction="row" spacing={{ base: 1, md: 4 }}>
      <IconButton
        onClick={onToggleMic}
        icon={isMicOn ? <FaMicrophone size={12} /> : <FaMicrophoneSlash />}
        variant="ghost"
        bg="blackAlpha.600"
        color="white"
        minWidth={{ base: 8, md: 12 }}
        height={{ base: 8, md: 12 }}
        _hover={{ bg: "blackAlpha.400" }}
        aria-label="toggle mic"
      />
      {isRoomOwner && (
        <IconButton
          onClick={onToggleVideo}
          icon={isVideoOn ? <FaVideo size={12} /> : <FaVideoSlash />}
          variant="ghost"
          bg="blackAlpha.600"
          minWidth={{ base: 8, md: 12 }}
          height={{ base: 8, md: 12 }}
          color="white"
          _hover={{ bg: "blackAlpha.400" }}
          aria-label="toggle video"
        />
      )}
    </Stack>
  );
};

export default VideoControls;
