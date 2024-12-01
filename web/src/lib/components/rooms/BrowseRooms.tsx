"use client";

import React, { useCallback, useEffect, useRef, useState } from "react";
import { FaCheck } from "react-icons/fa";
import { useDispatch, useSelector } from "react-redux";
import { ChevronDownIcon } from "@chakra-ui/icons";
import {
  Box,
  Button,
  Flex,
  Grid,
  Popover,
  PopoverArrow,
  PopoverBody,
  PopoverContent,
  PopoverTrigger,
  Stack,
  Tab,
  TabList,
  Tabs,
  Text,
  useColorModeValue,
  VStack,
} from "@chakra-ui/react";

import { AllRoomStatus, RoomsSortBy } from "@dapp/shared/src/types/openApiGen";

import { Option } from "../shared/buttons/CustomMenuButton";
import ConfirmDialog from "../shared/ConfirmDialog";
import Loader from "../shared/Loader";

import RoomCard from "./RoomCard";

import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import {
  clearRooms,
  deregisterRoom,
  getRooms,
  hideRoom,
  registerRoom,
  removeRoomById,
  removeRoomsByUserId,
} from "~/lib/state/room/roomSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import { blockUser } from "~/lib/state/user/userSlice";

const filterOptions: Option[] = [
  { value: 0, label: "Coming up" },
  { value: 1, label: "In progress" },
  { value: 2, label: "Interested to attend" },
];

const sortOptions: Option[] = [
  { value: 0, label: "Recently Created" },
  { value: 1, label: "Number of Participants" },
  { value: 2, label: "Schedule Date" },
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
  const [selectedStatus, setSelectedStatus] = useState<Option>(
    filterOptions[0]
  );
  const page = useRef(1);
  const [roomIdToBlock, setRoomIdToBlock] = useState<string>();

  const openDialog = () => setIsDialogOpen(true);
  const closeDialog = () => setIsDialogOpen(false);
  const [selectedSortByOption, setSelectedSortByOption] = useState(
    sortOptions[0]
  );

  const menuHoverBg = useColorModeValue("pink.200", "pink.600");
  const menuTextColor = useColorModeValue("gray.800", "white");

  const loadRooms = useCallback(() => {
    dispatch(
      getRooms({
        PageNumber: page.current,
        PageSize: 10,
        Status: selectedStatus.value as AllRoomStatus,
        SortBy: selectedSortByOption.value as RoomsSortBy,
      })
    );
  }, [dispatch, selectedSortByOption.value, selectedStatus.value]);

  useEffect(() => {
    dispatch(getAvailableDescriptors());
  }, [dispatch]);

  useEffect(() => {
    if (selectedSortByOption) {
      loadRooms();
    }

    return () => {
      dispatch(clearRooms());
    };
  }, [dispatch, loadRooms, selectedSortByOption]);

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

  const handleOnInterested = (roomId: string) => {
    dispatch(registerRoom(roomId));
  };

  const handleOnHideRoom = (roomId: string) => {
    dispatch(hideRoom({ roomId }));
  };

  const handleOnNotInterestedAnymore = async (roomId: string) => {
    await dispatch(deregisterRoom(roomId));
    if (selectedStatus.value === 2) {
      dispatch(removeRoomById(roomId));
    }
  };

  const handleSortChange = (value: Option) => {
    page.current = 1;
    setSelectedSortByOption(value);
  };

  return (
    <Box bg={bg} color={textColor} px={8} py={4} borderRadius="lg">
      <Tabs
        marginTop={{ base: "50px", md: "0px" }}
        display={"flex"}
        justifyContent={"space-between"}
      >
        <TabList flex={1} maxWidth={{ base: "90%", md: "75%", lg: "50%" }}>
          {filterOptions.map((option) => {
            return (
              <Tab
                key={option.value + "1"}
                onClick={() => handleSelect(option)}
                flex={"auto"}
              >
                {option.label}
              </Tab>
            );
          })}
        </TabList>
        <Flex justifyContent="flex-end" alignItems="center">
          <Box>
            <Popover>
              <PopoverTrigger>
                <Button
                  size={"md"}
                  colorScheme="pink"
                  rightIcon={<ChevronDownIcon />}
                  variant={"ghost"}
                >
                  Sort by: &nbsp;
                  <Text as="span" fontWeight={"bolder"}>
                    {selectedSortByOption.label}
                  </Text>
                </Button>
              </PopoverTrigger>
              <PopoverContent width={"fit-content"}>
                <PopoverArrow />
                <PopoverBody>
                  <VStack align="start">
                    {sortOptions.map((option) => (
                      <Flex
                        key={option.value}
                        alignItems={"center"}
                        onClick={() => handleSortChange(option)}
                        borderRadius={5}
                        _hover={{
                          bg: menuHoverBg,
                        }}
                        width={"100%"}
                      >
                        {selectedSortByOption.value === option.value ? (
                          <FaCheck width={"20px"} />
                        ) : (
                          <Box width={"20px"}></Box>
                        )}
                        <Box
                          color={menuTextColor}
                          cursor={"pointer"}
                          paddingY={1}
                          paddingX={2}
                        >
                          {option.label}
                        </Box>
                      </Flex>
                    ))}
                  </VStack>
                </PopoverBody>
              </PopoverContent>
            </Popover>
          </Box>
        </Flex>
      </Tabs>
      <Loader isLoading={getRoomsLoading} />

      <Stack spacing={4} align="center" sx={{ clear: "both" }}>
        {!rooms?.data?.length && !getRoomsLoading ? (
          <Text mt={6}>No available rooms at the moment!</Text>
        ) : null}
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
            handleOnBlock={(roomId: string) => {
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
