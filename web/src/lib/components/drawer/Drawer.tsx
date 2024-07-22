'use client';

import { useRef, type PropsWithChildren } from 'react';
import {
  Button,
  Drawer,
  DrawerBody,
  DrawerCloseButton,
  DrawerContent,
  useDisclosure,
} from '@chakra-ui/react';
import Content from './DrawerContent';

function DrawerExample({ children, ...rest }: PropsWithChildren) {
  const { onClose, isOpen, onOpen } = useDisclosure();
  const btnRef = useRef<any>();

  return (
    <>
      <Button ref={btnRef} colorScheme="teal" onClick={onOpen}>
        Open
      </Button>
      <Drawer
        {...rest}
        isOpen={isOpen}
        placement="left"
        onClose={onClose}
        initialFocusRef={btnRef}
      >
        <DrawerContent>
          <DrawerCloseButton />
          <DrawerBody>
            <Content />
          </DrawerBody>
        </DrawerContent>
      </Drawer>
    </>
  );
}

export default DrawerExample;
