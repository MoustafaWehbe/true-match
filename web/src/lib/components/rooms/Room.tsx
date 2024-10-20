"use client";

import React, { useCallback, useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Box, useToast } from "@chakra-ui/react";

import { socketEventTypes } from "@dapp/shared/src/types/custom";
import { UserDto } from "@dapp/shared/src/types/openApiGen";

import PresenterDisplay from "./displays/PresenterDisplay";
import WatcherDisplay from "./displays/WatcherDisplay";

import { getRoomById } from "~/lib/state/room/roomSlice";
import {
  pauseRound,
  resumeRound,
  setTimer,
  startRound,
} from "~/lib/state/round/roundSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import { WebRTCHandler } from "~/lib/utils/webrtc/WebRTCHandler";

export interface PeerItem {
  peerID: string;
  peer: RTCPeerConnection;
  user: UserDto;
}

const Room = ({ roomId }: { roomId: string }) => {
  const localVideoRef = useRef<HTMLVideoElement>(null);
  const webRTCHandler = useRef<WebRTCHandler | null>(null);
  const [peers, setPeers] = useState<PeerItem[]>([]);

  const { activeRoom } = useSelector((state: RootState) => state.room);
  const { user } = useSelector((state: RootState) => state.user);
  const dispatch = useDispatch<AppDispatch>();
  const toast = useToast();

  useEffect(() => {
    dispatch(getRoomById(parseInt(roomId)));
  }, [dispatch, roomId]);

  const onRoundsStarted = useCallback(
    (payload: socketEventTypes.RoundsStartedPayload) => {
      dispatch(startRound(0));
      dispatch(setTimer(payload.roomState.rounds![0].duration!));
    },
    [dispatch]
  );
  const onTimerUpdated = useCallback(
    (payload: socketEventTypes.TimerUpdatedPayload) => {
      dispatch(setTimer(payload.roomState.timeRemainingForRoundBeforePause!));
      dispatch(startRound(payload.roomState.currentRound!));
    },
    [dispatch]
  );
  const onRoundPaused = useCallback(
    (_payload: socketEventTypes.RoundPausedPayload) => {
      dispatch(pauseRound());
    },
    [dispatch]
  );
  const onRoundResumed = useCallback(
    (_payload: socketEventTypes.RoundResumedPayload) => {
      dispatch(resumeRound());
    },
    [dispatch]
  );
  const onRoundSkiped = useCallback(
    (payload: socketEventTypes.RoundSkipedPayload) => {
      dispatch(setTimer(payload.roomState.timeRemainingForRoundBeforePause!));
      dispatch(startRound(payload.roomState.currentRound!));
      dispatch(resumeRound());
    },
    [dispatch]
  );
  const onRoundsEnded = useCallback(
    (_payload: socketEventTypes.RoundsEndedPayload) => {
      toast({
        title:
          "You nailed it! Remember, it’s all about stepping into the spotlight :)",
        status: "success",
        duration: null,
        isClosable: true,
      });
    },
    [toast]
  );

  useEffect(() => {
    webRTCHandler.current = new WebRTCHandler(roomId, {
      onRoundPaused,
      onRoundResumed,
      onRoundSkiped,
      onRoundsEnded,
      onRoundsStarted,
      onTimerUpdated,
      onPeersChanged: setPeers,
    });
    webRTCHandler.current.init(localVideoRef);

    return () => {
      webRTCHandler.current?.closeConnections();
    };
  }, [
    onRoundPaused,
    onRoundResumed,
    onRoundSkiped,
    onRoundsEnded,
    onRoundsStarted,
    onTimerUpdated,
    roomId,
  ]);

  return (
    <Box height={{ base: "100%", lg: "calc(100vh - 60px - 75px)" }}>
      {activeRoom?.user?.id === user?.id ? (
        <PresenterDisplay peers={peers} localVideoRef={localVideoRef} />
      ) : (
        <Box position="relative" width="full">
          <WatcherDisplay peers={peers} localVideoRef={localVideoRef} />
        </Box>
      )}
    </Box>
  );
};

export default Room;
