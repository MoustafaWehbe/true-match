'use client';

import React, { useEffect } from 'react';

import {
  List,
  ListIcon,
  ListItem,
  Text,
  Modal,
  ModalBody,
  ModalCloseButton,
  ModalContent,
  ModalHeader,
  ModalOverlay,
  ModalFooter,
  Button,
  useColorModeValue,
} from '@chakra-ui/react';
import { MdCheckCircle } from 'react-icons/md';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '~/lib/state/store';
import { getRoomContent } from '~/lib/state/room/roomSlice';

type Props = {
  isModalOpen: boolean;
  setIsModalOpen: (isModalOpen: boolean) => void;
};

const ContentModal = ({ isModalOpen, setIsModalOpen }: Props) => {
  const dispatch = useDispatch<AppDispatch>();
  const { roomContent, roomContentLoading } = useSelector(
    (state: RootState) => state.room
  );

  useEffect(() => {
    if (!roomContent && !roomContentLoading) {
      dispatch(getRoomContent());
    }
  }, []);

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
                bg={useColorModeValue('gray.100', 'gray.600')}
              >
                <ListIcon as={MdCheckCircle} color="green.500" />
                <Text fontSize="lg" fontWeight="bold">
                  {content.title}
                </Text>
                <Text>{content.description}</Text>
                <Text fontSize="sm" color="gray.500">
                  Duration: {Math.floor((content.duration || 0) / 60)} mins{' '}
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
