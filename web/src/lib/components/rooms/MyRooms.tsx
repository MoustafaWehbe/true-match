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
  useToast,
} from "@chakra-ui/react";
import RoomCard from "./RoomCard";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "~/lib/state/store";
import { createRoom, getMyRooms, updateRoom } from "~/lib/state/room/roomSlice";
import { useEffect, useState } from "react";
import { MyRoomStatus, RoomDto } from "shared/src/types/openApiGen";
import CustomSelect, { Option } from "../shared/CustomSelect";
import { getQuestionCategories } from "~/lib/state/question/questionSlice";
import RoomModal from "./RoomModal";

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
  const [page, setPage] = useState(1);
  const [allRoomsLoaded, setAllRoomsLoaded] = useState(false);

  useEffect(() => {
    const loadRooms = async (pageNumber: number) => {
      await dispatch(
        getMyRooms({
          PageNumber: pageNumber,
          PageSize: 10,
          Status: selectedStatus.value as MyRoomStatus,
        })
      );

      // if (response.payload?.data?.length === 0) {
      //   setAllRoomsLoaded(true); // No more rooms to load
      // }
    };

    loadRooms(page);
  }, [dispatch, selectedStatus.value, page]);

  // useEffect(() => {
  //   dispatch(
  //     getMyRooms({
  //       PageNumber: 1,
  //       PageSize: 10,
  //       Status: selectedStatus.value as MyRoomStatus,
  //     })
  //   );
  // }, [dispatch, selectedStatus.value]);

  useEffect(() => {
    if (!categories && !categoriesLoading) {
      dispatch(getQuestionCategories());
    }
  }, [dispatch, categories, categoriesLoading]);

  const handleSelect = (option: Option) => {
    setSelectedStatus(option);
    setPage(1);
    setAllRoomsLoaded(false);
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
    setPage(1);
    setAllRoomsLoaded(false);
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
    setPage(1);
    setAllRoomsLoaded(false);
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

  const handleLoadMore = () => {
    setPage((prevPage) => prevPage + 1);
  };

  return (
    <Box bg={bg} color={textColor} px={8} py={4} borderRadius="lg">
      <Flex p={6} float={"right"} alignItems={"center"} gap={2}>
        <CustomSelect
          options={options}
          placeholder="Select option"
          handleSelect={handleSelect}
          selectedOption={selectedStatus}
        />
        <Button
          size="sm"
          bgGradient="linear(to-r, teal.500, green.500)"
          color="white"
          _hover={{ bgGradient: "linear(to-r, teal.600, green.600)" }}
          _active={{ bgGradient: "linear(to-r, teal.700, green.700)" }}
          boxShadow="xl"
          onClick={handleOpenRoomModal}
        >
          Schedule room
        </Button>
      </Flex>

      <Stack spacing={4} align="center" sx={{ clear: "both" }}>
        <Heading fontSize="4xl">My Rooms</Heading>
        <Text fontSize="lg">
          Join us for these exciting live rooms happening soon!
        </Text>
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
          />
        ))}
      </Grid>
      {!allRoomsLoaded && (
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
