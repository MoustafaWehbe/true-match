"use client";

import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Box, Flex, useColorModeValue } from "@chakra-ui/react";

import PresenterDisplay from "./PresenterDisplay";

import { getRoomById } from "~/lib/state/room/roomSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import { WebRTCHandler } from "~/lib/utils/webrtc/WebRTCHandler";

const Room = ({ roomId: roomId }: { roomId: string }) => {
  const cardBg = useColorModeValue("gray.100", "gray.900");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const localVideoRef = useRef<HTMLVideoElement>(null);
  const webRTCHandler = useRef<WebRTCHandler | null>(null);
  const [peers, setPeers] = useState<
    { peerID: string; peer: RTCPeerConnection }[]
  >([]);

  const { activeRoom, activeRoomLoading } = useSelector(
    (state: RootState) => state.room
  );
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    if (!activeRoom && !activeRoomLoading) {
      dispatch(getRoomById(parseInt(roomId)));
    }
  }, [dispatch, activeRoom, activeRoomLoading, roomId]);

  useEffect(() => {
    webRTCHandler.current = new WebRTCHandler(roomId, setPeers);
    webRTCHandler.current.init(localVideoRef);

    return () => {
      webRTCHandler.current?.closeConnections();
    };
  }, [roomId]);

  return (
    <Flex height="90%" bg={cardBg} color={cardTextColor} borderRadius="10px">
      <Box position="relative" width="full">
        <PresenterDisplay peers={peers} localVideoRef={localVideoRef} />
      </Box>
    </Flex>
  );
};

export default Room;
