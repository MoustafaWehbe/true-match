'use client';

import { Box, useColorModeValue } from '@chakra-ui/react';

import { LayoutProps } from '.';

const AuthLayout = ({ children }: LayoutProps) => {
  const gradientBgLight = 'linear(to-r, pink.400, red.400)';
  const gradientBgDark = 'linear(to-r, gray.700, gray.900)';

  const bgGradient = useColorModeValue(gradientBgLight, gradientBgDark);

  return (
    <Box
      width={'100%'}
      transition="0.5s ease-out"
      height={'100vh'}
      pt="8"
      bgGradient={bgGradient}
      display="flex"
      justifyContent="center"
      alignItems="center"
      overflowY="auto"
    >
      {children}
    </Box>
  );
};

export default AuthLayout;
