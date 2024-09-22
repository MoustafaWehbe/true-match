import { FaHeart } from "react-icons/fa";
import { Box, keyframes } from "@chakra-ui/react";

const heartbeat = keyframes`
  0%, 100% { transform: scale(1); }
  50% { transform: scale(1.3); }
`;

// const animation = `${heartbeat} 1s ease-in-out infinite`;

const AnimatedHeart = () => {
  return (
    <Box
      as={FaHeart}
      size="24px"
      color="red"
      animation={`${heartbeat} 1.5s infinite`}
    />
  );
};

export default AnimatedHeart;
