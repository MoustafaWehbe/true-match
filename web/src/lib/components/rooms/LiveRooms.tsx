'use client';

import {
  Box,
  Container,
  Heading,
  SimpleGrid,
  Stack,
  Text,
  useColorModeValue,
} from '@chakra-ui/react';
import { useEffect, useState } from 'react';
import RoomCard from './RoomCard';

// Mock data fetching function
const fetchLiveRooms = async () => {
  return [
    {
      id: 1,
      title: 'Live Room 1',
      description: 'Join us for an exciting live room!',
      date: '2024-08-01',
      time: '18:00',
      imageUrl: 'https://via.placeholder.com/150',
    },
    {
      id: 2,
      title: 'Live Room 2',
      description: "Don't miss out on this amazing room!",
      date: '2024-08-05',
      time: '20:00',
      imageUrl: 'https://via.placeholder.com/150',
    },
  ];
};

function LiveRooms() {
  const [rooms, setRooms] = useState<any>([]);
  const bg = useColorModeValue('gray.50', 'gray.800');
  const textColor = useColorModeValue('gray.800', 'whiteAlpha.900');

  useEffect(() => {
    const getRooms = async () => {
      const liveRooms = await fetchLiveRooms();
      setRooms(liveRooms);
    };
    getRooms();
  }, []);

  return (
    <Box bg={bg} color={textColor} p={8} borderRadius="lg" boxShadow="xl">
      <Stack spacing={4} align="center">
        <Heading fontSize="4xl">Live Rooms</Heading>
        <Text fontSize="lg">
          Join us for these exciting live rooms happening soon!
        </Text>
      </Stack>
      <SimpleGrid columns={{ base: 1, md: 2 }} spacing={8} mt={8}>
        {rooms.map((event: any) => (
          <RoomCard key={event.id} event={event} />
        ))}
      </SimpleGrid>
    </Box>
  );
}

export default LiveRooms;
