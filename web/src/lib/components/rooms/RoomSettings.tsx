import { Button, Stack } from '@chakra-ui/react';
import {
  FaMicrophone,
  FaMicrophoneSlash,
  FaVideo,
  FaVideoSlash,
} from 'react-icons/fa';

interface RoomSettings {
  onToggleMic: () => void;
  onToggleVideo: () => void;
  isMicOn: boolean;
  isVideoOn: boolean;
}

const RoomSettings = ({
  isMicOn,
  isVideoOn,
  onToggleMic,
  onToggleVideo,
}: RoomSettings) => {
  return (
    <Stack direction="row" spacing={4} mt={4} mb={8}>
      <Button
        onClick={onToggleMic}
        leftIcon={isMicOn ? <FaMicrophone /> : <FaMicrophoneSlash />}
        variant="outline"
      >
        {isMicOn ? 'Mute' : 'Unmute'}
      </Button>
      <Button
        onClick={onToggleVideo}
        leftIcon={isVideoOn ? <FaVideo /> : <FaVideoSlash />}
        variant="outline"
      >
        {isVideoOn ? 'Turn Off Video' : 'Turn On Video'}
      </Button>
    </Stack>
  );
};

export default RoomSettings;
