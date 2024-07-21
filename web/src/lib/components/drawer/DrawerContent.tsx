import {
  List,
  ListItem,
  ListIcon,
  Link,
  Avatar,
  Box,
  Stack,
  Heading,
  useColorModeValue,
  useColorMode,
} from '@chakra-ui/react';
import { RiCalendarScheduleLine } from 'react-icons/ri';
import { MdOutlineLiveTv } from 'react-icons/md';
import { GrSchedulePlay } from 'react-icons/gr';
import { BsEmojiHeartEyes } from 'react-icons/bs';
import { BsChatDots } from 'react-icons/bs';

const DrawerContent = () => {
  const bgColor = useColorModeValue('whiteAlpha.900', 'gray.700');
  const headingColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const linkColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const hoverColor = useColorModeValue('pink.500', 'pink.300');
  const iconColor = useColorModeValue('pink.400', 'pink.200');

  return (
    <Box bg={bgColor} p={6} borderRadius="lg" boxShadow="xl">
      <Stack spacing={6} align="center" mb={6}>
        <Heading fontSize="2xl" color={headingColor}>
          Menu
        </Heading>
      </Stack>
      <List fontSize="1.2em" spacing={4} color={linkColor}>
        <ListItem>
          <Link
            href="create"
            _hover={{ textDecoration: 'none', color: hoverColor }}
          >
            <ListIcon as={RiCalendarScheduleLine} color={iconColor} />
            Upcoming events
          </Link>
        </ListItem>
        <ListItem>
          <Link
            href="create"
            _hover={{ textDecoration: 'none', color: hoverColor }}
          >
            <ListIcon as={MdOutlineLiveTv} color={iconColor} />
            Live events
          </Link>
        </ListItem>
        <ListItem>
          <Link href="/" _hover={{ textDecoration: 'none', color: hoverColor }}>
            <ListIcon as={GrSchedulePlay} color={iconColor} />
            Schedule an event
          </Link>
        </ListItem>
        <ListItem>
          <Link href="/" _hover={{ textDecoration: 'none', color: hoverColor }}>
            <ListIcon as={BsEmojiHeartEyes} color={iconColor} />
            Matches
          </Link>
        </ListItem>
        <ListItem>
          <Link href="/" _hover={{ textDecoration: 'none', color: hoverColor }}>
            <ListIcon as={BsChatDots} color={iconColor} />
            Chat
          </Link>
        </ListItem>
        <ListItem>
          <Link
            href="profile"
            display="flex"
            alignItems="center"
            _hover={{ textDecoration: 'none', color: hoverColor }}
          >
            <Avatar
              size={'xs'}
              name="mario"
              backgroundColor="pink.500"
              color={'white'}
              cursor={'pointer'}
              mr="20px"
            />
            Profile
          </Link>
        </ListItem>
      </List>
    </Box>
  );
};

export default DrawerContent;
