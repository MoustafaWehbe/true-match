import { keyframes } from "@chakra-ui/react";

export const glowingAnimation = (color) => keyframes`
0% { box-shadow: 0 0 10px ${color}; }
50% { box-shadow: 0 0 20px ${color}; }
100% { box-shadow: 0 0 10px ${color}; }
`;
