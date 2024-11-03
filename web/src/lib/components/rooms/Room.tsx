"use client";

import React, { useCallback, useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Box, useToast } from "@chakra-ui/react";

import { socketEventTypes } from "@dapp/shared/src/types/custom";
import { RoomState, UserDto } from "@dapp/shared/src/types/openApiGen";

import PresenterDisplay from "./displays/PresenterDisplay";
import WatcherDisplay from "./displays/WatcherDisplay";

import {
  getRoomById,
  updateActiveRoomStatePartially,
} from "~/lib/state/room/roomSlice";
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
      dispatch(
        updateActiveRoomStatePartially({
          currentRound: payload.roomState.currentRound,
          timeRemainingForRoundBeforePause:
            payload.roomState.timeRemainingForRoundBeforePause,
        } as RoomState)
      );
    },
    [dispatch]
  );
  const onTimerUpdated = useCallback(
    (payload: socketEventTypes.TimerUpdatedPayload) => {
      dispatch(
        updateActiveRoomStatePartially({
          currentRound: payload.roomState.currentRound,
          timeRemainingForRoundBeforePause:
            payload.roomState.timeRemainingForRoundBeforePause,
        } as RoomState)
      );
    },
    [dispatch]
  );

  const onRoomStateReceived = () => {};

  const onRoundPaused = useCallback(
    (payload: socketEventTypes.RoundPausedPayload) => {
      dispatch(
        updateActiveRoomStatePartially({
          isRoundPaused: payload.roomState.isRoundPaused,
        } as RoomState)
      );
    },
    [dispatch]
  );
  const onRoundResumed = useCallback(
    (payload: socketEventTypes.RoundResumedPayload) => {
      dispatch(
        updateActiveRoomStatePartially({
          isRoundPaused: payload.roomState.isRoundPaused,
        } as RoomState)
      );
    },
    [dispatch]
  );
  const onRoundSkiped = useCallback(
    (payload: socketEventTypes.RoundSkipedPayload) => {
      dispatch(
        updateActiveRoomStatePartially({
          timeRemainingForRoundBeforePause:
            payload.roomState.timeRemainingForRoundBeforePause,
          currentRound: payload.roomState.currentRound,
          isRoundPaused: payload.roomState.isRoundPaused,
        } as RoomState)
      );
    },
    [dispatch]
  );
  const onGoToNextQuestion = useCallback(
    (payload: socketEventTypes.NextQuestionClickedPayload) => {
      console.log("onGoToNextQuestion: ", payload.roomState);
      dispatch(
        updateActiveRoomStatePartially({
          currentRound: payload.roomState.currentRound,
          questionIndex: payload.roomState.questionIndex,
        } as RoomState)
      );
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
      onGoToNextQuestion,
      onTimerUpdated,
      onPeersChanged: setPeers,
      onRoomStateReceived,
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
    onGoToNextQuestion,
    roomId,
  ]);

  return (
    <Box height="100%">
      {activeRoom?.user?.id === user?.id ? (
        <PresenterDisplay peers={peers} localVideoRef={localVideoRef} />
      ) : (
        <WatcherDisplay peers={peers} localVideoRef={localVideoRef} />
      )}
    </Box>
  );
};

export default Room;
