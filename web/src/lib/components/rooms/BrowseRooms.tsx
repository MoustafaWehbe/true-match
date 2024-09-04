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
import { clearRooms, getRooms } from "~/lib/state/room/roomSlice";
import CustomSelect, { Option } from "../shared/CustomSelect";
import { AllRoomStatus } from "shared/src/types/openApiGen";

const options: Option[] = [
  { value: 0, label: "Coming up" },
  { value: 1, label: "In progress" },
];

function BrowseRooms() {
  const bg = useColorModeValue("gray.50", "gray.800");
  const textColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const dispatch = useDispatch<AppDispatch>();
  const { rooms } = useSelector((state: RootState) => state.room);
  const [selectedStatus, setSelectedStatus] = useState<Option>(options[0]);
  const page = useRef(1);

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
    // const loadRooms = async (pageNumber: number) => {
    //   dispatch(
    //     getRooms({
    //       PageNumber: pageNumber,
    //       PageSize: 10,
    //       Status: selectedStatus.value as AllRoomStatus,
    //     })
    //   );

    //   // if (response.payload?.data?.length === 0) {
    //   //   setAllRoomsLoaded(true); // No more rooms to load
    //   // }
    // };

    loadRooms();
  }, [loadRooms]);

  const handleSelect = (option: Option) => {
    if (selectedStatus.value !== option.value) {
      setSelectedStatus(option);
      page.current = 1;
      dispatch(clearRooms());
    }
  };

  const handleLoadMore = () => {
    // setPage((prevPage) => prevPage + 1);
    page.current = page.current + 1;
    loadRooms();
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
              // isLoading={createRoomLoading || updateRoomLoading}
            >
              Load More
            </Button>
          </Flex>
        )}
    </Box>
  );
}

export default BrowseRooms;
