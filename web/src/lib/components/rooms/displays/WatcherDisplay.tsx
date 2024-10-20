import React, { useCallback, useMemo, useState } from "react";
import { useSelector } from "react-redux";
import {
  Box,
  Flex,
  Text,
  useColorModeValue,
  useMediaQuery,
} from "@chakra-ui/react";
import { motion } from "framer-motion";

import PeerVideo from "../PeerVideo";
import { PeerItem } from "../Room";

import MyVideo from "./MyVideo";
import RoundPlayground from "./RoundPlayground";
import Timer from "./Timer";

import { size } from "~/lib/consts";
import useRound from "~/lib/hooks/useRound";
import { RootState } from "~/lib/state/store";

interface WatcherProps {
  peers: PeerItem[];
  localVideoRef: React.RefObject<HTMLVideoElement>;
}

const MotionBox = motion(Box as any); // Create a motion-enhanced Box component

const Watcher = ({ peers, localVideoRef }: WatcherProps) => {
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const cardBg = useColorModeValue("gray.100", "gray.900");
  const [isMicOn, setIsMicOn] = useState(true);
  const [isVideoOn, setIsVideoOn] = useState(true);
  const [currentIndexForSystemQuestion] = useState(0);
  const { activeRoom } = useSelector((state: RootState) => state.room);
  const [isLaptopOrDesktop] = useMediaQuery(`(min-width: ${size.desktop})`);

  const { rounds, currentRound, timer } = useRound();
  const progressCircleThickness = isLaptopOrDesktop ? 5 : 4;
  const progressCircleSize = isLaptopOrDesktop ? 140 : 70;

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

  const thePresenter = useMemo(() => {
    return peers.find((peer) => peer.user.id === activeRoom?.user?.id);
  }, [activeRoom?.user?.id, peers]);

  console.log({
    activeRoom,
    peers,
  });

  if (!rounds) {
    return null;
  }

  // const peers2 = Array.from(Array(4).keys());
  const peersWithoutThePresenter = peers.filter(
    (peer) => peer.user.id !== activeRoom?.user!.id!
  );
  const leftPeers = peersWithoutThePresenter.slice(
    0,
    Math.round(peersWithoutThePresenter.length / 2) - 1
  );
  const rightPeers = peersWithoutThePresenter.slice(
    Math.round(peersWithoutThePresenter.length / 2) - 1
  );

  const peerAnimationProps = {
    initial: { opacity: 0, scale: 0.8 },
    animate: { opacity: 1, scale: 1 },
    transition: { duration: 0.5, ease: "easeInOut" },
  };

  // Define a special animation for the central video (zoom-in with rotation)
  const centralVideoAnimationProps = {
    initial: { opacity: 0, scale: 0.5, rotate: 45 },
    animate: { opacity: 1, scale: 1, rotate: 0 },
    transition: { duration: 1, ease: "easeOut" }, // Slower and more dramatic
  };

  return (
    <Box
      height="calc(100vh - 300px)"
      bg={cardBg}
      color={cardTextColor}
      position="relative"
    >
      <Flex p={4} display="flex" justifyContent="space-between" height={"100%"}>
        {/* Peer Videos - Left */}
        <Flex direction="column" gap={4}>
          <MotionBox
            width="240px"
            height="180px"
            borderRadius="10px"
            display="flex"
            justifyContent="center"
            alignItems="center"
            position="relative"
            {...peerAnimationProps} // Apply animation properties
          >
            <MyVideo
              isMicOn={isMicOn}
              isVideoOn={isVideoOn}
              onToggleMic={onToggleMic}
              onToggleVideo={onToggleVideo}
              localVideoRef={localVideoRef}
            />
          </MotionBox>
          {leftPeers.map((peer, index) => (
            <MotionBox
              key={index}
              width="200px"
              height="120px"
              borderRadius="10px"
              display="flex"
              justifyContent="center"
              alignItems="center"
              {...peerAnimationProps} // Apply animation properties
            >
              <PeerVideo peer={peer.peer} />
              {/* <video
                autoPlay
                playsInline
                src={"/sample-video.mp4"}
                width="100%"
                height="100%"
                style={{ borderRadius: "10px" }}
              /> */}
            </MotionBox>
          ))}
        </Flex>

        {/* Central Video */}
        <MotionBox
          position="relative"
          bg="gray.700"
          borderRadius="10px"
          height="40%"
          width="50%"
          display="flex"
          justifyContent="center"
          alignItems="center"
          marginTop="10%"
          {...centralVideoAnimationProps} // Apply special animation
        >
          {thePresenter ? (
            <PeerVideo peer={thePresenter.peer} />
          ) : (
            <Box>Hmm.. where is the presenter?</Box>
          )}
        </MotionBox>

        {/* Peer Videos - Right */}
        <Flex direction="column" gap={4}>
          {rightPeers.map((peer, index) => (
            <MotionBox
              key={index}
              width="200px"
              height="120px"
              borderRadius="10px"
              display="flex"
              justifyContent="center"
              alignItems="center"
              {...peerAnimationProps} // Apply animation properties
            >
              <PeerVideo peer={peer.peer} />
              {/* <video
                autoPlay
                playsInline
                src={"/sample-video.mp4"}
                width="100%"
                height="100%"
                style={{ borderRadius: "10px" }}
              /> */}
            </MotionBox>
          ))}
        </Flex>
      </Flex>
      {/* Rounds go here */}
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
        mb={{ base: "20px", lg: "0" }}
        flexGrow={{ base: "unset", lg: 1 }}
        minHeight={"150px"}
        display={"flex"}
        justifyContent={"center"}
      >
        {currentRound !== null && (
          <Flex
            justifyContent={"space-between"}
            alignItems={"center"}
            height={"100%"}
          >
            <RoundPlayground
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
            </Flex>
          </Flex>
        )}

        {currentRound === null && <Text>Rounds play here</Text>}
      </Box>
    </Box>
  );
};

export default Watcher;
