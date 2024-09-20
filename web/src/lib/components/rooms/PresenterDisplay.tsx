import React, { useState } from "react";
import {
  Box,
  Button,
  CircularProgress,
  CircularProgressLabel,
  Flex,
  Grid,
  IconButton,
  keyframes,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
import VideoControls from "./VideoControls";
import PeerVideo from "./PeerVideo";
import useRound from "~/lib/hooks/useRound";
import AnimatedHeart from "../shared/AnimatedHeart";
import { FaArrowRight, FaForward, FaPause, FaPlay } from "react-icons/fa";
import CustomTooltip from "../shared/CutsomTooltip";

interface PresenterDisplayProps {
  peers: { peerID: string; peer: RTCPeerConnection }[];
  localVideoRef: React.RefObject<HTMLVideoElement>;
}

const heartBackground = keyframes`
  0% { background-position: 0% 50%; }
  50% { background-position: 100% 50%; }
  100% { background-position: 0% 50%; }
`;

const progressCircleThickness = 6;
const progressCircleSize = 80;

const PresenterDisplay = ({ peers, localVideoRef }: PresenterDisplayProps) => {
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const [isMicOn, setIsMicOn] = useState(true);
  const [isVideoOn, setIsVideoOn] = useState(true);
  const [currentIndexForSystemQuestion, setCurrentIndexForSystemQuestion] =
    useState(0);
  const {
    timer,
    systemQuestions,
    currentRound,
    rounds,
    isPaused,
    startRounds,
    pauseRound,
    skipRound,
  } = useRound();

  const onToggleMic = () => {
    if (localVideoRef.current) {
      const stream = localVideoRef.current.srcObject as MediaStream | null;
      stream?.getAudioTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsMicOn((prev) => !prev);
    }
  };

  const onToggleVideo = () => {
    if (localVideoRef.current) {
      const stream = localVideoRef.current.srcObject as MediaStream | null;
      stream?.getVideoTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsVideoOn((prev) => !prev);
    }
  };

  const onNextQuestionClicked = () => {
    setCurrentIndexForSystemQuestion((idx) => {
      if (systemQuestions && idx === systemQuestions?.length - 1) {
        skipRound();
        return 0;
      } else {
        return idx + 1;
      }
    });
  };

  if (!rounds) {
    return null;
  }

  return (
    <Flex
      direction="column"
      height={"100%"}
      align="left"
      justify="space-between"
    >
      {/* First Row */}
      <Flex direction="row" height="50%" width="100%" gap={4}>
        {/* Left Column (25%) */}
        <Box width="25%" height="100%" color={cardTextColor}>
          {/* Add content for the left column here */}
          <Box
            position={"relative"}
            display={"flex"}
            alignItems={"center"}
            justifyContent={"center"}
          >
            <VideoControls
              onToggleMic={onToggleMic}
              onToggleVideo={onToggleVideo}
              isMicOn={isMicOn}
              isVideoOn={isVideoOn}
            />
            <video
              muted
              ref={localVideoRef}
              autoPlay
              playsInline
              style={{
                borderRadius: "10px",
              }}
            />
          </Box>
        </Box>

        {/* Right Column (75%) */}
        <Box
          width="75%"
          height="fit-content"
          maxHeight="200px"
          overflow={"auto"}
          p={4}
          color={cardTextColor}
          background={
            currentRound !== null
              ? "linear-gradient(135deg, #ff9a9e 0%, #fecfef 100%)"
              : "transparent"
          }
          borderRadius="10px"
          minHeight={0}
          flexGrow={1}
        >
          {currentRound !== null && (
            <Flex
              top="0"
              left="0"
              color="black"
              direction="column"
              align="start"
              maxWidth={"88%"}
              justify="center"
              p={4}
              borderRadius="lg"
            >
              <Text fontSize="2xl" mb={2}>
                {rounds[currentRound].title}
              </Text>
              <Text fontSize="md" mb={4}>
                {rounds[currentRound].description}
              </Text>
              {currentRound === 2 && systemQuestions && (
                <Box width={"100%"}>
                  <Text mb={2}>
                    {systemQuestions[currentIndexForSystemQuestion].name}
                  </Text>
                  <Button
                    float={"right"}
                    leftIcon={<FaArrowRight />}
                    onClick={onNextQuestionClicked}
                    colorScheme="blue"
                    color="blue"
                    variant="ghost"
                  >
                    Next question
                  </Button>
                </Box>
              )}
              {rounds && rounds[currentRound]?.duration && (
                <Box
                  position="absolute"
                  top={"70px"}
                  right={"25px"}
                  display="flex"
                  alignItems="center"
                  justifyContent="center"
                  width={`${progressCircleSize - progressCircleThickness - 2}px`}
                  height={`${progressCircleSize - progressCircleThickness - 2}px`}
                  borderRadius="50%"
                  overflow="hidden"
                >
                  <Box
                    position="absolute"
                    top="0"
                    left="0"
                    width="100%"
                    height="100%"
                    bg="url(/images/pink-hearts.jpg)"
                    backgroundSize="150% 150%"
                    animation={`${heartBackground} 5s ease infinite`}
                    zIndex="0" // Ensure it's beneath the progress bar
                  />

                  <CircularProgress
                    value={(timer / rounds[currentRound].duration) * 100}
                    size={`${progressCircleSize}px`}
                    thickness={`${progressCircleThickness}px`}
                    color="pink.400"
                    trackColor="pink.200"
                    capIsRound
                    zIndex="1" // Ensure it's above the background and glow
                  >
                    <CircularProgressLabel>
                      <Text
                        fontSize="lg"
                        fontWeight="bold"
                        color="pink.600"
                        fontFamily="'Pacifico', cursive"
                      >
                        {timer}s
                      </Text>
                    </CircularProgressLabel>
                  </CircularProgress>
                </Box>
              )}
              {currentRound < rounds.length - 1 && (
                <Box
                  ml={4}
                  display="flex"
                  alignItems={"center"}
                  justifyContent={"center"}
                  position={"absolute"}
                  top={"15px"}
                  right={"15px"}
                >
                  <CustomTooltip label="Skip round">
                    <IconButton
                      onClick={skipRound}
                      colorScheme="red"
                      color="red"
                      icon={<FaForward />}
                      variant="ghost"
                      width={"48px"}
                      height={"48px"}
                      aria-label="toggle mic"
                    />
                  </CustomTooltip>
                  <CustomTooltip label="Pause round">
                    <IconButton
                      onClick={pauseRound}
                      colorScheme="yellow"
                      color="yellow"
                      icon={isPaused ? <FaPlay /> : <FaPause />}
                      variant="ghost"
                      width={"48px"}
                      height={"48px"}
                      aria-label="toggle mic"
                    />
                  </CustomTooltip>
                </Box>
              )}
            </Flex>
          )}
          {currentRound === null && (
            <Button
              colorScheme="red"
              variant="outline"
              onClick={startRounds}
              color={"white"}
              float={"right"}
              isDisabled={peers.length === 0}
            >
              Start Rounds
            </Button>
          )}
        </Box>
      </Flex>

      {/* Second Row */}
      {peers?.length === 0 ? (
        <Flex
          direction="column"
          align="center"
          justify="center"
          borderRadius="lg"
          p={6}
          mt={4}
        >
          <Text fontSize="xl" mb={4}>
            Waiting for others to join
          </Text>
          <AnimatedHeart />
        </Flex>
      ) : (
        <Grid
          templateColumns="repeat(auto-fill, minmax(200px, 1fr))"
          gap={4}
          height="50%"
          alignContent={"end"}
        >
          {peers?.map((peer, index) => (
            <PeerVideo key={index} peer={peer.peer} />
          ))}
        </Grid>
      )}
    </Flex>
  );
};

export default PresenterDisplay;
