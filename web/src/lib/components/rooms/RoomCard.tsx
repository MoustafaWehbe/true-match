import { FaHeart } from "react-icons/fa";
import { LuHeartOff } from "react-icons/lu";
import { MdBlock } from "react-icons/md";
import { useSelector } from "react-redux";
import { CalendarIcon, CloseIcon, TimeIcon } from "@chakra-ui/icons";
import {
  Box,
  Button,
  IconButton,
  Stack,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
import { format } from "date-fns";
import { motion } from "framer-motion";
import { useRouter } from "next/navigation";

import { RoomDto } from "@dapp/shared/src/types/openApiGen";

import CustomTooltip from "../shared/CutsomTooltip";

import DeleteRoomButton from "./DeleteRoomButton";

import { RootState } from "~/lib/state/store";

interface RoomCardProps {
  room: RoomDto;
  isComingUp?: boolean;
  isInProgress?: boolean;
  isArchived?: boolean;
  onJoin?: (roomId: number) => void;
  onUpdate?: (roomId: number) => void;
  onDelete?: (roomId: number) => void;
  handleOnInterested?: (roomId: number) => void;
  handleOnBlock?: (roomId: number) => void;
  handleOnHideRoom?: (roomId: number) => void;
  handleOnNotInterestedAnymore?: (roomId: number) => void;
  onEditClicked?: (room: RoomDto) => void;
  onStartRoom?: (room: RoomDto) => void;
}

const RoomCard = ({
  room,
  isArchived: _isArchived,
  isInProgress,
  isComingUp,
  handleOnInterested,
  handleOnBlock,
  handleOnHideRoom,
  handleOnNotInterestedAnymore,
  onEditClicked,
  onStartRoom,
}: RoomCardProps) => {
  const cardBg = useColorModeValue("white", "gray.700");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const currentUser = useSelector((state: RootState) => state.user.user);
  const {
    isRegistering,
    isdeRegistering,
    ishidingRoom,
    actionPerformedOnRoomId,
  } = useSelector((state: RootState) => state.room);
  const router = useRouter();

  const isOwner = currentUser && currentUser.id === room?.user?.id;

  const onStart = async () => {
    if (onStartRoom) {
      onStartRoom(room);
    }
  };

  return (
    <Box
      bg={cardBg}
      color={cardTextColor}
      borderRadius="lg"
      boxShadow="lg"
      overflow="hidden"
      height={600}
      transition="transform 0.2s"
      _hover={{ transform: "scale(1.05)" }}
      position={"relative"}
      display={"flex"}
      flexDirection={"column"}
    >
      <Box
        height={"50%"}
        bgImage={"url(/images/default-user-image-female.jpg)"}
        bgSize="cover"
        bgPosition="center"
      />
      <Box p={6} flex={8}>
        <Stack spacing={4} justifyContent={"space-between"} height={"100%"}>
          <Text
            fontWeight="bold"
            fontSize="2xl"
            sx={{
              textOverflow: "ellipsis",
              overflow: "hidden",
              lineClamp: "2",
              display: "-webkit-box",
              "-webkit-box-orient": "vertical",
              "-webkit-line-clamp": "1",
            }}
          >
            {room.title}
          </Text>
          <CustomTooltip label={room.description || ""}>
            <Text
              sx={{
                textOverflow: "ellipsis",
                overflow: "hidden",
                lineClamp: "2",
                display: "-webkit-box",
                "-webkit-box-orient": "vertical",
                "-webkit-line-clamp": "1",
                whiteSpace: "nowrap",
              }}
            >
              {room.description}
            </Text>
          </CustomTooltip>
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
                flex={1}
                onClick={() => onEditClicked && onEditClicked(room)}
              >
                Edit
              </Button>
              <DeleteRoomButton roomId={room.id!} />
            </Stack>
          ) : isInProgress ? (
            <Button
              colorScheme="green"
              variant="outline"
              mt={4}
              onClick={() => router.push(`rooms/${room.id}`)}
            >
              Join Room
            </Button>
          ) : (
            <Stack
              direction="row"
              spacing={4}
              mt={4}
              alignItems={"center"}
              justifyContent={"space-between"}
            >
              <CustomTooltip label="Do not show rooms from this person again">
                <IconButton
                  onClick={() => handleOnBlock && handleOnBlock(room.id!)}
                  colorScheme="red"
                  color="red"
                  icon={<MdBlock />}
                  variant="outline"
                  width={"48px"}
                  height={"48px"}
                  aria-label="Block"
                />
              </CustomTooltip>
              <Stack direction={"row"} spacing={4} alignItems={"center"}>
                <CustomTooltip label="Hide this room">
                  <IconButton
                    onClick={() =>
                      handleOnHideRoom && handleOnHideRoom(room.id!)
                    }
                    colorScheme="yellow"
                    color="yellow"
                    icon={<CloseIcon />}
                    variant="outline"
                    width={"48px"}
                    height={"48px"}
                    aria-label="Hide room"
                    isLoading={
                      ishidingRoom && actionPerformedOnRoomId === room.id
                    }
                  />
                </CustomTooltip>
                {room.isParticipanting ? (
                  <CustomTooltip label="Not interested anymore">
                    <IconButton
                      onClick={() =>
                        handleOnNotInterestedAnymore &&
                        handleOnNotInterestedAnymore(room.id!)
                      }
                      colorScheme="pink"
                      color="pink.400"
                      icon={<LuHeartOff />}
                      variant="outline"
                      width={"48px"}
                      height={"48px"}
                      aria-label="Sign me out"
                      isLoading={
                        isdeRegistering && actionPerformedOnRoomId === room.id
                      }
                    />
                  </CustomTooltip>
                ) : (
                  <CustomTooltip label="Interested to attend this room">
                    <IconButton
                      onClick={() =>
                        handleOnInterested && handleOnInterested(room.id!)
                      }
                      colorScheme="pink"
                      color="pink.400"
                      icon={<FaHeart />}
                      variant="outline"
                      width={"48px"}
                      height={"48px"}
                      aria-label="Sign me in"
                      isLoading={
                        isRegistering && actionPerformedOnRoomId === room.id
                      }
                    />
                  </CustomTooltip>
                )}
              </Stack>
            </Stack>
          )}
        </Stack>
      </Box>
      {isOwner && isComingUp && (
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
