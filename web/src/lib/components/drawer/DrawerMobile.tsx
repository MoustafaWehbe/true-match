"use client";

import { type PropsWithChildren, useRef } from "react";
import { HamburgerIcon } from "@chakra-ui/icons";
import {
  Box,
  Drawer,
  DrawerBody,
  DrawerCloseButton,
  DrawerContent,
  IconButton,
  useDisclosure,
} from "@chakra-ui/react";

import Content from "./DrawerContent";

function DrawerMobile({ children, ...rest }: PropsWithChildren) {
  const { onClose, isOpen, onOpen } = useDisclosure();
  const btnRef = useRef<any>();

  return (
    <Box position={"absolute"}>
      <IconButton
        ref={btnRef}
        aria-label="Add to friends"
        icon={<HamburgerIcon />}
        onClick={onOpen}
        variant="ghost"
      />

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
    </Box>
  );
}

export default DrawerMobile;
