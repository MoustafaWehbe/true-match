import React, { useState } from "react";
import {
  Box,
  Button,
  CircularProgress,
  CircularProgressLabel,
  Flex,
  Grid,
  IconButton,
  Text,
  Tooltip,
  useColorModeValue,
} from "@chakra-ui/react";
import VideoControls from "./VideoControls";
import PeerVideo from "./PeerVideo";
import useRound from "~/lib/hooks/useRound";
import AnimatedHeart from "../shared/AnimatedHeart";
import { FaForward, FaPause, FaPlay } from "react-icons/fa";

interface PresenterDisplayProps {
  peers: { peerID: string; peer: RTCPeerConnection }[];
  localVideoRef: React.RefObject<HTMLVideoElement>;
}

const PresenterDisplay = ({ peers, localVideoRef }: PresenterDisplayProps) => {
  const cardBg = useColorModeValue("gray.100", "gray.900");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const userJoinedBg = useColorModeValue("gray.100", "gray.900");
  const [isMicOn, setIsMicOn] = useState(true);
  const [isVideoOn, setIsVideoOn] = useState(true);
  const overlayBg = useColorModeValue(
    "rgba(255, 255, 255, 0.8)",
    "rgba(0, 0, 0, 0.8)"
  );
  const {
    timer,
    questions,
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

  if (!rounds) {
    return null;
  }

  return (
    <Flex direction="column">
      {/* First Row */}
      <Flex direction="row" height="25%" width="100%" p={4} gap={4}>
        {/* Left Column (25%) */}
        <Box width="25%" height="100%" bg={cardBg} color={cardTextColor}>
          {/* Add content for the left column here */}
          <Box
            position={"relative"}
            display={"flex"}
            alignItems={"center"}
            justifyContent={"center"}
            height="100%"
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
                height: "100%",
                width: "100%",
              }}
            />
          </Box>
        </Box>

        {/* Right Column (75%) */}
        <Box
          width="75%"
          height="auto"
          p={4}
          bg={cardBg}
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
              width="100%"
              height="100%"
              color="black"
              direction="column"
              align="center"
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
              {currentRound === 2 && (
                <Box>
                  {questions.map((question, idx) => (
                    <Text key={idx} mb={2}>
                      {question}
                    </Text>
                  ))}
                </Box>
              )}
              {rounds && rounds[currentRound]?.duration && (
                <CircularProgress
                  value={(timer / rounds[currentRound].duration) * 100}
                  size="40px"
                  thickness="8px"
                  color="teal.800"
                  trackColor="gray.200"
                  animation="spin 2s linear infinite"
                >
                  <CircularProgressLabel>
                    <Text fontSize="sm" color="gray.700">
                      {timer}s
                    </Text>
                  </CircularProgressLabel>
                </CircularProgress>
              )}
              {currentRound < rounds.length - 1 && (
                <Box
                  ml={4}
                  display="flex"
                  alignItems={"center"}
                  justifyContent={"center"}
                  marginLeft="auto"
                >
                  <Tooltip
                    placement="top"
                    hasArrow
                    arrowSize={15}
                    label="Skip round"
                    fontSize="md"
                  >
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
                  </Tooltip>
                  <Tooltip
                    placement="top"
                    hasArrow
                    arrowSize={15}
                    label="Pause round"
                    fontSize="md"
                  >
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
                  </Tooltip>
                </Box>
              )}
            </Flex>
          )}
          {currentRound === null && (
            <Button
              colorScheme="red"
              variant="solid"
              onClick={startRounds}
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
          bg={userJoinedBg}
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
          height="75%"
          p={4}
          bg={userJoinedBg}
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
