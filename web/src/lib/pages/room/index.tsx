import { Box, Heading } from '@chakra-ui/react';
import Room from '~/lib/components/rooms/Room';

const RoomPage = (props: {
  params: { [key: string]: string };
  search: Object;
}) => {
  const id = props.params['id'];

  return <Room roomId={id as string} />;
};

export default RoomPage;
