import React, { useCallback, useMemo, useState } from "react";
import { useSelector } from "react-redux";
import {
  Box,
  Flex,
  Text,
  useColorModeValue,
  Wrap,
  WrapItem,
} from "@chakra-ui/react";

import { SOCKET_EVENTS } from "@truematch/shared/src/consts/socketEvents";
import { socketEventTypes } from "@truematch/shared/src/types/custom";

import PreviewProfileModal from "../../profile/Preview/PreviewProfileModal";
import ConfirmDialog from "../../shared/ConfirmDialog";
import PeerAudio from "../PeerAudio";
import PeerVideo from "../PeerVideo";
import { PeerItem } from "../Room";

import FinalRound from "./FinalRound";
import MyAudio from "./MyAudio";
import MyVideo from "./MyVideo";
import PickingRound from "./PickingRound";
import PresenterWaiting from "./PresenterWaiting";
import RoomControls from "./RoomControls";
import RoundPlayground from "./RoundPlayground";
import StartRound from "./StartRound";
import UserCard from "./UserCard";
import WatcherWaiting from "./WatcherWaiting";

import useRound from "~/lib/hooks/useRound";
import { RootState } from "~/lib/state/store";
import { colorPalette } from "~/lib/utils/colors/colors";
import { roomSocket as socket } from "~/lib/utils/socket/socket";
import isTruthy from "~/lib/utils/truthy";

interface DisplayProps {
  peers: PeerItem[];
  localAudioRef: React.RefObject<HTMLAudioElement>;
  localVideoRef: React.RefObject<HTMLVideoElement>;
}
const Display = ({ peers, localVideoRef, localAudioRef }: DisplayProps) => {
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const [isMicOn, setIsMicOn] = useState(true);
  const [isVideoOn, setIsVideoOn] = useState(true);
  const { activeRoom } = useSelector((state: RootState) => state.room);
  const { user } = useSelector((state: RootState) => state.user);
  const [previewProfileModalUserId, setPreviewProfileModalUserId] =
    useState<string>();

  const [userToBeRemoved, setUserToBeRemoved] = useState<string>();

  const isOwner = activeRoom?.user?.id === user?.id;

  const {
    rounds,
    skipCurrentRound,
    pauseCurrentRound,
    startRounds,
    resumeCurrentRound,
    nextQuestionClicked,
  } = useRound();

  const colorForUserId = useMemo(() => {
    const uniqueColors = [...colorPalette];
    return peers.reduce((prev, cur, index) => {
      if (cur.user.id) {
        prev[cur.user.id] = uniqueColors[index % uniqueColors.length];
      }
      return prev;
    }, {});
  }, [peers]);

  const onToggleMic = useCallback(() => {
    const ref = isOwner ? localVideoRef.current : localAudioRef.current;
    if (ref) {
      const stream = ref.srcObject as MediaStream | null;
      stream?.getAudioTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsMicOn((prev) => !prev);
    }
  }, [isOwner, localAudioRef, localVideoRef]);

  const onToggleVideo = useCallback(() => {
    if (localVideoRef.current) {
      const stream = localVideoRef.current.srcObject as MediaStream | null;
      stream?.getVideoTracks().forEach((track) => {
        track.enabled = !track.enabled;
      });
      setIsVideoOn((prev) => !prev);
    }
  }, [localVideoRef]);

  const thePresenter = useMemo(
    () => peers.find((peer) => peer.user.id === activeRoom?.user?.id),
    [activeRoom?.user?.id, peers]
  );

  const peersFiltered = useMemo(() => {
    if (isOwner) {
      return peers;
    } else {
      return peers.filter((peer) => peer.user.id !== activeRoom?.user?.id);
    }
  }, [activeRoom?.user?.id, isOwner, peers]);

  const renderVideo = () => {
    if (isOwner) {
      return <MyVideo localVideoRef={localVideoRef} />;
    } else {
      if (thePresenter && activeRoom?.roomState?.currentRound !== 5) {
        return (
          <PeerVideo peer={thePresenter?.peer} user={thePresenter?.user} />
        );
      } else {
        return (
          <Text
            fontSize="lg"
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
            The presenter is on their way &#128525;
          </Text>
        );
      }
    }
  };

  const onUserCardClicked = (userId?: string | null) => {
    if (userId) {
      setPreviewProfileModalUserId(userId);
    }
  };

  const onRemoveUser = (userId?: string | null) => {
    if (userId) {
      setUserToBeRemoved(userId);
    }
  };

  const removeTheUser = (userId?: string) => {
    if (activeRoom?.id && userId) {
      const p = peers.find((p) => p.user.id === userId);

      socket.emit(SOCKET_EVENTS.CLIENT.REMOVE_USER, {
        socketIdToRemove: p?.peerID,
        roomId: activeRoom.id,
      } as socketEventTypes.RemoveUserPayload);
    }

    setUserToBeRemoved(undefined);
  };

  const handleClosePreviewProfileModal = () => {
    setPreviewProfileModalUserId(undefined);
  };

  const usersFromPeers = useMemo(() => peers.map((p) => p.user), [peers]);

  if (!rounds) {
    return null;
  }

  return (
    <Box
      height={"100%"}
      mx={{ base: "10px" }}
      position={"relative"}
      display={"flex"}
      justifyContent={"space-between"}
      flexDirection={"column"}
    >
      <Flex
        flexDir={{ base: "column", md: "row" }}
        justifyContent={"center"}
        gap={8}
        minHeight="200px"
        pt={2}
      >
        <Flex
          color={cardTextColor}
          justify={"center"}
          align={"center"}
          alignItems={"center"}
          position={"relative"}
          width={{ base: "220px", md: "340px" }}
        >
          {renderVideo()}
        </Flex>
        <Box
          height={{ base: "170px", md: "200px" }}
          transition="height 0.3s ease-in-out"
          backgroundColor="gray.800"
          borderRadius="20px"
          boxShadow="0 4px 12px rgba(0, 0, 0, 0.1)"
          overflow="auto"
          width={{ base: "100%" }}
        >
          {peersFiltered?.length === 0 && isOwner ? (
            <PresenterWaiting />
          ) : (
            <Wrap
              gap={{ base: 2, md: 6 }}
              alignContent={"start"}
              padding={2}
              overflowY={"auto"}
            >
              {!isOwner && (
                <WrapItem
                  position={"relative"}
                  display={"flex"}
                  justifyContent={"center"}
                  alignItems={"center"}
                  maxWidth={"200px"}
                  p={2}
                  shadow="sm"
                  rounded="md"
                >
                  <MyAudio localAudioRef={localAudioRef} />
                </WrapItem>
              )}
              {peersFiltered?.map((peer, index) => (
                <WrapItem
                  key={index}
                  position={"relative"}
                  display={"flex"}
                  justifyContent={"center"}
                  alignItems={"center"}
                  maxWidth={"200px"}
                  p={2}
                  shadow="sm"
                  rounded="md"
                >
                  <UserCard
                    color={colorForUserId[peer.user.id!]}
                    user={peer.user}
                    isMe={false}
                    onUserCardClicked={onUserCardClicked}
                    onRemoveUser={onRemoveUser}
                    isOwner={user?.id === activeRoom?.user?.id}
                  />
                  <PeerAudio peer={peer.peer} />
                </WrapItem>
              ))}
            </Wrap>
          )}
        </Box>
      </Flex>

      {/* Rounds section */}
      <Flex
        width={"100%"}
        p={4}
        color={cardTextColor}
        borderRadius="10px"
        position={"relative"}
        mb={{ base: "20px", lg: "0" }}
        alignItems={"center"}
        justify={"center"}
        gap={8}
      >
        {/* <Image
          src="/images/in-a-date.jpg"
          alt="In a date"
          boxSize="250px"
          objectFit="cover"
          rounded={"50%"}
          position={"absolute"}
          left={0}
          top="50%"
          transform={"translateY(-50%)"}
        /> */}
        {isTruthy(activeRoom?.roomState?.currentRound) && (
          <Flex
            height={"100%"}
            direction={"column"}
            justifyContent={"center"}
            gap={4}
            maxWidth={{ base: "95vw", md: "95vw" }}
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
              isOwner={isOwner}
            />
          </Flex>
        )}
        {!isTruthy(activeRoom?.roomState?.currentRound) && isOwner ? (
          <StartRound
            startRounds={startRounds}
            isDisabled={peers.length === 0}
          />
        ) : null}
        {!isTruthy(activeRoom?.roomState?.currentRound) && !isOwner ? (
          <WatcherWaiting />
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
        isRoomOwner={activeRoom?.user?.id === user?.id}
        peersCount={peers.length}
      />
      {previewProfileModalUserId && (
        <PreviewProfileModal
          isOpen={!!previewProfileModalUserId}
          onClose={handleClosePreviewProfileModal}
          userId={previewProfileModalUserId}
        />
      )}
      <ConfirmDialog
        isOpen={!!userToBeRemoved}
        onClose={() => setUserToBeRemoved(undefined)}
        onConfirm={() => removeTheUser(userToBeRemoved)}
        title="Remove user from room?"
        description="Are you sure you want to remove this user from the room?"
        confirmText="Remove"
        cancelText="Cancel"
      />
      {peers.length > 2 && activeRoom?.roomState?.currentRound === 4 && (
        <PickingRound
          users={usersFromPeers}
          onRemoveUser={(userId) => removeTheUser(userId)}
          isOwner={isOwner}
        />
      )}
      {activeRoom?.roomState?.currentRound === 5 && peers.length > 0 && (
        <FinalRound
          users={usersFromPeers}
          isOwner={isOwner}
          thePresenter={thePresenter}
        />
      )}
    </Box>
  );
};

export default Display;
