import { Box, Flex } from '@chakra-ui/react';

const Home = () => {
  return (
    <Box>
      <Flex
        direction="column"
        alignItems="center"
        justifyContent="center"
        minHeight="70vh"
        gap={4}
        mb={8}
        w="full"
      ></Flex>
    </Box>
  );
};

export default Home;
