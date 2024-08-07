'use client';

import {
  Box,
  Heading,
  SimpleGrid,
  Stack,
  Text,
  useColorModeValue,
} from '@chakra-ui/react';
import { useEffect, useState } from 'react';
import RoomCard from './RoomCard';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '~/lib/state/store';
import { getRooms } from '~/lib/state/room/roomSlice';

function LiveRooms() {
  const bg = useColorModeValue('gray.50', 'gray.800');
  const textColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const dispatch = useDispatch<AppDispatch>();
  const { rooms, getRoomsLoading } = useSelector(
    (state: RootState) => state.room
  );

  useEffect(() => {
    dispatch(
      getRooms({
        PageNumber: 1,
        PageSize: 10,
        Status: 1,
      })
    );
  }, [dispatch]);

  return (
    <Box bg={bg} color={textColor} px={8} py={4} borderRadius="lg">
      <Stack spacing={4} align="center">
        <Heading fontSize="4xl">Live Rooms</Heading>
        <Text fontSize="lg">
          Join us for these exciting live rooms happening soon!
        </Text>
      </Stack>
      <SimpleGrid columns={{ base: 1, sm: 2, md: 3 }} spacing={8} mt={8}>
        {rooms?.data?.map((room) => <RoomCard key={room.id} room={room} />)}
      </SimpleGrid>
    </Box>
  );
}

export default LiveRooms;
