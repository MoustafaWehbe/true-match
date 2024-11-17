import { useState } from "react";
import { FaHeart } from "react-icons/fa";
import { FiMoreVertical } from "react-icons/fi";
import { IoCloseOutline } from "react-icons/io5";
import { LuHeartOff } from "react-icons/lu";
import { useSelector } from "react-redux";
import { CalendarIcon, TimeIcon } from "@chakra-ui/icons";
import {
  Box,
  Button,
  Flex,
  IconButton,
  Popover,
  PopoverArrow,
  PopoverBody,
  PopoverContent,
  PopoverTrigger,
  Stack,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
import { format } from "date-fns";
import { motion } from "framer-motion";
import { useRouter } from "next/navigation";

import { RoomDto } from "@dapp/shared/src/types/openApiGen";

import PreviewProfileModal from "../profile/Preview/PreviewProfileModal";
import GradientButton from "../shared/buttons/GradientButton";
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
  const [isPreviewProfileModalOpen, setIsPreviewProfileModalOpen] =
    useState(false);

  const isOwner = currentUser && currentUser.id === room?.user?.id;

  const onStart = async () => {
    if (onStartRoom) {
      onStartRoom(room);
    }
  };

  const handleViewProfile = () => {
    setIsPreviewProfileModalOpen(true);
  };

  const handleClosePreviewProfileModal = () => {
    setIsPreviewProfileModalOpen(false);
  };

  const moreOptionsBgColor = useColorModeValue("whiteAlpha.900", "gray.700");
  const moreOptionsTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const moreOptionsHoverColor = useColorModeValue("pink.500", "pink.300");

  return (
    <Box
      role="group"
      bg={cardBg}
      color={cardTextColor}
      borderRadius="lg"
      boxShadow="lg"
      overflow="hidden"
      height={600}
      transition="transform 0.2s"
      _hover={{ transform: "scale(1.05)", cursor: "pointer", opacity: 0.9 }}
      position={"relative"}
      display={"flex"}
      flexDirection={"column"}
      gap={0}
    >
      <Flex
        direction={"column"}
        paddingTop={2}
        paddingLeft={6}
        paddingBottom={2}
        gap={4}
        background={"linear-gradient(45deg, gray, transparent)"}
      >
        <Flex justifyContent={"space-between"} alignItems={"center"}>
          <Text
            fontWeight="bold"
            fontSize={"medium"}
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
          {!isOwner && (
            <Popover trigger="click" placement="top-end">
              <PopoverTrigger>
                <Button
                  as={IconButton}
                  aria-label="Options"
                  icon={<FiMoreVertical />}
                  variant="ghost"
                  bg="transparent"
                  _hover={{ bg: "transparent" }}
                  height={"auto"}
                  width={"fit-content"}
                  padding={0}
                />
              </PopoverTrigger>
              <PopoverContent bg={moreOptionsBgColor} width={"auto"}>
                <PopoverArrow />
                <PopoverBody
                  display={"flex"}
                  flexDir={"column"}
                  width={"fit-content"}
                  alignItems={"start"}
                >
                  <Button
                    aria-label="view user"
                    variant="link"
                    onClick={handleViewProfile}
                    color={moreOptionsTextColor}
                    _hover={{ color: moreOptionsHoverColor }}
                    cursor={"pointer"}
                    mt="10px"
                  >
                    View profile
                  </Button>
                  <Button
                    aria-label="block user"
                    variant="link"
                    onClick={() => handleOnBlock && handleOnBlock(room.id!)}
                    color={moreOptionsTextColor}
                    _hover={{ color: moreOptionsHoverColor }}
                    cursor={"pointer"}
                    mt="10px"
                  >
                    Block user
                  </Button>
                </PopoverBody>
              </PopoverContent>
            </Popover>
          )}
        </Flex>
        <Text fontSize={"small"} mt={"-10px"}>
          by {room.user?.firstName} {room.user?.lastName}
        </Text>
      </Flex>
      <Box
        height={"50%"}
        bgImage={"url(/images/default-user-image-female.jpg)"}
        bgSize="cover"
        bgPosition="center"
      />
      <Button
        position="absolute"
        top="30%"
        left="50%"
        transform="translate(-50%, -50%)"
        size="sm"
        colorScheme="teal"
        transition="opacity 0.2s ease-in-out"
        onClick={handleViewProfile}
        opacity={0}
        _groupHover={{ opacity: 1 }}
      >
        View Profile
      </Button>
      <Box p={6} flex={8}>
        <Stack justifyContent={"space-between"} height={"100%"}>
          <CustomTooltip label={room.description || ""}>
            <Box>
              <Text as="label" fontSize={"small"}>
                Room description
              </Text>
              <Text
                fontSize={"medium"}
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
            </Box>
          </CustomTooltip>
          <Box>
            <Text as="label" fontSize={"small"}>
              Scheduled at
            </Text>
            <Stack direction="row" align="center">
              <CalendarIcon fontSize={"x-small"} />
              <Text fontSize={"medium"}>
                {format(new Date(room.scheduledAt!), "MMMM do, yyyy h:mm:ss a")}
              </Text>
            </Stack>
          </Box>
          <Box>
            <Text as="label" fontSize={"small"}>
              Live duration
            </Text>
            <Stack direction="row" align="center">
              <TimeIcon />
              <Text fontSize={"medium"}>{20} mins</Text>
            </Stack>
          </Box>
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
              mt={4}
              alignItems={"center"}
              justifyContent={"space-between"}
            >
              <Button
                onClick={() => handleOnHideRoom && handleOnHideRoom(room.id!)}
                colorScheme="red"
                color="red.300"
                leftIcon={<IoCloseOutline />}
                variant="outline"
                aria-label="Hide room"
                size={"sm"}
                isLoading={ishidingRoom && actionPerformedOnRoomId === room.id}
              >
                Hide room
              </Button>
              {room.isParticipanting ? (
                <Button
                  onClick={() =>
                    handleOnNotInterestedAnymore &&
                    handleOnNotInterestedAnymore(room.id!)
                  }
                  colorScheme="pink"
                  color="pink.400"
                  leftIcon={<LuHeartOff />}
                  variant="outline"
                  aria-label="Opt Out"
                  size={"sm"}
                  isLoading={
                    isdeRegistering && actionPerformedOnRoomId === room.id
                  }
                >
                  Opt Out
                </Button>
              ) : (
                <Button
                  onClick={() =>
                    handleOnInterested && handleOnInterested(room.id!)
                  }
                  colorScheme="pink"
                  color="pink.400"
                  leftIcon={<FaHeart />}
                  variant="outline"
                  aria-label="I'm Interested"
                  size={"sm"}
                  isLoading={
                    isRegistering && actionPerformedOnRoomId === room.id
                  }
                >
                  I'm Interested
                </Button>
              )}
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
          <GradientButton size="md" boxShadow="xl" onClick={onStart}>
            Start Room
          </GradientButton>
        </motion.div>
      )}
      {isPreviewProfileModalOpen && (
        <PreviewProfileModal
          isOpen={isPreviewProfileModalOpen}
          onClose={handleClosePreviewProfileModal}
          userId={room.user?.id!}
        />
      )}
    </Box>
  );
};

export default RoomCard;
