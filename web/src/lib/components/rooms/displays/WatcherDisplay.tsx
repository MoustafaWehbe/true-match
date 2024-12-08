import React, { useCallback, useMemo, useState } from "react";
import { FaArrowLeft } from "react-icons/fa";
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

import MyAudio from "./MyAudio";
import RoomControls from "./RoomControls";
import RoundPlayground from "./RoundPlayground";
import Timer from "./Timer";

import { size } from "~/lib/consts";
import useRound from "~/lib/hooks/useRound";
import { RootState } from "~/lib/state/store";
import { calculateAge } from "~/lib/utils/date/date";
import isTruthy from "~/lib/utils/truthy";

interface WatcherDisplayProps {
  peers: PeerItem[];
  localAudioRef: React.RefObject<HTMLAudioElement>;
}

const WatcherDisplay = ({ peers, localAudioRef }: WatcherDisplayProps) => {
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const [isMicOn, setIsMicOn] = useState(true);
  const { activeRoom } = useSelector((state: RootState) => state.room);
  const { user } = useSelector((state: RootState) => state.user);

  const {
    rounds,
    skipCurrentRound,
    pauseCurrentRound,
    resumeCurrentRound,
    nextQuestionClicked,
  } = useRound();

  const presenterBgGradient = useColorModeValue(
    "linear(to-r, teal.300, blue.500)",
    "linear(to-r, pink.500, purple.500)"
  );

  const [isLaptopOrDesktop] = useMediaQuery(`(min-width: ${size.desktop})`);

  const progressCircleThickness = isLaptopOrDesktop ? 5 : 4;
  const progressCircleSize = isLaptopOrDesktop ? 140 : 70;

  const onToggleMic = useCallback(() => {
    if (localAudioRef.current) {
      const stream = localAudioRef.current.srcObject as MediaStream | null;
      stream?.getAudioTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsMicOn((prev) => !prev);
    }
  }, [localAudioRef]);

  const thePresenter = useMemo(() => {
    return peers.find((peer) => peer.user.id === activeRoom?.user?.id);
  }, [activeRoom?.user?.id, peers]);

  if (!rounds) {
    return null;
  }

  return (
    <Box height={"100%"} width={"100%"} padding={10}>
      <Grid
        templateColumns="33% 1fr" // First column takes 40% of the width, second column fills the remaining space
        templateRows="repeat(3, 1fr)" // Dynamic row heights
        gap={4}
        width="100%"
        maxHeight="70vh"
        alignItems={"center"}
        overflow={"scroll"}
        _before={{
          content: '""',
          position: "absolute",
          top: 20,
          bottom: 40,
          left: "33%",
          width: "1px",
          backgroundColor: "red",
          transform: "translateX(-50%)",
        }}
      >
        {/* First Column - 3 Rows */}
        <GridItem
          gridColumn={1}
          gridRow={1}
          position={"relative"}
          maxWidth={"350px"}
        >
          {thePresenter ? (
            <>
              <Flex
                direction={"column"}
                gap={4}
                fontSize={{ base: "s", md: "s" }}
                fontWeight={"bold"}
                color={"white"}
              >
                <Box textTransform={"uppercase"}>
                  {thePresenter.user.firstName},{" "}
                  {calculateAge(
                    new Date(thePresenter.user?.userProfile?.birthDate!)
                  )}
                </Box>
                <PeerVideo peer={thePresenter.peer} />
              </Flex>
            </>
          ) : (
            <Text
              fontSize="lg"
              bgGradient={presenterBgGradient}
              color="white"
              p={4}
              borderRadius="lg"
              boxShadow="lg"
              textAlign="center"
              border="1px solid white"
              w="50%"
              align="center"
              transform="scale(1)"
              transition="transform 0.3s ease-in-out"
              _hover={{ transform: "scale(1.05)" }}
            >
              The presenter appears here &#128525;
            </Text>
          )}
        </GridItem>

        <GridItem gridColumn={1} gridRow={2}>
          <Flex
            color={cardTextColor}
            justify="center"
            align="center"
            alignItems="center"
            position="relative"
            width="200px"
          >
            <MyAudio localAudioRef={localAudioRef} />
          </Flex>
        </GridItem>

        <GridItem gridColumn={1} gridRow={3}>
          {peers?.length >= 3 ? (
            <Text fontSize="xl">
              You and {peers.length - 1} watchers are attending.
            </Text>
          ) : (
            <Text fontSize="md" opacity={"80%"}>
              It’s just you here, enjoy!
            </Text>
          )}
        </GridItem>

        {/* Second Column */}
        <GridItem gridRow={"1 / span 3"} gridColumn={2} width={"100%"}>
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
            // justify={"center"}
            gap={8}
          >
            {isTruthy(activeRoom?.roomState?.currentRound) && (
              <Flex
                height={"100%"}
                direction={"column"}
                justifyContent={"center"}
                gap={4}
                maxWidth={"70%"}
                marginLeft={10}
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
                    timer={
                      activeRoom?.roomState?.timeRemainingForRoundBeforePause!
                    }
                  />
                </Box>
              </Flex>
            )}
            {!isTruthy(activeRoom?.roomState?.currentRound) ? (
              <Flex
                direction="column"
                align="center"
                justify="center"
                height="100%"
                gap={6}
              >
                <Text fontSize="xl">
                  Waiting for the first round to start..
                </Text>
                <AnimatedHeart />
              </Flex>
            ) : null}
          </Flex>
        </GridItem>
      </Grid>

      {/* timer controls */}
      <RoomControls
        currentRound={activeRoom?.roomState?.currentRound!}
        isPaused={activeRoom?.roomState?.isRoundPaused!}
        pauseRound={pauseCurrentRound}
        resumeRound={resumeCurrentRound}
        skipRound={skipCurrentRound}
        onToggleVideo={() => {}}
        onToggleMic={onToggleMic}
        isMicOn={isMicOn}
        isVideoOn={false}
        isRoomOwner={activeRoom?.user?.id === user?.id}
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
        bottom="100px"
        px={4}
        py={2}
      >
        Exit Room
      </Button>
    </Box>
  );
};

export default WatcherDisplay;
