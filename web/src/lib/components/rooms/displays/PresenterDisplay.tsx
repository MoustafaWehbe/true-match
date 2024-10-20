import React, { useCallback, useEffect, useRef, useState } from "react";
import {
  Box,
  Flex,
  Grid,
  GridItem,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";

import AnimatedHeart from "../../shared/AnimatedHeart";
import PeerVideo from "../PeerVideo";
import { PeerItem } from "../Room";

import PresenterMainDisplay from "./PresenterMainDisplay";

import useRound from "~/lib/hooks/useRound";
import { calculateAge } from "~/lib/utils/date/date";

interface PresenterDisplayProps {
  peers: PeerItem[];
  localVideoRef: React.RefObject<HTMLVideoElement>;
}

const PresenterDisplay = ({ peers, localVideoRef }: PresenterDisplayProps) => {
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const cardBg = useColorModeValue("gray.100", "gray.900");
  const [isBottom, setIsBottom] = useState(false);
  const boxRef = useRef<HTMLDivElement>(null);
  const [isMicOn, setIsMicOn] = useState(true);
  const [isVideoOn, setIsVideoOn] = useState(true);
  const [currentIndexForSystemQuestion, setCurrentIndexForSystemQuestion] =
    useState(0);

  const { rounds, systemQuestions, skipCurrentRound: skipRound } = useRound();

  const getGridTemplateColumns = (videoCount: number) => {
    if (videoCount === 1) return "1fr 1fr"; // 1 video takes full width
    if (videoCount === 2) return "repeat(2, 1fr)"; // 2 videos share the space
    return "repeat(3, 1fr)"; // More than 4 videos, 3 per row
  };

  const handleScroll = () => {
    const box = boxRef.current;
    if (box) {
      const isScrolledToBottom =
        Math.round(box.scrollHeight - box.scrollTop) === box.clientHeight;
      setIsBottom(isScrolledToBottom);
    }
  };

  useEffect(() => {
    const box = boxRef.current;
    if (box) {
      box.addEventListener("scroll", handleScroll);
      return () => box.removeEventListener("scroll", handleScroll);
    }
  }, []);

  const onToggleMic = useCallback(() => {
    if (localVideoRef.current) {
      const stream = localVideoRef.current.srcObject as MediaStream | null;
      stream?.getAudioTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsMicOn((prev) => !prev);
    }
  }, [localVideoRef]);

  const onToggleVideo = useCallback(() => {
    if (localVideoRef.current) {
      const stream = localVideoRef.current.srcObject as MediaStream | null;
      stream?.getVideoTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsVideoOn((prev) => !prev);
    }
  }, [localVideoRef]);

  const onNextQuestionClicked = useCallback(() => {
    setCurrentIndexForSystemQuestion((idx) => {
      if (systemQuestions && idx === systemQuestions?.length - 1) {
        skipRound();
        return 0;
      } else {
        return idx + 1;
      }
    });
  }, [skipRound, systemQuestions]);

  if (!rounds) {
    return null;
  }

  return (
    <Flex
      direction="column"
      height={"100%"}
      align="left"
      justify="space-between"
      gap={4}
      mt={{ base: "20px", md: "0px" }}
      mx={{ base: "10px" }}
    >
      {/* First Row */}
      <PresenterMainDisplay
        localVideoRef={localVideoRef}
        peers={peers}
        isMicOn={isMicOn}
        isVideoOn={isVideoOn}
        currentIndexForSystemQuestion={currentIndexForSystemQuestion}
        onToggleMic={onToggleMic}
        onToggleVideo={onToggleVideo}
        onNextQuestionClicked={onNextQuestionClicked}
      />
      {/* Second Row */}
      <Box
        height={{ base: "auto", lg: "70%" }}
        bg={cardBg}
        color={cardTextColor}
        borderRadius="10px"
        position={"relative"}
        _after={{
          content: '""',
          position: "absolute",
          bottom: 0,
          left: 0,
          right: 0,
          height: "30px",
          bgGradient: isBottom
            ? "none"
            : "linear(to-t, rgba(0, 0, 0, 0.9), rgba(0, 0, 0, 0))",
          pointerEvents: "none",
        }}
        mb={4}
      >
        <Box
          ref={boxRef}
          height={"100%"}
          bg={cardBg}
          color={cardTextColor}
          borderRadius="10px"
          overflowY={"auto"}
          position={"relative"}
        >
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
              templateColumns={{
                base: "repeat(2, 1fr)",
                lg: getGridTemplateColumns(9),
              }}
              gap={{ base: 2, md: 6 }}
              minHeight="200px"
              alignContent={"end"}
              padding={6}
              overflowY={"auto"}
            >
              {/* {Array.from(Array(9).keys())?.map((peer, index) => ( */}
              {peers?.map((peer, index) => (
                <GridItem
                  key={index}
                  width="100%"
                  position={"relative"}
                  display={"flex"}
                  justifyContent={"center"}
                  alignItems={"center"}
                >
                  <Flex
                    position={"absolute"}
                    bottom={2}
                    left={4}
                    direction={"column"}
                    gap={0}
                    fontSize={{ base: "s", md: "lg", lg: "xl" }}
                    fontWeight={"bold"}
                    color={"white"}
                  >
                    <Box>{peer.user.firstName}</Box>
                    <Box>
                      {calculateAge(
                        new Date(peer.user?.userProfile?.birthDate!)
                      )}
                    </Box>
                    {/* <Box>My name is</Box> */}
                    {/* <Box>My age is</Box> */}
                  </Flex>
                  <PeerVideo key={index} peer={peer.peer} />
                  {/* <video
                    key={index}
                    autoPlay
                    src="/sample-video.mp4"
                    playsInline
                    width="100%"
                    height="auto"
                    style={{ borderRadius: "10px", marginTop: "10px" }}
                  /> */}
                </GridItem>
              ))}
            </Grid>
          )}
        </Box>
      </Box>
    </Flex>
  );
};

export default PresenterDisplay;
