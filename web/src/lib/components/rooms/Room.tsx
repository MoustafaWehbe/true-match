"use client";

import React, { useCallback, useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Box, useToast } from "@chakra-ui/react";
import { useRouter } from "next/navigation";

import { socketEventTypes } from "@dapp/shared/src/types/custom";
import { RoomState, UserDto } from "@dapp/shared/src/types/openApiGen";

import Display from "./displays/Display";

import { CHAT_MATCH_ID_QUERY_PARAM } from "~/lib/consts";
import {
  getRoomById,
  updateActiveRoomStatePartially,
} from "~/lib/state/room/roomSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import isTruthy from "~/lib/utils/truthy";
import { RoomsWebRTCHandler } from "~/lib/utils/webrtc/RoomsWebRTCHandler";

export interface PeerItem {
  peerID: string;
  peer: RTCPeerConnection;
  user: UserDto;
}

const Room = ({ roomId }: { roomId: string }) => {
  const localVideoRef = useRef<HTMLVideoElement>(null);
  const localAudioRef = useRef<HTMLAudioElement>(null);
  const webRTCHandler = useRef<RoomsWebRTCHandler | null>(null);
  const [peers, setPeers] = useState<PeerItem[]>([]);

  const { activeRoom } = useSelector((state: RootState) => state.room);
  const { user } = useSelector((state: RootState) => state.user);
  const dispatch = useDispatch<AppDispatch>();
  const toast = useToast();
  const router = useRouter();
  const isRoomOwner = user && user.id === activeRoom?.user?.id;

  useEffect(() => {
    dispatch(getRoomById(roomId));
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

  const onFetchUserMediaError = useCallback(
    (error: any) => {
      console.error("Failed to fetch user media", error);
      const message =
        "Failed to fetch user media. Make sure to give access to your camera and/or mic.";
      toast({
        title: error.message || message,
        status: "error",
        isClosable: true,
      });
    },
    [toast]
  );

  const onServerError = useCallback(
    (e: socketEventTypes.EmitErrorPayload) => {
      const message = "An error has occured";
      if (e.action === "JOIN" && isTruthy(e.status)) {
        toast({
          title: e.message || message,
          status: "error",
          isClosable: true,
        });
        router.push("/");
      } else {
        toast({
          title: message,
          status: "error",
          isClosable: true,
        });
      }
    },
    [router, toast]
  );

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

  const onPeersChanged = useCallback((peers: PeerItem[]) => {
    setPeers([...peers]);
  }, []);

  const onNewMatch = useCallback(
    (payload: socketEventTypes.AddNewMatchPayload) => {
      router.push(`/chat?${CHAT_MATCH_ID_QUERY_PARAM}=${payload.matchId}`);
    },
    [router]
  );

  useEffect(() => {
    if (user && activeRoom?.user) {
      webRTCHandler.current = new RoomsWebRTCHandler(
        roomId,
        {
          onRoundPaused,
          onRoundResumed,
          onRoundSkiped,
          onRoundsEnded,
          onRoundsStarted,
          onGoToNextQuestion,
          onTimerUpdated,
          onPeersChanged,
          onRoomStateReceived,
          onServerError,
          onFetchUserMediaError,
          onNewMatch,
        },
        { roomOwner: !!isRoomOwner }
      );

      try {
        webRTCHandler.current.init(localVideoRef, localAudioRef);
      } catch (e) {
        console.log("Error occured initializing the webrtc handler", e);
      }
    }

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
    onServerError,
    onFetchUserMediaError,
    onPeersChanged,
    onNewMatch,
    roomId,
    isRoomOwner,
    user,
    activeRoom?.user,
  ]);

  return (
    <Box height="100%">
      <Display
        localAudioRef={localAudioRef}
        localVideoRef={localVideoRef}
        peers={peers}
      />
    </Box>
  );
};

export default Room;
