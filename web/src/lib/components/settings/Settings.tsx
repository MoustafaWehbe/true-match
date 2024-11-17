"use client";

import { useState } from "react";
import { useDispatch } from "react-redux";
import {
  Box,
  Button,
  FormControl,
  FormLabel,
  Heading,
  RangeSlider,
  RangeSliderFilledTrack,
  RangeSliderThumb,
  RangeSliderTrack,
  Slider,
  SliderFilledTrack,
  SliderThumb,
  SliderTrack,
  Switch,
  Text,
  useColorModeValue,
  useToast,
  VStack,
} from "@chakra-ui/react";

import { AppDispatch } from "~/lib/state/store";
import { createOrUpdateUserProfile } from "~/lib/state/user/userSlice";

const SettingsPage = () => {
  const [ageFilter, setAgeFilter] = useState<[number, number]>([18, 50]); // Min and Max age
  const [distanceFilter, setDistanceFilter] = useState(30); // Default distance
  const [hideProfile, setHideProfile] = useState(false);

  const toast = useToast();
  const dispatch = useDispatch<AppDispatch>();

  const textColor = useColorModeValue("gray.800", "white");
  const sectionBgColor = useColorModeValue("white", "gray.700");

  const handleSave = async () => {
    await dispatch(
      createOrUpdateUserProfile({
        ageFilterMin: ageFilter[0],
        ageFilterMax: ageFilter[1],
      })
    );

    toast({
      title: "Settings Updated",
      description: "Your preferences have been saved successfully.",
      status: "success",
      duration: 5000,
      isClosable: true,
    });
  };

  const handleDeleteAccount = () => {
    // TODO: Call API to delete the account
    toast({
      title: "Account Deleted",
      description: "Your account has been deleted.",
      status: "error",
      duration: 5000,
      isClosable: true,
    });
  };

  return (
    <Box
      w="full"
      maxW="lg"
      mx="auto"
      mt={8}
      p={6}
      borderWidth="1px"
      borderRadius="lg"
      overflow="hidden"
      bg={sectionBgColor}
      shadow="md"
    >
      <VStack align="stretch" spacing={6}>
        <Heading size="lg" color={textColor}>
          Settings
        </Heading>

        {/* Age Filter */}
        <Box>
          <Heading size="md" color={textColor} mb={4}>
            Age Filter
          </Heading>
          <FormControl>
            <RangeSlider
              defaultValue={ageFilter}
              min={18}
              max={100}
              step={1}
              onChange={(val) => setAgeFilter(val as [number, number])}
              colorScheme="pink"
            >
              <RangeSliderTrack>
                <RangeSliderFilledTrack />
              </RangeSliderTrack>
              <RangeSliderThumb index={0} />
              <RangeSliderThumb index={1} />
            </RangeSlider>
            <Text mt={2} color={textColor}>
              {`From ${ageFilter[0]} to ${ageFilter[1]} years`}
            </Text>
          </FormControl>
        </Box>

        {/* Distance Filter */}
        <Box>
          <Heading size="md" color={textColor} mb={4}>
            Distance Filter
          </Heading>
          <FormControl>
            <Slider
              defaultValue={distanceFilter}
              min={1}
              max={200}
              step={1}
              onChange={(val) => setDistanceFilter(val)}
              colorScheme="pink"
            >
              <SliderTrack>
                <SliderFilledTrack />
              </SliderTrack>
              <SliderThumb />
            </Slider>
            <Text mt={2} color={textColor}>
              {distanceFilter} km
            </Text>
          </FormControl>
        </Box>

        {/* Hide Profile */}
        <Box>
          <Heading size="md" color={textColor} mb={4}>
            Privacy
          </Heading>
          <FormControl display="flex" alignItems="center">
            <FormLabel color={textColor} mb="0">
              Hide Profile
            </FormLabel>
            <Switch
              isChecked={hideProfile}
              onChange={(e) => setHideProfile(e.target.checked)}
              colorScheme="pink"
            />
          </FormControl>
        </Box>

        {/* Save Button */}
        <Button colorScheme="pink" w="full" onClick={handleSave}>
          Save Settings
        </Button>

        {/* Delete Account */}
        <Button colorScheme="red" w="full" onClick={handleDeleteAccount}>
          Delete Account
        </Button>
      </VStack>
    </Box>
  );
};

export default SettingsPage;
