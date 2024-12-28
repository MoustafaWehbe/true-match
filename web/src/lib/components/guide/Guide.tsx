"use client";

import { Box, Heading, useColorModeValue, VStack } from "@chakra-ui/react";

import RoomContent from "../rooms/RoomContent";

const GuidePage = () => {
  const textColor = useColorModeValue("gray.800", "white");
  const sectionBgColor = useColorModeValue("white", "gray.700");

  return (
    <Box
      w="full"
      maxW="lg"
      mx="auto"
      mt={8}
      p={6}
      borderWidth="1px"
      borderRadius="lg"
      overflow="hidden"
      bg={sectionBgColor}
      shadow="md"
    >
      <VStack align="stretch" spacing={6} mb={4}>
        <Heading size="lg" color={textColor}>
          Room Guide
        </Heading>
        <hr style={{ width: "100%", margin: "0 auto" }} />
      </VStack>
      <RoomContent />
    </Box>
  );
};

export default GuidePage;
