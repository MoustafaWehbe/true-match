import React from "react";
import { Box, Flex, useColorModeValue, useMediaQuery } from "@chakra-ui/react";

import MyVideo from "./MyVideo";
import RoundPlayground from "./RoundPlayground";
import StartRound from "./StartRound";
import Timer from "./Timer";
import TimerControls from "./TimerControls";

import { size } from "~/lib/consts";
import useRound from "~/lib/hooks/useRound";

interface PresenterMainDisplayProps {
  localVideoRef: React.RefObject<HTMLVideoElement>;
  peers: { peerID: string; peer: RTCPeerConnection }[];
  isMicOn: boolean;
  isVideoOn: boolean;
  currentIndexForSystemQuestion: number;
  onToggleVideo: () => void;
  onToggleMic: () => void;
  onNextQuestionClicked: () => void;
}

const PresenterMainDisplay = ({
  localVideoRef,
  isMicOn,
  isVideoOn,
  currentIndexForSystemQuestion,
  onToggleMic,
  onToggleVideo,
  onNextQuestionClicked,
}: PresenterMainDisplayProps) => {
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const cardBg = useColorModeValue("gray.100", "gray.900");
  const [isLaptopOrDesktop] = useMediaQuery(`(min-width: ${size.desktop})`);

  const progressCircleThickness = isLaptopOrDesktop ? 5 : 4;
  const progressCircleSize = isLaptopOrDesktop ? 140 : 70;

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
    <Box
      bg={cardBg}
      color={cardTextColor}
      height={{ base: "initial", lg: "30%" }}
      borderRadius="10px"
      px={{ base: 4, lg: 0 }}
    >
      <Flex
        direction={{ base: "column", lg: "row" }}
        width="100%"
        gap={4}
        height={"100%"}
      >
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
          width={{ base: "100%", lg: "70%" }}
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
          mb={{ base: "20px", lg: "0" }}
          minHeight={{ base: "unset", lg: 0 }}
          flexGrow={{ base: "unset", lg: 1 }}
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

export default PresenterMainDisplay;
