"use client";

import {
  Box,
  Button,
  Flex,
  Grid,
  Heading,
  Stack,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
import { useCallback, useEffect, useRef, useState } from "react";
import RoomCard from "./RoomCard";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "~/lib/state/store";
import {
  clearRooms,
  deregisterRoom,
  getRooms,
  hideRoom,
  registerRoom,
  removeRoomById,
  removeRoomsByUserId,
} from "~/lib/state/room/roomSlice";
import CustomSelect, { Option } from "../shared/CustomSelect";
import { AllRoomStatus } from "@dapp/shared/src/types/openApiGen";
import { blockUser } from "~/lib/state/user/userSlice";
import ConfirmDialog from "../shared/ConfirmDialog";
import Loader from "../shared/Loader";

const options: Option[] = [
  { value: 0, label: "Coming up" },
  { value: 1, label: "In progress" },
  { value: 2, label: "Interested to attend" },
];

function BrowseRooms() {
  const bg = useColorModeValue("gray.50", "gray.800");
  const textColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const dispatch = useDispatch<AppDispatch>();
  const [isDialogOpen, setIsDialogOpen] = useState(false);
  const { rooms, getRoomsLoading } = useSelector(
    (state: RootState) => state.room
  );
  const { isBlockingUser } = useSelector((state: RootState) => state.user);
  const [selectedStatus, setSelectedStatus] = useState<Option>(options[0]);
  const page = useRef(1);
  const [roomIdToBlock, setRoomIdToBlock] = useState<number>();

  const openDialog = () => setIsDialogOpen(true);
  const closeDialog = () => setIsDialogOpen(false);

  const loadRooms = useCallback(() => {
    dispatch(
      getRooms({
        PageNumber: page.current,
        PageSize: 10,
        Status: selectedStatus.value as AllRoomStatus,
      })
    );
  }, [dispatch, selectedStatus.value]);

  useEffect(() => {
    loadRooms();

    return () => {
      dispatch(clearRooms());
    };
  }, [dispatch, loadRooms]);

  const handleSelect = (option: Option) => {
    if (selectedStatus.value !== option.value) {
      setSelectedStatus(option);
      page.current = 1;
      dispatch(clearRooms());
    }
  };

  const handleLoadMore = () => {
    page.current = page.current + 1;
    loadRooms();
  };

  const handleOnBlock = async () => {
    if (!roomIdToBlock) {
      return;
    }
    const room = rooms?.data?.find((r) => r.id === roomIdToBlock);
    if (room && room.user?.id) {
      await dispatch(blockUser({ blockedUserId: room.user.id }));
      closeDialog();
      dispatch(removeRoomsByUserId(room.user.id));
    }
  };

  const handleOnInterested = (roomId: number) => {
    dispatch(registerRoom(roomId));
  };

  const handleOnHideRoom = (roomId: number) => {
    dispatch(hideRoom({ roomId }));
  };

  const handleOnNotInterestedAnymore = async (roomId: number) => {
    await dispatch(deregisterRoom(roomId));
    if (selectedStatus.value === 2) {
      dispatch(removeRoomById(roomId));
    }
  };

  return (
    <Box bg={bg} color={textColor} px={8} py={4} borderRadius="lg">
      <Box p={6} float={"right"}>
        <CustomSelect
          options={options}
          placeholder="Select option"
          handleSelect={handleSelect}
          selectedOption={selectedStatus}
        />
      </Box>
      <Loader isLoading={getRoomsLoading} />

      <Stack spacing={4} align="center" sx={{ clear: "both" }}>
        <Heading fontSize="4xl">Browse Rooms</Heading>
        {rooms?.data?.length ? (
          <Text fontSize="lg">
            Join us for these exciting live rooms happening soon!
          </Text>
        ) : (
          <Text>No available rooms at the moment!</Text>
        )}
      </Stack>
      <Grid
        templateColumns={{
          base: "repeat(1, 1fr)", // For screens less than 48em (768px)
          md: "repeat(2, 1fr)", // For screens between 48em (768px) and 74em (1184px)
          lg: "repeat(3, 1fr)", // For screens larger than 74em (1184px)
        }}
        gap={8}
        mt={8}
      >
        {rooms?.data?.map((room) => (
          <RoomCard
            isComingUp={selectedStatus.value === 0}
            isInProgress={selectedStatus.value === 1}
            key={room.id}
            room={room}
            handleOnBlock={(roomId: number) => {
              openDialog();
              setRoomIdToBlock(roomId);
            }}
            handleOnInterested={handleOnInterested}
            handleOnHideRoom={handleOnHideRoom}
            handleOnNotInterestedAnymore={handleOnNotInterestedAnymore}
          />
        ))}
      </Grid>
      {rooms &&
        rooms.pageSize! * rooms?.currentPage! <= rooms?.data?.length! && (
          <Flex justify="center" mt={8}>
            <Button
              onClick={handleLoadMore}
              size="md"
              colorScheme="teal"
              isLoading={getRoomsLoading}
            >
              Load More
            </Button>
          </Flex>
        )}
      <ConfirmDialog
        isOpen={isDialogOpen}
        onClose={closeDialog}
        onConfirm={handleOnBlock}
        title="Block User?"
        description="Are you sure you want to block this user? We will not show you their rooms or profile anymore. 
        <br/><br/>This action cannot be undone."
        confirmText="Block"
        cancelText="Cancel"
        isLoading={isBlockingUser}
      />
    </Box>
  );
}

export default BrowseRooms;
