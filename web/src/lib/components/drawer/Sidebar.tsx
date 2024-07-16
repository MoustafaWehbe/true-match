'use client';

import { Box } from '@chakra-ui/react';

import Content from './DrawerContent';

export default function Sidebar() {
  return (
    <Box p="5" boxShadow="rgba(0, 0, 0, 0.12) 0px 1px 1px">
      <Content />
    </Box>
  );
}
