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
} from '@chakra-ui/react';
import { RiCalendarScheduleLine } from 'react-icons/ri';
import { MdOutlineLiveTv } from 'react-icons/md';
import { GrSchedulePlay } from 'react-icons/gr';
import { BsEmojiHeartEyes } from 'react-icons/bs';
import { BsChatDots } from 'react-icons/bs';
import NextLink from 'next/link';

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
          <NextLink href="/upcoming-rooms" passHref>
            <Link _hover={{ textDecoration: 'none', color: hoverColor }}>
              <ListIcon as={RiCalendarScheduleLine} color={iconColor} />
              Upcoming rooms
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/live-rooms" passHref>
            <Link _hover={{ textDecoration: 'none', color: hoverColor }}>
              <ListIcon as={MdOutlineLiveTv} color={iconColor} />
              Live rooms
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/schedule-room" passHref>
            <Link _hover={{ textDecoration: 'none', color: hoverColor }}>
              <ListIcon as={GrSchedulePlay} color={iconColor} />
              Schedule an room
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/matches" passHref>
            <Link _hover={{ textDecoration: 'none', color: hoverColor }}>
              <ListIcon as={BsEmojiHeartEyes} color={iconColor} />
              Matches
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/chat" passHref>
            <Link _hover={{ textDecoration: 'none', color: hoverColor }}>
              <ListIcon as={BsChatDots} color={iconColor} />
              Chat
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/profile" passHref>
            <Link
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
          </NextLink>
        </ListItem>
      </List>
    </Box>
  );
};

export default DrawerContent;
