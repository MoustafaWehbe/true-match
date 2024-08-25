import {
  Box,
  Button,
  Image,
  Stack,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
import { useEffect } from "react";
import { motion } from "framer-motion";
import { useRouter } from "next/navigation";
import { useDispatch, useSelector } from "react-redux";
import { CalendarIcon, TimeIcon } from "@chakra-ui/icons";
import { format } from "date-fns";

import { RoomDto } from "shared/src/types/openApiGen";
import { AppDispatch, RootState } from "~/lib/state/store";
import { startRoom } from "~/lib/state/room/roomSlice";
interface RoomCardProps {
  room: RoomDto;
  onJoin?: (roomId: number) => void;
  onInterested?: (roomId: number) => void;
  onUpdate?: (roomId: number) => void;
  onDelete?: (roomId: number) => void;
}

const RoomCard = ({
  room,
  onDelete,
  onInterested,
  onUpdate,
}: RoomCardProps) => {
  const cardBg = useColorModeValue("white", "gray.700");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const currentUser = useSelector((state: RootState) => state.user.user);
  const router = useRouter();

  const isOwner = currentUser && currentUser.id === room?.user?.id;
  const isLive = room.status === "InProgress" && !room.finishedAt;
  const isUpcoming = room.status === "Pending";
  const dispatch = useDispatch<AppDispatch>();
  const { roomStarted } = useSelector((state: RootState) => state.room);

  useEffect(() => {
    if (roomStarted) {
      router.push(`rooms/${room.id}`);
    }
  }, [room.id, roomStarted, router]);

  const onStart = () => {
    const newRoom = { ...room };
    newRoom.status = "InProgress";
    dispatch(startRoom(newRoom));
  };

  return (
    <Box
      bg={cardBg}
      color={cardTextColor}
      borderRadius="lg"
      boxShadow="lg"
      overflow="hidden"
      transition="transform 0.2s"
      _hover={{ transform: "scale(1.05)" }}
      position={"relative"}
    >
      <Image src={"https://via.placeholder.com/150"} alt={room.title || ""} />
      <Box p={6}>
        <Stack spacing={4}>
          <Text fontWeight="bold" fontSize="2xl">
            {room.title}
          </Text>
          <Text>{room.description}</Text>
          <Stack direction="row" align="center">
            <CalendarIcon />
            <Text>
              {format(new Date(room.scheduledAt!), "MMMM do, yyyy h:mm:ss a")}
            </Text>
          </Stack>
          <Stack direction="row" align="center">
            <TimeIcon />
            <Text>{20} mins</Text>
          </Stack>
          {isOwner ? (
            <Stack direction="row" spacing={4} mt={4}>
              <Button
                colorScheme="blue"
                variant="outline"
                onClick={() => onUpdate && onUpdate(room.id!)}
              >
                Edit
              </Button>
              <Button
                colorScheme="red"
                variant="solid"
                onClick={() => onDelete && onDelete(room.id!)}
              >
                Delete
              </Button>
            </Stack>
          ) : (
            <Button
              colorScheme={isLive ? "green" : "pink"}
              variant="outline"
              mt={4}
              onClick={() =>
                isLive
                  ? router.push(`rooms/${room.id}`)
                  : onInterested && onInterested(room.id!)
              }
            >
              {isLive ? "Join Room" : "Interested to Attend"}
            </Button>
          )}
        </Stack>
      </Box>
      {isOwner && isUpcoming && (
        <motion.div
          initial={{ opacity: 0, scale: 0.5 }}
          animate={{ opacity: 1, scale: 1 }}
          transition={{ duration: 0.5, ease: "easeOut" }}
          style={{
            position: "absolute",
            top: "10px",
            right: "10px",
          }}
        >
          <Button
            size="md"
            bgGradient="linear(to-r, teal.500, green.500)"
            color="white"
            _hover={{ bgGradient: "linear(to-r, teal.600, green.600)" }}
            _active={{ bgGradient: "linear(to-r, teal.700, green.700)" }}
            boxShadow="xl"
            onClick={onStart}
          >
            Start Room
          </Button>
        </motion.div>
      )}
    </Box>
  );
};

export default RoomCard;
