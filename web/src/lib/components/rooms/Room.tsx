"use client";

import React, { useEffect, useRef, useState } from "react";
import { Box, Flex, useColorModeValue } from "@chakra-ui/react";
import { WebRTCHandler } from "~/lib/utils/webrtc/WebRTCHandler";
import PresenterDisplay from "./PresenterDisplay";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "~/lib/state/store";
import { getRoomContent } from "~/lib/state/room/roomSlice";

const Room = ({ roomId: roomID }: { roomId: string }) => {
  const cardBg = useColorModeValue("gray.100", "gray.900");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const localVideoRef = useRef<HTMLVideoElement>(null);
  const webRTCHandler = useRef<WebRTCHandler | null>(null);
  const [peers, setPeers] = useState<
    { peerID: string; peer: RTCPeerConnection }[]
  >([]);

  useEffect(() => {
    webRTCHandler.current = new WebRTCHandler(roomID, setPeers);
    webRTCHandler.current.init(localVideoRef);

    return () => {
      webRTCHandler.current?.closeConnections();
    };
  }, [roomID]);

  return (
    <Flex
      direction="column"
      align="center"
      justify="space-between"
      height="90%"
      bg={cardBg}
      color={cardTextColor}
    >
      <Box position="relative" width="full">
        <PresenterDisplay peers={peers} localVideoRef={localVideoRef} />
      </Box>
    </Flex>
  );
};

export default Room;
