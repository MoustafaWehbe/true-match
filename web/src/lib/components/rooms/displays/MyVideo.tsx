import { Box, Flex } from "@chakra-ui/react";

import VideoControls from "../VideoControls";

interface MyVideoProps {
  onToggleVideo: () => void;
  onToggleMic: () => void;
  isMicOn: boolean;
  isVideoOn: boolean;
  localVideoRef: React.RefObject<HTMLVideoElement>;
}

const MyVideo = ({
  onToggleMic,
  onToggleVideo,
  isMicOn,
  isVideoOn,
  localVideoRef,
}: MyVideoProps) => {
  return (
    <>
      <VideoControls
        onToggleMic={onToggleMic}
        onToggleVideo={onToggleVideo}
        isMicOn={isMicOn}
        isVideoOn={isVideoOn}
      />
      <Flex
        position={"absolute"}
        bottom={8}
        left={8}
        direction={"column"}
        gap={2}
        fontSize={{ base: "s", md: "lg", lg: "xl" }}
        fontWeight={"bold"}
      >
        <Box color={"white"}>You</Box>
      </Flex>
      <video
        muted
        ref={localVideoRef}
        autoPlay
        width={"100%"}
        playsInline
        style={{
          borderRadius: "10px",
          height: "100%",
          objectFit: "cover",
        }}
      />
    </>
  );
};
export default MyVideo;
