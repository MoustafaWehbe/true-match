"use client";

import React, { useEffect } from "react";
import { MdCheckCircle } from "react-icons/md";
import { useDispatch, useSelector } from "react-redux";
import {
  Button,
  List,
  ListIcon,
  ListItem,
  Modal,
  ModalBody,
  ModalCloseButton,
  ModalContent,
  ModalFooter,
  ModalHeader,
  ModalOverlay,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";

import { getRoomContent } from "~/lib/state/room/roomSlice";
import { AppDispatch, RootState } from "~/lib/state/store";

type Props = {
  isModalOpen: boolean;
  setIsModalOpen: (isModalOpen: boolean) => void;
};

const ContentModal = ({ isModalOpen, setIsModalOpen }: Props) => {
  const dispatch = useDispatch<AppDispatch>();
  const { roomContent } = useSelector((state: RootState) => state.room);
  const listItemBgColor = useColorModeValue("gray.100", "gray.600");

  useEffect(() => {
    dispatch(getRoomContent());
  }, [dispatch]);

  return (
    <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)}>
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>Room Content</ModalHeader>
        <ModalCloseButton />
        <ModalBody>
          <List spacing={3}>
            {roomContent?.map((content) => (
              <ListItem
                key={content.id}
                p={4}
                borderRadius="md"
                bg={listItemBgColor}
              >
                <ListIcon as={MdCheckCircle} color="green.500" />
                <Text fontSize="lg" fontWeight="bold">
                  {content.title}
                </Text>
                <Text>{content.description}</Text>
                <Text fontSize="sm" color="gray.500">
                  Duration: {Math.floor((content.duration || 0) / 60)} mins{" "}
                  {(content.duration || 0) % 60} secs
                </Text>
              </ListItem>
            ))}
          </List>
        </ModalBody>
        <ModalFooter>
          <Button colorScheme="pink" onClick={() => setIsModalOpen(false)}>
            Close
          </Button>
        </ModalFooter>
      </ModalContent>
    </Modal>
  );
};

export default ContentModal;
