"use client";

import { useCallback, useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  Box,
  Button,
  Flex,
  Grid,
  Heading,
  Stack,
  Text,
  useColorModeValue,
  useToast,
} from "@chakra-ui/react";
import { useRouter } from "next/navigation";

import { MyRoomStatus, RoomDto } from "@dapp/shared/src/types/openApiGen";

import MenuButton, { Option } from "../shared/buttons/CustomMenuButton";
import GradientButton from "../shared/buttons/GradientButton";

import RoomCard from "./RoomCard";
import RoomModal from "./RoomModal";

import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import { getQuestionCategories } from "~/lib/state/question/questionSlice";
import {
  clearMyRooms,
  clearRooms,
  createRoom,
  getMyRooms,
  startRoom,
  updateRoom,
} from "~/lib/state/room/roomSlice";
import { AppDispatch, RootState } from "~/lib/state/store";

const options: Option[] = [
  { value: 0, label: "Coming up" },
  { value: 1, label: "Archived" },
];

function MyRooms() {
  const bg = useColorModeValue("gray.50", "gray.800");
  const textColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const dispatch = useDispatch<AppDispatch>();
  const { myRooms, createRoomLoading, updateRoomLoading } = useSelector(
    (state: RootState) => state.room
  );
  const [selectedStatus, setSelectedStatus] = useState<Option>(options[0]);
  const { categories, categoriesLoading } = useSelector(
    (state: RootState) => state.question
  );
  const toast = useToast();
  const [isAgreementChecked, setIsAgreementChecked] = useState(false);
  const [roomToEdit, setRoomToEdit] = useState<RoomDto>();
  const [isRoomModalOpen, setIsRoomModalOpen] = useState(false);
  const page = useRef(1);
  const router = useRouter();

  const loadRooms = useCallback(() => {
    dispatch(
      getMyRooms({
        PageNumber: page.current,
        PageSize: 10,
        Status: selectedStatus.value as MyRoomStatus,
      })
    );
  }, [dispatch, selectedStatus.value]);

  useEffect(() => {
    loadRooms();

    return () => {
      dispatch(clearMyRooms());
    };
  }, [dispatch, selectedStatus.value, page, loadRooms]);

  useEffect(() => {
    if (!categories && !categoriesLoading) {
      dispatch(getQuestionCategories());
    }
  }, [dispatch, categories, categoriesLoading]);

  useEffect(() => {
    dispatch(getAvailableDescriptors());
  }, [dispatch]);

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

  const handleCreateRoom = async (values: any) => {
    await dispatch(
      createRoom({
        title: values.title,
        description: values.description,
        scheduledAt: new Date(values.scheduledAt),
        questionsCategories: values.selectedQuestionCategories.map(
          (e: string) => parseInt(e)
        ),
      })
    );
    handleCloseRoomModal();
    toast({
      title: "Room created.",
      description: "Your room has been created successfully.",
      status: "success",
      duration: 5000,
      isClosable: true,
    });
    page.current = 1;
    loadRooms();
  };

  const handleUpdateRoom = async (values: any, room: RoomDto) => {
    await dispatch(
      updateRoom({
        id: room.id!,
        title: values.title,
        description: values.description,
        scheduledAt: new Date(values.scheduledAt),
        questionsCategories: values.selectedQuestionCategories.map(
          (e: string) => parseInt(e)
        ),
      })
    );
    handleCloseRoomModal();
    toast({
      title: "Room updated.",
      description: "Your room has been updated successfully.",
      status: "success",
      duration: 5000,
      isClosable: true,
    });
  };

  const handleRoomModalSubmit = (values: any, room?: RoomDto) => {
    if (room) {
      handleUpdateRoom(values, room);
    } else {
      handleCreateRoom(values);
    }
  };

  const handleEditClicked = (room: RoomDto) => {
    setIsRoomModalOpen(true);
    setRoomToEdit(room);
  };

  const handleOpenRoomModal = () => setIsRoomModalOpen(true);

  const handleCloseRoomModal = () => {
    setIsRoomModalOpen(false);
    setRoomToEdit(undefined);
    setIsAgreementChecked(false);
  };

  const handleStartRoom = async (room: RoomDto) => {
    const res = await dispatch(startRoom({ id: room.id! }));
    if (
      res.payload &&
      "status" in res.payload &&
      res.payload.status !== 200 &&
      res.payload.status !== 201
    ) {
      toast({
        title: res.payload.data,
        status: "error",
        duration: 5000,
        isClosable: true,
      });
    } else {
      router.push(`rooms/${room.id}`);
    }
  };

  return (
    <Box bg={bg} color={textColor} px={8} py={4} borderRadius="lg">
      <Flex p={6} float={"right"} alignItems={"center"} gap={2}>
        <MenuButton
          options={options}
          placeholder="Select option"
          handleSelect={handleSelect}
          selectedOption={selectedStatus}
        />
        <GradientButton
          size="sm"
          color="white"
          boxShadow="xl"
          onClick={handleOpenRoomModal}
        >
          Schedule room
        </GradientButton>
      </Flex>

      <Stack spacing={4} align="center" sx={{ clear: "both" }}>
        <Heading fontSize="4xl">My Rooms</Heading>
        <Text fontSize="lg">You rooms appear here</Text>
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
        {myRooms?.data?.map((room) => (
          <RoomCard
            isComingUp={selectedStatus.value === 0}
            isArchived={selectedStatus.value === 1}
            key={room.id}
            room={room}
            onEditClicked={handleEditClicked}
            onStartRoom={handleStartRoom}
          />
        ))}
      </Grid>
      {myRooms &&
        myRooms.pageSize! * myRooms?.currentPage! <= myRooms?.data?.length! && (
          <Flex justify="center" mt={8}>
            <Button
              onClick={handleLoadMore}
              size="md"
              colorScheme="teal"
              isLoading={createRoomLoading || updateRoomLoading}
            >
              Load More
            </Button>
          </Flex>
        )}

      <RoomModal
        isOpen={isRoomModalOpen}
        room={roomToEdit}
        isAgreementChecked={isAgreementChecked}
        isLoading={createRoomLoading || updateRoomLoading}
        onClose={handleCloseRoomModal}
        handleSubmit={handleRoomModalSubmit}
        setIsAgreementChecked={setIsAgreementChecked}
      />
    </Box>
  );
}

export default MyRooms;
