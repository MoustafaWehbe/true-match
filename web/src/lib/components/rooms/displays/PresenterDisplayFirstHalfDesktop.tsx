import React from "react";
import { Box, Flex, useColorModeValue } from "@chakra-ui/react";

import MyVideo from "./MyVideo";
import RoundPlayground from "./RoundPlayground";
import StartRound from "./StartRound";
import Timer from "./Timer";
import TimerControls from "./TimerControls";

import useRound from "~/lib/hooks/useRound";

interface PresenterDisplayFirstHalfDesktopProps {
  localVideoRef: React.RefObject<HTMLVideoElement>;
  peers: { peerID: string; peer: RTCPeerConnection }[];
  isMicOn: boolean;
  isVideoOn: boolean;
  currentIndexForSystemQuestion: number;
  onToggleVideo: () => void;
  onToggleMic: () => void;
  onNextQuestionClicked: () => void;
}

const progressCircleThickness = 5;
const progressCircleSize = 140;

const PresenterDisplayFirstHalfDesktop = ({
  localVideoRef,
  isMicOn,
  isVideoOn,
  currentIndexForSystemQuestion,
  onToggleMic,
  onToggleVideo,
  onNextQuestionClicked,
}: PresenterDisplayFirstHalfDesktopProps) => {
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
    resumeCurrentRound,
  } = useRound();

  if (!rounds) {
    return null;
  }

  return (
    <Box height={"30%"} bg={cardBg} color={cardTextColor} borderRadius="10px">
      <Flex direction="row" width="100%" gap={4} height={"100%"}>
        {/* Left Column (25%) */}
        <Flex
          color={cardTextColor}
          justify={"center"}
          align={"center"}
          alignItems={"center"}
          position={"relative"}
          padding={"15px"}
        >
          <MyVideo
            isMicOn={isMicOn}
            isVideoOn={isVideoOn}
            onToggleMic={onToggleMic}
            onToggleVideo={onToggleVideo}
            localVideoRef={localVideoRef}
          />
        </Flex>

        {/* Right Column (75%) */}
        <Box
          width="70%"
          overflow={"auto"}
          p={4}
          color={cardTextColor}
          background={
            currentRound !== null
              ? "linear-gradient(135deg, black 0%, #fecfef 130%)"
              : "transparent"
          }
          borderRadius="10px"
          minHeight={0}
          flexGrow={1}
          position={"relative"}
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
              <Flex gap={4}>
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
                  resumeRound={resumeCurrentRound}
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
      </Flex>
    </Box>
  );
};

export default PresenterDisplayFirstHalfDesktop;
