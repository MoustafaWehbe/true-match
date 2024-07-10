'use client';

import { Box } from '@chakra-ui/react';

import { LayoutProps } from '.';

const AuthLayout = ({ children }: LayoutProps) => {
  return (
    <Box
      width={'100%'}
      transition="0.5s ease-out"
      height={'100vh'}
      pt="8"
      bgGradient="linear(to-r, pink.400, red.400)"
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
