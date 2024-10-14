"use client";

import React, { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Box, Heading } from "@chakra-ui/react";

import PresenterDisplay from "./displays/PresenterDisplay";

import { getRoomById } from "~/lib/state/room/roomSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import { WebRTCHandler } from "~/lib/utils/webrtc/WebRTCHandler";

const Room = ({ roomId }: { roomId: string }) => {
  const localVideoRef = useRef<HTMLVideoElement>(null);
  const webRTCHandler = useRef<WebRTCHandler | null>(null);
  const [peers, setPeers] = useState<
    { peerID: string; peer: RTCPeerConnection }[]
  >([]);

  const { activeRoom, activeRoomLoading } = useSelector(
    (state: RootState) => state.room
  );
  const { user } = useSelector((state: RootState) => state.user);
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
    <Box height={{ base: "100%", lg: "calc(100vh - 60px - 75px)" }}>
      {activeRoom?.user?.id === user?.id ? (
        <PresenterDisplay peers={peers} localVideoRef={localVideoRef} />
      ) : (
        <Box position="relative" width="full">
          <Heading as={"h2"}>Viewer</Heading>
          <PresenterDisplay peers={peers} localVideoRef={localVideoRef} />
        </Box>
      )}
    </Box>
  );
};

export default Room;
