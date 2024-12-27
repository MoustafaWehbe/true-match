import { Box, Flex, Text } from "@chakra-ui/react";

const WatcherWaiting = () => {
  return (
    <Box
      id="peer-container"
      height="100%"
      overflowY="auto"
      width="100%"
      display={"flex"}
      justifyContent={"center"}
      alignItems={"center"}
    >
      <Flex
        direction="column"
        align="center"
        justify="center"
        height="100%"
        gap={6}
      >
        <Text fontSize="xl">It’s just you here, enjoy!</Text>
      </Flex>
    </Box>
  );
};

export default WatcherWaiting;
