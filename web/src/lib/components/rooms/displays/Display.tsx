import React, { useCallback, useMemo, useState } from "react";
import { useSelector } from "react-redux";
import {
  Box,
  Flex,
  Text,
  useColorModeValue,
  useMediaQuery,
  Wrap,
  WrapItem,
} from "@chakra-ui/react";

import { SOCKET_EVENTS } from "@dapp/shared/src/consts/socketEvents";
import { socketEventTypes } from "@dapp/shared/src/types/custom";

import PreviewProfileModal from "../../profile/Preview/PreviewProfileModal";
import ConfirmDialog from "../../shared/ConfirmDialog";
import PeerAudio from "../PeerAudio";
import PeerVideo from "../PeerVideo";
import { PeerItem } from "../Room";

import MyAudio from "./MyAudio";
import MyVideo from "./MyVideo";
import PresenterWaiting from "./PresenterWaiting";
import RoomControls from "./RoomControls";
import RoundPlayground from "./RoundPlayground";
import StartRound from "./StartRound";
import Timer from "./Timer";
import UserCard from "./UserCard";

import { size } from "~/lib/consts";
import useRound from "~/lib/hooks/useRound";
import { RootState } from "~/lib/state/store";
import { colorPalette } from "~/lib/utils/colors/colors";
import { socket } from "~/lib/utils/socket/socket";
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

  const [isLaptopOrDesktop] = useMediaQuery(`(min-width: ${size.desktop})`);

  const progressCircleThickness = isLaptopOrDesktop ? 5 : 4;
  const progressCircleSize = isLaptopOrDesktop ? 140 : 70;

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
      // return <MyVideo localVideoRef={localVideoRef} />;
      return null;
    } else {
      if (thePresenter) {
        return null;
        // return <PeerVideo peer={thePresenter?.peer} user={thePresenter?.user} />
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

  const removeTheUser = () => {
    if (userToBeRemoved && activeRoom?.id) {
      const p = peers.find((p) => p.user.id === userToBeRemoved);

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

  if (!rounds) {
    return null;
  }

  return (
    <Box height={"100%"} mx={{ base: "10px" }} position={"relative"}>
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
          marginLeft={10}
        >
          {renderVideo()}
        </Flex>
        <Box
          height={{ base: "170px", md: "200px" }}
          transition="height 0.3s ease-in-out"
          backgroundColor="gray.800"
          borderRadius="20px"
          boxShadow="0 4px 12px rgba(0, 0, 0, 0.1)"
          overflow="hidden"
          width={{ base: "100%" }}
        >
          {peersFiltered?.length === 0 && isOwner ? (
            <PresenterWaiting />
          ) : (
            <Wrap
              gap={{ base: 2, md: 6 }}
              alignContent={"start"}
              padding={8}
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
                  marginTop={"30px"}
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
                  marginTop={"30px"}
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
        mt={"10%"}
      >
        {/* <Image
          src="/images/in-a-date.jpg"
          alt="In a date"
          boxSize="250px"
          objectFit="cover"
          rounded={"50%"}
        /> */}
        {isTruthy(activeRoom?.roomState?.currentRound) && (
          <Flex
            height={"100%"}
            direction={"column"}
            justifyContent={"center"}
            gap={4}
            maxWidth={{ base: "95vw", md: "65vw" }}
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
        {!isTruthy(activeRoom?.roomState?.currentRound) && isOwner ? (
          <StartRound
            startRounds={startRounds}
            isDisabled={peers.length === 0}
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
        onConfirm={removeTheUser}
        title="Remove user from room?"
        description="Are you sure you want to remove this user from the room?"
        confirmText="Remove"
        cancelText="Cancel"
      />
    </Box>
  );
};

export default Display;
