"use client";

import { useEffect, useState } from "react";
import { FaHeart } from "react-icons/fa";
import {
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

import MotionBox from "../motion/Box";

function Chat() {
  const cardBg = useColorModeValue("white", "gray.700");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const inputBg = useColorModeValue("gray.100", "gray.600");
  const myMessageBg = useColorModeValue("pink.100", "pink.500");
  const userMessageBg = useColorModeValue("gray.200", "gray.600");

  const [messages, setMessages] = useState<
    { text: string; sender: "me" | "user" }[]
  >([]);
  const [input, setInput] = useState<string>("");

  const sendMessage = () => {
    if (input.trim()) {
      setMessages((prev) => [...prev, { text: input, sender: "me" }]);
      setInput("");
    }
  };

  useEffect(() => {
    // Example animation on new message
    const timeout = setTimeout(() => {
      setMessages((prev) => [
        ...prev,
        { text: "I'm glad to meet you!", sender: "user" },
      ]);
    }, 2000);
    return () => clearTimeout(timeout);
  }, []);

  return (
    <Container maxW="2xl" py={5}>
      <VStack spacing={4} align="stretch">
        <HStack justifyContent="space-between">
          <Heading as="h1" size="lg" color="pink.400" fontWeight="bold">
            💕 Chat
          </Heading>
        </HStack>

        <Box
          bg={cardBg}
          borderRadius="lg"
          boxShadow="lg"
          p={4}
          h="450px"
          overflowY="scroll"
          color={cardTextColor}
        >
          {messages.map((msg, idx) => (
            <MotionBox
              key={idx}
              initial={{ opacity: 0 }}
              animate={{ opacity: 1 }}
              transition={{ duration: 0.4 }}
              mb={2}
              alignSelf={msg.sender === "me" ? "flex-end" : "flex-start"}
              bg={msg.sender === "me" ? myMessageBg : userMessageBg}
              borderRadius="md"
              px={4}
              py={2}
              maxW="65%"
              width="fit-content"
              color={cardTextColor}
              textAlign={"left"}
              marginLeft={msg.sender === "me" ? "auto" : "unset"}
            >
              <Text>{msg.text}</Text>
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
      </VStack>
    </Container>
  );
}

export default Chat;
