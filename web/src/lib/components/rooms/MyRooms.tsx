'use client';

import {
  Box,
  Grid,
  Heading,
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
      <Grid
        templateColumns={{
          base: 'repeat(1, 1fr)', // For screens less than 48em (768px)
          md: 'repeat(2, 1fr)', // For screens between 48em (768px) and 74em (1184px)
          lg: 'repeat(3, 1fr)', // For screens larger than 74em (1184px)
        }}
        gap={8}
        mt={8}
      >
        {' '}
        {user?.rooms?.map((room) => <RoomCard key={room.id} room={room} />)}
      </Grid>
    </Box>
  );
}

export default MyRooms;
