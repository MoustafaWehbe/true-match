import React, { useCallback, useState } from "react";
import { FaArrowLeft } from "react-icons/fa";
import { IoIosArrowUp } from "react-icons/io";
import { IoIosArrowDown } from "react-icons/io";
import { useSelector } from "react-redux";
import {
  Box,
  Button,
  Flex,
  Grid,
  GridItem,
  Text,
  useColorModeValue,
  useMediaQuery,
} from "@chakra-ui/react";

import AnimatedHeart from "../../shared/AnimatedHeart";
import PeerVideo from "../PeerVideo";
import { PeerItem } from "../Room";

import MyVideo from "./MyVideo";
import RoomControls from "./RoomControls";
import RoundPlayground from "./RoundPlayground";
import StartRound from "./StartRound";
import Timer from "./Timer";

import { size } from "~/lib/consts";
import useRound from "~/lib/hooks/useRound";
import { RootState } from "~/lib/state/store";
import { calculateAge } from "~/lib/utils/date/date";

interface PresenterDisplayProps {
  peers: PeerItem[];
  localVideoRef: React.RefObject<HTMLVideoElement>;
}
const PresenterDisplay = ({ peers, localVideoRef }: PresenterDisplayProps) => {
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const [isMicOn, setIsMicOn] = useState(true);
  const [isUpperPanelCollapsed, setIsUpperPanelCollapsed] = useState(true);
  const [isVideoOn, setIsVideoOn] = useState(true);
  const { activeRoom } = useSelector((state: RootState) => state.room);

  const {
    rounds,
    skipCurrentRound,
    pauseCurrentRound,
    startRounds,
    resumeCurrentRound,
    nextQuestionClicked,
  } = useRound();

  const [isLaptopOrDesktop] = useMediaQuery(`(min-width: ${size.desktop})`);

  const progressCircleThickness = isLaptopOrDesktop ? 5 : 4;
  const progressCircleSize = isLaptopOrDesktop ? 140 : 70;

  const getGridTemplateColumns = (videoCount: number) => {
    if (videoCount === 1) return "1fr 1fr"; // 1 video takes full width
    if (videoCount === 2) return "repeat(2, 1fr)"; // 2 videos share the space
    return "repeat(4, 1fr)"; // More than 4 videos, 3 per row
  };

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

  const onUpperPanelToggleClick = () => {
    setIsUpperPanelCollapsed((isCollapsed) => !isCollapsed);
  };

  if (!rounds) {
    return null;
  }

  return (
    <Box
      height={"100%"}
      mt={{ base: "20px", md: "0px" }}
      mx={{ base: "10px" }}
      position={"relative"}
    >
      <Box
        position="absolute"
        top={0}
        left={0}
        right={0}
        height={isUpperPanelCollapsed ? "200px" : "350px"}
        transition="height 0.3s ease-in-out"
        minHeight="200px"
        backgroundColor="gray.800"
        borderBottomLeftRadius="20px"
        borderBottomRightRadius="20px"
        boxShadow="0 4px 12px rgba(0, 0, 0, 0.1)"
        overflow="hidden"
        zIndex={10}
        opacity={0.8}
      >
        <Flex
          width={"100%"}
          alignItems={"start"}
          justifyContent={"space-between"}
        >
          <Flex
            color={cardTextColor}
            justify={"center"}
            align={"center"}
            alignItems={"center"}
            position={"relative"}
            padding={"15px"}
            width={"265px"}
          >
            <MyVideo localVideoRef={localVideoRef} />
          </Flex>
          {peers?.length === 0 ? (
            <Box
              id="peer-container"
              height="100%"
              overflowY="auto"
              // padding={4}
              position="absolute"
              transform="translateX(-50%)"
              left="50%"
              width="60%"
            >
              <Flex
                direction="column"
                align="center"
                justify="center"
                height="100%"
                gap={6}
              >
                <Text fontSize="xl">Waiting for others to join</Text>
                <AnimatedHeart />
              </Flex>
            </Box>
          ) : (
            <Box
              id="peer-container"
              height={isUpperPanelCollapsed ? "200px" : "350px"}
              transition="height 0.3s ease-in-out"
              overflowY="auto"
              margin={"0 auto"}
              css={{
                "&::-webkit-scrollbar": {
                  display: "none", // Hide scrollbar in WebKit browsers
                },
                "&": {
                  scrollbarWidth: "none", // Hide scrollbar in Firefox
                },
              }}
            >
              <Grid
                templateColumns={{
                  base: "repeat(2, 1fr)",
                  lg: getGridTemplateColumns(2),
                }}
                gap={{ base: 2, md: 6 }}
                minHeight="200px"
                alignContent={"start"}
                padding={8}
                overflowY={"auto"}
              >
                {/* {Array.from(Array(2).keys())?.map((peer, index) => ( */}
                {peers?.map((peer, index) => (
                  <GridItem
                    key={index}
                    position={"relative"}
                    display={"flex"}
                    justifyContent={"center"}
                    alignItems={"center"}
                    maxWidth={"200px"}
                  >
                    <Flex
                      position={"absolute"}
                      bottom={2}
                      left={4}
                      direction={"column"}
                      gap={0}
                      fontSize={{ base: "s", md: "s" }}
                      fontWeight={"bold"}
                      color={"white"}
                    >
                      <Box>{peer.user.firstName}</Box>
                      <Box>
                        {calculateAge(
                          new Date(peer.user?.userProfile?.birthDate!)
                        )}
                      </Box>
                      {/* <Box>My name is</Box>
                      <Box>My age is</Box> */}
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
            </Box>
          )}
        </Flex>

        {/* collapse / expand */}
        <Box
          position="absolute"
          bottom={0}
          left="50%"
          transform="translateX(-50%)"
          cursor={"pointer"}
          width={"40px"}
          overflow={"hidden"}
          onClick={onUpperPanelToggleClick}
        >
          {isUpperPanelCollapsed ? (
            <IoIosArrowDown size={"s"} />
          ) : (
            <IoIosArrowUp size={"s"} />
          )}
        </Box>
      </Box>
      {/* Rounds section */}
      <Flex
        width={"100%"}
        p={4}
        color={cardTextColor}
        borderRadius="10px"
        position={"relative"}
        mb={{ base: "20px", lg: "0" }}
        alignItems={"center"}
        height={"100%"}
        justify={"center"}
        gap={8}
      >
        {/* <Image
          src="/images/in-a-date.jpg"
          alt="In a date"
          boxSize="250px"
          objectFit="cover"
          rounded={"50%"}
        /> */}
        {activeRoom?.roomState?.currentRound !== undefined && (
          <Flex
            height={"100%"}
            direction={"column"}
            justifyContent={"center"}
            gap={4}
            // mt={"100px"}
          >
            <Text textAlign={"left"}>
              Round {activeRoom?.roomState?.currentRound! + 1}
            </Text>
            <RoundPlayground
              onNextQuestionClicked={nextQuestionClicked}
              currentIndexForSystemQuestion={
                activeRoom?.roomState?.questionIndex || 0
              }
              currentRound={activeRoom?.roomState?.currentRound!}
            />
            <Box
              position={"absolute"}
              top={"50%"}
              right={8}
              transform="translateY(-50%)"
            >
              {/* Timer section */}
              <Timer
                progressCircleSize={progressCircleSize}
                progressCircleThickness={progressCircleThickness}
                currentRound={activeRoom?.roomState?.currentRound!}
                timer={activeRoom?.roomState?.timeRemainingForRoundBeforePause!}
              />
            </Box>
          </Flex>
        )}
        {activeRoom?.roomState?.currentRound === undefined ? (
          <StartRound
            startRounds={startRounds}
            // isDisabled={peers.length === 0}
          />
        ) : null}
      </Flex>
      {/* timer controls */}
      <RoomControls
        currentRound={activeRoom?.roomState?.currentRound!}
        isPaused={activeRoom?.roomState?.isRoundPaused!}
        pauseRound={pauseCurrentRound}
        resumeRound={resumeCurrentRound}
        skipRound={skipCurrentRound}
        onToggleVideo={onToggleVideo}
        onToggleMic={onToggleMic}
        isMicOn={isMicOn}
        isVideoOn={isVideoOn}
      />
      <Button
        variant="link"
        colorScheme="red"
        onClick={() => {
          window.location.href = "/browse-rooms";
        }}
        leftIcon={<FaArrowLeft />}
        position="fixed"
        left="0"
        bottom="140px"
        px={4}
        py={2}
      >
        Exit Room
      </Button>
    </Box>
  );
};

export default PresenterDisplay;
