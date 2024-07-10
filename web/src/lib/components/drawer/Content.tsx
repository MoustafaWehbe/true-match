import { List, ListItem, ListIcon, Link, Box, Avatar } from '@chakra-ui/react';
import { CalendarIcon, EditIcon, AtSignIcon } from '@chakra-ui/icons';
import { RiCalendarScheduleLine } from 'react-icons/ri';
import { MdOutlineLiveTv } from 'react-icons/md';
import { GrSchedulePlay } from 'react-icons/gr';
import { BsEmojiHeartEyes } from 'react-icons/bs';
import { BsChatDots } from 'react-icons/bs';

const Content = () => {
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

export default Content;

// introduction
// system question with timing
// users question
