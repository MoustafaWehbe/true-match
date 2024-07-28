import {
  Box,
  Button,
  Image,
  Stack,
  Text,
  useColorModeValue,
} from '@chakra-ui/react';
import { CalendarIcon, TimeIcon } from '@chakra-ui/icons';
import { useState } from 'react';
import { socket } from '~/lib/utils/socket/socket';

const RoomCard = ({ event }: { event: any }) => {
  const cardBg = useColorModeValue('white', 'gray.700');
  const cardTextColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const [isConnected, setIsConnected] = useState(socket.connected);

  console.log(isConnected);

  const join = () => {
    socket.connect();
  };

  return (
    <Box
      bg={cardBg}
      color={cardTextColor}
      borderRadius="lg"
      boxShadow="lg"
      overflow="hidden"
      transition="transform 0.2s"
      _hover={{ transform: 'scale(1.05)' }}
    >
      <Image src={event.imageUrl} alt={event.title} />
      <Box p={6}>
        <Stack spacing={4}>
          <Text fontWeight="bold" fontSize="2xl">
            {event.title}
          </Text>
          <Text>{event.description}</Text>
          <Stack direction="row" align="center">
            <CalendarIcon />
            <Text>{event.date}</Text>
          </Stack>
          <Stack direction="row" align="center">
            <TimeIcon />
            <Text>{event.time}</Text>
          </Stack>
          <Button colorScheme="pink" variant="outline" mt={4} onClick={join}>
            Join Room
          </Button>
        </Stack>
      </Box>
    </Box>
  );
};

export default RoomCard;
