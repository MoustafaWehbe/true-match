"use client";

import React, { useCallback, useEffect, useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  Box,
  Button,
  Flex,
  Grid,
  Stack,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";

import Loader from "../shared/Loader";

import RoomHistoryCard from "./RoomHistoryCard";

import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import { getRoomsHistory } from "~/lib/state/room/roomSlice";
import { AppDispatch, RootState } from "~/lib/state/store";

function History() {
  const bg = useColorModeValue("gray.50", "gray.800");
  const textColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const dispatch = useDispatch<AppDispatch>();
  const { roomsHistory, getRoomsHistoryLoading } = useSelector(
    (state: RootState) => state.room
  );
  const page = useRef(1);

  const loadRooms = useCallback(() => {
    dispatch(
      getRoomsHistory({
        PageNumber: page.current,
        PageSize: 10,
      })
    );
  }, [dispatch]);

  useEffect(() => {
    dispatch(getAvailableDescriptors());
  }, [dispatch]);

  useEffect(() => {
    loadRooms();
  }, [loadRooms]);

  const handleLoadMore = () => {
    page.current = page.current + 1;
    loadRooms();
  };

  return (
    <Box bg={bg} color={textColor} px={8} py={4} borderRadius="lg">
      <Text as="p" margin={"0 auto"} textAlign={"center"}>
        All the lives you have atteneded will appear here.
      </Text>
      <Box
        marginTop={{ base: "50px", md: "0px" }}
        display={"flex"}
        justifyContent={"space-between"}
      >
        <Loader isLoading={getRoomsHistoryLoading} />

        <Stack spacing={4} align="center" sx={{ clear: "both" }}>
          {!roomsHistory?.data?.length && !getRoomsHistoryLoading ? (
            <Text mt={6}>Room history is empty!</Text>
          ) : null}
        </Stack>
        <Grid
          templateColumns={{
            base: "repeat(1, 1fr)",
            md: "repeat(2, 1fr)",
            lg: "repeat(3, 1fr)",
          }}
          gap={8}
          mt={8}
        >
          {roomsHistory?.data?.map((room) => (
            <RoomHistoryCard key={room.id} room={room} />
          ))}
        </Grid>
        {roomsHistory &&
          roomsHistory.pageSize! * roomsHistory?.currentPage! <=
            roomsHistory?.data?.length! && (
            <Flex justify="center" mt={8}>
              <Button
                onClick={handleLoadMore}
                size="md"
                colorScheme="teal"
                isLoading={getRoomsHistoryLoading}
              >
                Load More
              </Button>
            </Flex>
          )}
      </Box>
    </Box>
  );
}

export default History;
