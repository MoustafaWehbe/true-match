import { Button, Stack } from "@chakra-ui/react";
import {
  FaMicrophone,
  FaMicrophoneSlash,
  FaVideo,
  FaVideoSlash,
} from "react-icons/fa";

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
    <Stack direction="row" spacing={4} top={0} position={"absolute"}>
      <Button
        onClick={onToggleMic}
        leftIcon={isMicOn ? <FaMicrophone /> : <FaMicrophoneSlash />}
        variant="ghost"
        width={10}
        height={10}
      />
      <Button
        onClick={onToggleVideo}
        leftIcon={isVideoOn ? <FaVideo /> : <FaVideoSlash />}
        variant="ghost"
      />
    </Stack>
  );
};

export default VideoControls;
