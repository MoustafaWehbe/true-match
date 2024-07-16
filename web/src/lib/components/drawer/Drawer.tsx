'use client';

import type { PropsWithChildren } from 'react';
import {
  Drawer,
  DrawerBody,
  DrawerFooter,
  DrawerHeader,
  DrawerContent,
  Button,
  Input,
  useDisclosure,
} from '@chakra-ui/react';
import Content from './DrawerContent';

function DrawerExample({ children, ...rest }: PropsWithChildren) {
  const { onClose } = useDisclosure();

  return (
    <Drawer
      {...rest}
      isOpen={true}
      placement="left"
      onClose={onClose}
      blockScrollOnMount={false}
      autoFocus={false}
      closeOnEsc={false}
      lockFocusAcrossFrames={false}
    >
      <DrawerContent motionProps={{ transition: { duration: 0 } }}>
        <Content />
      </DrawerContent>
    </Drawer>
  );
}

export default DrawerExample;
