"use client";

import { useCallback, useEffect, useMemo, useRef, useState } from "react";
import { FaHeart } from "react-icons/fa";
import { FiMoreVertical } from "react-icons/fi";
import { useDispatch, useSelector } from "react-redux";
import {
  Avatar,
  Box,
  Button,
  Container,
  Fade,
  Heading,
  HStack,
  IconButton,
  Input,
  Popover,
  PopoverArrow,
  PopoverBody,
  PopoverContent,
  PopoverTrigger,
  Text,
  useColorModeValue,
  VStack,
} from "@chakra-ui/react";
import { motion } from "framer-motion";
import { useRouter, useSearchParams } from "next/navigation";

import { SOCKET_EVENTS } from "@truematch/shared/src/consts/socketEvents";
import { socketEventTypes } from "@truematch/shared/src/types/custom";

import MotionBox from "../motion/Box";
import PreviewProfileModal from "../profile/Preview/PreviewProfileModal";
import ConfirmDialog from "../shared/ConfirmDialog";

import { CHAT_MATCH_ID_QUERY_PARAM } from "~/lib/consts";
import {
  clearMessages,
  deleteMatch,
  getMatches,
  getMessages,
  setActiveMatchId,
  updateMessages,
} from "~/lib/state/match/matchSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import { chatSocket as socket } from "~/lib/utils/socket/socket";
import { constructMediaUrl } from "~/lib/utils/url";
import { IndividualChatWebRTCHandler } from "~/lib/utils/webrtc/IndividualChatWebRTCHandler";

const MotionAvatarBox = motion(Box as any);

function Chat() {
  const cardBg = useColorModeValue("white", "gray.700");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const inputBg = useColorModeValue("gray.100", "gray.600");
  const myMessageBg = useColorModeValue("pink.100", "pink.500");
  const userMessageBg = useColorModeValue("gray.200", "gray.600");

  const moreOptionsBgColor = useColorModeValue("whiteAlpha.900", "gray.700");
  const moreOptionsTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const moreOptionsHoverColor = useColorModeValue("pink.500", "pink.300");

  const [input, setInput] = useState<string>("");
  const { matches, activeMatchId, messages, deletingMatch } = useSelector(
    (state: RootState) => state.match
  );
  const { user: me } = useSelector((state: RootState) => state.user);
  const dispatch = useDispatch<AppDispatch>();
  const webRTCHandler = useRef<IndividualChatWebRTCHandler | null>(null);
  const messageContainerRef = useRef<HTMLDivElement>(null);
  const router = useRouter();
  const searchParams = useSearchParams();
  const [previewProfileModalUserId, setPreviewProfileModalUserId] =
    useState<string>();
  const [isDialogOpen, setIsDialogOpen] = useState(false);

  const sendMessage = () => {
    if (input.trim()) {
      const match = matches?.find((m) => m.id === activeMatchId);
      if (match) {
        const user = match.user1?.id === me?.id ? match.user2 : match.user1;
        dispatch(
          updateMessages({
            content: input,
            receiverId: user?.id!,
            senderId: me?.id!,
          })
        );

        setInput("");
        socket.emit(SOCKET_EVENTS.CLIENT.SEND_MESSAGE, {
          receiverId: user?.id,
          content: input,
        } as socketEventTypes.SendMessagePayload);
      }
    }
  };

  const onNewMessage = useCallback(
    (message: socketEventTypes.MessageSentPayload) => {
      dispatch(
        updateMessages({
          content: message.content,
          receiverId: message.receiverId,
          senderId: message.senderId,
        })
      );
    },
    [dispatch]
  );

  useEffect(() => {
    return () => {
      dispatch(setActiveMatchId(null));
    };
  }, [dispatch]);

  useEffect(() => {
    // Scroll to the bottom whenever messages change
    if (messageContainerRef.current) {
      messageContainerRef.current.scrollTop =
        messageContainerRef.current.scrollHeight;
    }
  }, [messages]);

  useEffect(() => {
    webRTCHandler.current = new IndividualChatWebRTCHandler({
      handleSendMessage: onNewMessage,
    });
    webRTCHandler.current.init();

    return () => {
      webRTCHandler.current?.closeConnections();
    };
  }, [onNewMessage]);

  useEffect(() => {
    dispatch(getMatches());
  }, [dispatch]);

  useEffect(() => {
    const matchId = searchParams.get(CHAT_MATCH_ID_QUERY_PARAM);
    if (matchId && matches?.length && me?.id) {
      const match = matches?.find((m) => m.id === matchId);
      if (match) {
        dispatch(setActiveMatchId(matchId));
        const otherPersonId =
          match.user1?.id === me?.id ? match.user2 : match.user1;
        dispatch(
          getMessages({ receiverId: otherPersonId?.id!, senderId: me?.id! })
        );
      }
    }
  }, [searchParams, matches, me, dispatch]);

  const onMatchClick = (matchId: string) => {
    if (activeMatchId === matchId) {
      const updatedSearchParams = new URLSearchParams(searchParams.toString());
      updatedSearchParams.delete(CHAT_MATCH_ID_QUERY_PARAM);
      const newUrl = updatedSearchParams.toString()
        ? `?${updatedSearchParams.toString()}`
        : "/chat";
      router.push(newUrl);

      dispatch(setActiveMatchId(null));
    } else {
      router.push(`?${CHAT_MATCH_ID_QUERY_PARAM}=${matchId}`);
    }
  };

  const matchedUser = useMemo(() => {
    const match = matches?.find((m) => m.id === activeMatchId);
    if (match) {
      const user = match.user1?.id === me?.id ? match.user2 : match.user1;
      return user;
    }
    return null;
  }, [activeMatchId, matches, me?.id]);

  const handleClosePreviewProfileModal = () => {
    setPreviewProfileModalUserId(undefined);
  };

  const viewProfile = useCallback(() => {
    if (matchedUser?.id) {
      setPreviewProfileModalUserId(matchedUser.id);
    }
  }, [matchedUser?.id]);

  const openDeleteDialog = () => setIsDialogOpen(true);
  const closeDeleteDialog = () => setIsDialogOpen(false);

  const handleDelete = async () => {
    if (!activeMatchId) {
      return;
    }
    try {
      await dispatch(deleteMatch(activeMatchId));
      dispatch(clearMessages());
    } catch (error) {
      console.error("Failed to delete room:", error);
    } finally {
      closeDeleteDialog();
    }
  };

  if (!me) {
    return null;
  }

  return (
    <Container maxW="2xl" py={5}>
      <VStack spacing={4} align="stretch">
        <HStack justifyContent="space-between">
          <Heading as="h1" size="md" color="pink.400" fontWeight="bold">
            💕 Matches
          </Heading>
        </HStack>

        {/* Matched Users Scrollable Section */}
        <Box
          display="flex"
          overflowX="auto"
          paddingLeft={"4px"}
          py={2}
          mb={4}
          css={{
            "&::-webkit-scrollbar": { display: "none" },
            "-ms-overflow-style": "none",
            "scrollbar-width": "none",
          }}
        >
          {matches?.map((match) => {
            const user = match.user1?.id === me?.id ? match.user2 : match.user1;

            if (!user) return null;

            const borderColor =
              match.id === activeMatchId
                ? "2px solid rgba(255, 182, 193, 1)"
                : "2px solid rgba(0, 0, 0, 0)";
            return (
              <MotionAvatarBox
                key={match.id}
                onClick={() => onMatchClick(match.id!)}
                cursor="pointer"
                bg={cardBg}
                borderRadius="md"
                boxShadow="md"
                p={2}
                mr={2}
                minW="80px"
                textAlign="center"
                whileHover={{
                  scale: 1.05,
                }}
                transition="all 0.2s"
                style={{
                  transition: "all 0.2s",
                  border: borderColor,
                }}
              >
                <Avatar
                  src={constructMediaUrl(
                    user?.media?.length ? user?.media[0].url : ""
                  )}
                  name={`${user.firstName} ${user.lastName}`}
                  mb={2}
                />
                <Text fontSize="sm" color={cardTextColor}>
                  {user.firstName}
                </Text>
              </MotionAvatarBox>
            );
          })}

          {/* No matches */}
          {!matches?.length &&
            [1].map((index) => {
              return (
                <MotionAvatarBox
                  key={index}
                  cursor="pointer"
                  bg={cardBg}
                  borderRadius="md"
                  boxShadow="md"
                  p={2}
                  mr={2}
                  minW="80px"
                  textAlign="center"
                  whileHover={{
                    scale: 1.05,
                  }}
                  transition="all 0.2s"
                  style={{
                    transition: "all 0.2s",
                    height: "100px",
                    position: "relative",
                    overflow: "hidden",
                    backgroundColor: "#f0f0f0", // Light gray background indicating "no match"
                  }}
                >
                  <div
                    style={{
                      position: "absolute",
                      top: 0,
                      left: 0,
                      width: "100%",
                      height: "100%",
                      background: `radial-gradient(circle, rgba(255, 105, 180, 0.6) 10%, rgba(70, 130, 180, 0.4) 60%, rgba(0, 255, 255, 0.3) 100%)`,
                      opacity: 0.8, // Increased opacity for vividness
                      pointerEvents: "none", // Ensures it's not interactive
                    }}
                  />
                  {/* Placeholder Label Text */}
                  <div
                    style={{
                      position: "absolute",
                      left: "50%",
                      transform: "translate(-50%, -50%)",
                      fontSize: "9px",
                      boxShadow: "2px 2px 4px 0 rgba(225, 18, 18, 0.2)",
                      color: "darkmagenta",
                      fontWeight: "bold",
                      textTransform: "uppercase",
                      top: "50%",
                      width: "100%",
                      padding: "0px 4px",
                    }}
                  >
                    No Matches yet
                  </div>
                </MotionAvatarBox>
              );
            })}
        </Box>

        <HStack width={"100%"}>
          {matchedUser && (
            <Avatar
              src={constructMediaUrl(
                matchedUser.media?.length ? matchedUser.media[0].url : ""
              )}
              name={`${matchedUser.firstName} ${matchedUser.lastName}`}
              mb={2}
              cursor={"pointer"}
              border={"1px solid pink"}
              onClick={viewProfile}
            />
          )}
          <Heading as="h1" size="md" color="pink.400" fontWeight="bold">
            Chat 💕
          </Heading>

          {matchedUser && (
            <Popover trigger="click" placement="bottom">
              <PopoverTrigger>
                <Button
                  as={IconButton}
                  aria-label="Options"
                  icon={<FiMoreVertical />}
                  variant="ghost"
                  bg="transparent"
                  _hover={{ bg: "transparent" }}
                  height={"auto"}
                  width={"fit-content"}
                  padding={0}
                  marginLeft={"auto"}
                />
              </PopoverTrigger>
              <PopoverContent bg={moreOptionsBgColor} width={"auto"}>
                <PopoverArrow />
                <PopoverBody
                  display={"flex"}
                  flexDir={"column"}
                  width={"fit-content"}
                  alignItems={"start"}
                >
                  <Button
                    aria-label="unmatch"
                    variant="link"
                    onClick={openDeleteDialog}
                    color={moreOptionsTextColor}
                    _hover={{ color: moreOptionsHoverColor }}
                    cursor={"pointer"}
                  >
                    Unmatch
                  </Button>
                </PopoverBody>
              </PopoverContent>
            </Popover>
          )}
        </HStack>

        {activeMatchId && (
          <>
            <Box
              bg={cardBg}
              borderRadius="lg"
              boxShadow="lg"
              p={4}
              h="450px"
              overflowY="scroll"
              color={cardTextColor}
              ref={messageContainerRef}
              position={"relative"}
            >
              {messages?.map((msg, idx) => (
                <MotionBox
                  key={idx}
                  initial={{ opacity: 0 }}
                  animate={{ opacity: 1 }}
                  transition={{ duration: 0.4 }}
                  mb={2}
                  alignSelf={
                    msg.senderId === me?.id ? "flex-end" : "flex-start"
                  }
                  bg={msg.senderId === me?.id ? myMessageBg : userMessageBg}
                  borderRadius="md"
                  px={4}
                  py={2}
                  maxW="65%"
                  width="fit-content"
                  color={cardTextColor}
                  textAlign={"left"}
                  marginLeft={msg.senderId === me?.id ? "auto" : "unset"}
                >
                  <Text>{msg.content}</Text>
                </MotionBox>
              ))}
              {messages?.length === 0 && (
                <Text
                  position={"absolute"}
                  top={"50%"}
                  left={"50%"}
                  transform="translate(-50%, -50%)"
                  maxWidth={"70%"}
                  margin={"0 auto"}
                  color="lightgray"
                >
                  <Text textAlign={"center"}>
                    Congratulations on your new match! 🎉
                  </Text>
                  <Text mt="4" textAlign={"center"}>
                    Start chatting now to get to know each other better!
                  </Text>
                </Text>
              )}
            </Box>

            <HStack as={Fade} in={true} spacing={3}>
              <Input
                bg={inputBg}
                placeholder="Type a message..."
                value={input}
                onChange={(e) => setInput(e.target.value)}
                autoFocus
                onKeyPress={(e) => e.key === "Enter" && sendMessage()}
              />
              <IconButton
                icon={<FaHeart />}
                onClick={sendMessage}
                colorScheme="pink"
                color="pink.400"
                variant="outline"
                aria-label="Send love message"
                transition="transform 0.2s"
                _hover={{ transform: "scale(1.1)" }}
              />
            </HStack>
          </>
        )}
        {!activeMatchId && <Text>Select a match to chat with..</Text>}
      </VStack>
      {previewProfileModalUserId && (
        <PreviewProfileModal
          isOpen={!!previewProfileModalUserId}
          onClose={handleClosePreviewProfileModal}
          userId={previewProfileModalUserId}
        />
      )}
      <ConfirmDialog
        isOpen={isDialogOpen}
        onClose={closeDeleteDialog}
        onConfirm={handleDelete}
        title="Remove match?"
        description={`Are you sure you want to remove ${matchedUser?.firstName || "this user"}?`}
        confirmText="Delete"
        cancelText="Cancel"
        isLoading={deletingMatch}
      />
    </Container>
  );
}

export default Chat;
