"use client";

import { useCallback, useEffect, useRef, useState } from "react";
import { FaHeart } from "react-icons/fa";
import { useDispatch, useSelector } from "react-redux";
import {
  Avatar,
  Box,
  Container,
  Fade,
  Heading,
  HStack,
  IconButton,
  Input,
  Text,
  useColorModeValue,
  VStack,
} from "@chakra-ui/react";
import { motion } from "framer-motion";

import { SOCKET_EVENTS } from "@dapp/shared/src/consts/socketEvents";
import { socketEventTypes } from "@dapp/shared/src/types/custom";

import MotionBox from "../motion/Box";

import {
  getMatches,
  getMessages,
  setActiveMatchId,
  updateMessages,
} from "~/lib/state/match/matchSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import { socket } from "~/lib/utils/socket/socket";
import { IndividualChatWebRTCHandler } from "~/lib/utils/webrtc/IndividualChatWebRTCHandler";

const MotionAvatarBox = motion(Box as any);

function Chat() {
  const cardBg = useColorModeValue("white", "gray.700");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const inputBg = useColorModeValue("gray.100", "gray.600");
  const myMessageBg = useColorModeValue("pink.100", "pink.500");
  const userMessageBg = useColorModeValue("gray.200", "gray.600");
  const [input, setInput] = useState<string>("");
  const { matches, activeMatchId, messages } = useSelector(
    (state: RootState) => state.match
  );
  const { user: me } = useSelector((state: RootState) => state.user);
  const dispatch = useDispatch<AppDispatch>();
  const webRTCHandler = useRef<IndividualChatWebRTCHandler | null>(null);
  const messageContainerRef = useRef<HTMLDivElement>(null);

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

  const onMatchClick = (matchId: number) => {
    const match = matches?.find((m) => m.id === matchId);
    if (match) {
      const otherPersonId =
        match.user1?.id === me?.id ? match.user2 : match.user1;
      dispatch(setActiveMatchId(matchId));
      dispatch(
        getMessages({ receiverId: otherPersonId?.id!, senderId: me?.id! })
      );
    }
  };

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
                key={user.id}
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
                <Avatar name={`${user.firstName} ${user.lastName}`} mb={2} />
                <Text fontSize="sm" color={cardTextColor}>
                  {user.firstName}
                </Text>
              </MotionAvatarBox>
            );
          })}
        </Box>

        <HStack justifyContent="space-between">
          <Heading as="h1" size="md" color="pink.400" fontWeight="bold">
            💕 Chat
          </Heading>
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
            </Box>

            <HStack as={Fade} in={true} spacing={3}>
              <Input
                bg={inputBg}
                placeholder="Type a message..."
                value={input}
                onChange={(e) => setInput(e.target.value)}
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
      </VStack>
    </Container>
  );
}

export default Chat;
