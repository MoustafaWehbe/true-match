"use client";

import React from "react";
import {
  Button,
  Modal,
  ModalBody,
  ModalCloseButton,
  ModalContent,
  ModalFooter,
  ModalHeader,
  ModalOverlay,
} from "@chakra-ui/react";

import RoomContent from "./RoomContent";

type Props = {
  isModalOpen: boolean;
  setIsModalOpen: (isModalOpen: boolean) => void;
};

const ContentModal = ({ isModalOpen, setIsModalOpen }: Props) => {
  return (
    <Modal isOpen={isModalOpen} onClose={() => setIsModalOpen(false)}>
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>Room Content</ModalHeader>
        <ModalCloseButton />
        <ModalBody>
          <RoomContent />
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
