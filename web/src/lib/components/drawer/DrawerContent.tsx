import { List, ListItem, ListIcon, Link, Box, Avatar } from '@chakra-ui/react';
import { CalendarIcon, EditIcon, AtSignIcon } from '@chakra-ui/icons';
import { RiCalendarScheduleLine } from 'react-icons/ri';
import { MdOutlineLiveTv } from 'react-icons/md';
import { GrSchedulePlay } from 'react-icons/gr';
import { BsEmojiHeartEyes } from 'react-icons/bs';
import { BsChatDots } from 'react-icons/bs';

const DrawerContent = () => {
  return (
    <List fontSize="1.2em" spacing={4}>
      <ListItem>
        <Link href="create">
          <ListIcon as={RiCalendarScheduleLine} />
          Upcoming events
        </Link>
      </ListItem>
      <ListItem>
        <Link href="create">
          <ListIcon as={MdOutlineLiveTv} />
          Live events
        </Link>
      </ListItem>
      <ListItem>
        <Link href="/">
          <ListIcon as={GrSchedulePlay} />
          Schedule an event
        </Link>
      </ListItem>
      <ListItem>
        <Link href="/">
          <ListIcon as={BsEmojiHeartEyes} />
          Matches
        </Link>
      </ListItem>
      <ListItem>
        <Link href="/">
          <ListIcon as={BsChatDots} />
          Chat
        </Link>
      </ListItem>
      <ListItem>
        <Link href="profile">
          <Avatar
            size={'sm'}
            name="mario"
            backgroundColor="teal"
            color={'white'}
            cursor={'pointer'}
            mr="20px"
          />
          Profile
        </Link>
      </ListItem>
    </List>
  );
};

export default DrawerContent;

// introduction
// 2 Fun facts and Hobbies
// system questions with timing
// users question
// the person should ask a question and choose to match with one person from the call

// my weird but true story is...
// the first item on my bucket list is...
// My parents will like you if...
// the key to my heart is...
// My favrotie playlist is...
// A surprising thing about me is...
// If I'm not home, you can find me...
// My biography would probably be called...
// The hottest thing you can do is...
// My go-to Karaoke song is...
// My hidden talent is...
// I can beat you in a game of...
// My dream job is...
// People would describe as...
// My worst midnight snack habit...
// ME: I'm a grown up. Also me:
// If I have 20 mins left to live, I would...
// First date wish list:
// Perks of dating me...
// I want someone who...
// Two truths and a lie
// My weakness is...
// Life's too short to...
