import React from "react";
import { Box, Flex, useColorModeValue } from "@chakra-ui/react";

import MyVideo from "./MyVideo";
import RoundPlayground from "./RoundPlayground";
import StartRound from "./StartRound";
import Timer from "./Timer";
import TimerControls from "./TimerControls";

import useRound from "~/lib/hooks/useRound";

interface PresenterDisplayFirstHalfMobileProps {
  peers: { peerID: string; peer: RTCPeerConnection }[];
  localVideoRef: React.RefObject<HTMLVideoElement>;
  isMicOn: boolean;
  isVideoOn: boolean;
  currentIndexForSystemQuestion: number;
  onToggleVideo: () => void;
  onToggleMic: () => void;
  onNextQuestionClicked: () => void;
}

const progressCircleThickness = 4;
const progressCircleSize = 70;

const PresenterDisplayFirstHalfMobile = ({
  localVideoRef,
  isMicOn,
  isVideoOn,
  currentIndexForSystemQuestion,
  onToggleMic,
  onToggleVideo,
  onNextQuestionClicked,
}: PresenterDisplayFirstHalfMobileProps) => {
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const cardBg = useColorModeValue("gray.100", "gray.900");

  const {
    currentRound,
    rounds,
    timer,
    isPaused,
    pauseCurrentRound,
    skipCurrentRound,
    startRounds,
  } = useRound();

  if (!rounds) {
    return null;
  }

  return (
    <Box bg={cardBg} color={cardTextColor} borderRadius="10px" px={4}>
      <Box color={cardTextColor} position={"relative"} py={"15px"} width="100%">
        <MyVideo
          isMicOn={isMicOn}
          isVideoOn={isVideoOn}
          onToggleMic={onToggleMic}
          onToggleVideo={onToggleVideo}
          localVideoRef={localVideoRef}
        />
      </Box>

      <Box
        width="100%"
        overflow={"auto"}
        p={4}
        color={cardTextColor}
        background={
          currentRound !== null
            ? "linear-gradient(135deg, black 0%, #fecfef 130%)"
            : "transparent"
        }
        borderRadius="10px"
        position={"relative"}
        mb={"20px"}
      >
        {currentRound !== null && (
          <Flex
            justifyContent={"space-between"}
            alignItems={"center"}
            height={"100%"}
          >
            <RoundPlayground
              onNextQuestionClicked={onNextQuestionClicked}
              currentIndexForSystemQuestion={currentIndexForSystemQuestion}
              currentRound={currentRound}
            />

            <Flex gap={4} direction={{ base: "column", lg: "row" }}>
              {/* Timer section */}
              <Timer
                progressCircleSize={progressCircleSize}
                progressCircleThickness={progressCircleThickness}
                currentRound={currentRound}
                timer={timer}
              />
              {/* timer controls */}
              <TimerControls
                currentRound={currentRound}
                isPaused={isPaused}
                pauseRound={pauseCurrentRound}
                skipRound={skipCurrentRound}
              />
            </Flex>
          </Flex>
        )}

        {currentRound === null && (
          <StartRound
            startRounds={startRounds}
            // isDisabled={peers.length === 0}
          />
        )}
      </Box>
    </Box>
  );
};

export default PresenterDisplayFirstHalfMobile;
