'use client';

import {
  Box,
  Heading,
  SimpleGrid,
  Stack,
  Text,
  useColorModeValue,
} from '@chakra-ui/react';
import RoomCard from './RoomCard';
import { useSelector } from 'react-redux';
import { RootState } from '~/lib/state/store';

function MyRooms() {
  const bg = useColorModeValue('gray.50', 'gray.800');
  const textColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const { user } = useSelector((state: RootState) => state.user);

  return (
    <Box bg={bg} color={textColor} px={8} py={4} borderRadius="lg">
      <Stack spacing={4} align="center">
        <Heading fontSize="4xl">My Rooms</Heading>
        <Text fontSize="lg">
          Join us for these exciting live rooms happening soon!
        </Text>
      </Stack>
      <SimpleGrid columns={{ base: 1, sm: 2, md: 3 }} spacing={8} mt={8}>
        {user?.rooms?.map((room) => <RoomCard key={room.id} room={room} />)}
      </SimpleGrid>
    </Box>
  );
}

export default MyRooms;
