"use client";

import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { ChevronDownIcon } from "@chakra-ui/icons";
import {
  Box,
  Button,
  Checkbox,
  FormControl,
  FormLabel,
  Heading,
  Popover,
  PopoverArrow,
  PopoverBody,
  PopoverCloseButton,
  PopoverContent,
  PopoverHeader,
  PopoverTrigger,
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

import ConfirmDialog from "../shared/ConfirmDialog";

import { getGenders } from "~/lib/state/gender/genderSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import {
  createOrUpdateUserProfile,
  deleteAccount,
} from "~/lib/state/user/userSlice";

const SettingsPage = () => {
  const [ageFilter, setAgeFilter] = useState<[number, number]>([18, 50]);
  const [distanceFilter, setDistanceFilter] = useState(30);
  const [hideProfile, setHideProfile] = useState(false);
  const { user, deleteAccountLoading } = useSelector(
    (state: RootState) => state.user
  );
  const [isDialogOpen, setIsDialogOpen] = useState(false);
  const [genderPreferences, setGenderPreferences] = useState<string[]>([]);

  const toast = useToast();
  const dispatch = useDispatch<AppDispatch>();

  const textColor = useColorModeValue("gray.800", "white");
  const sectionBgColor = useColorModeValue("white", "gray.700");
  const { genders } = useSelector((state: RootState) => state.gender);

  const openDialog = () => setIsDialogOpen(true);
  const closeDialog = () => setIsDialogOpen(false);

  const handleSave = async () => {
    const res = await dispatch(
      createOrUpdateUserProfile({
        ageFilterMin: ageFilter[0],
        ageFilterMax: ageFilter[1],
        distanceFilter: distanceFilter,
        hidden: hideProfile,
        userProfileGenderPreferences: genderPreferences,
      })
    );

    if (res.meta.requestStatus === "rejected") {
      toast({
        title: "Failed to update settings",
        status: "error",
        duration: 5000,
        isClosable: true,
      });
      return;
    }

    toast({
      title: "Settings Updated",
      description: "Your preferences have been saved successfully.",
      status: "success",
      duration: 5000,
      isClosable: true,
    });
  };

  const handleDeleteAccount = async () => {
    await dispatch(deleteAccount());
    window.location.href = "/login";
    toast({
      title: "Account Deleted",
      description: "Your account has been deleted.",
      status: "error",
      duration: 5000,
      isClosable: true,
    });
  };

  useEffect(() => {
    if (user?.userProfile?.ageFilterMax && user.userProfile.ageFilterMin) {
      setAgeFilter([
        user?.userProfile?.ageFilterMin,
        user?.userProfile?.ageFilterMax,
      ]);
    }
    setHideProfile(!!user?.userProfile?.hidden);
    setDistanceFilter(user?.userProfile?.distanceFilter || 30);
  }, [user]);

  useEffect(() => {
    dispatch(getGenders());
  }, [dispatch]);

  useEffect(() => {
    if (user?.userProfile) {
      setGenderPreferences(user.userProfile.userProfileGenderPreferences || []);
    }
  }, [user?.userProfile]);

  const handleCheckboxChange = (id: string) => {
    setGenderPreferences((prev) =>
      prev.includes(id)
        ? prev.filter((genderId) => genderId !== id)
        : [...prev, id]
    );
  };

  if (!user) {
    return null;
  }

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
        <hr style={{ width: "100%", margin: "0 auto" }} />

        {/* Age Filter */}
        <Box>
          <Heading size="sm" color={textColor} mb={4}>
            Age Filter
          </Heading>
          <FormControl>
            <RangeSlider
              value={ageFilter}
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

        <Box>
          <Heading size="sm" color={textColor} mb={4}>
            Distance Filter
          </Heading>
          <FormControl>
            <Slider
              value={distanceFilter}
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

        <Box>
          <Heading size="sm" color={textColor} mb={4}>
            Gender Preferences
          </Heading>
          <FormControl>
            <Box>
              <Popover>
                <PopoverTrigger>
                  <Button
                    size={"md"}
                    colorScheme="pink"
                    rightIcon={<ChevronDownIcon />}
                  >
                    {genderPreferences.length > 0
                      ? `Selected (${genderPreferences.length})`
                      : "Select Gender Preferences"}
                  </Button>
                </PopoverTrigger>
                <PopoverContent>
                  <PopoverArrow />
                  <PopoverCloseButton />
                  <PopoverHeader>Select Preferences</PopoverHeader>
                  <PopoverBody>
                    <VStack align="start">
                      {genders
                        ?.filter((gender) => gender.parentId === null)
                        .map((gender) => (
                          <Checkbox
                            key={gender.id}
                            isChecked={genderPreferences.includes(gender.id!)}
                            onChange={() => handleCheckboxChange(gender.id!)}
                          >
                            {gender.name}
                          </Checkbox>
                        ))}
                    </VStack>
                  </PopoverBody>
                </PopoverContent>
              </Popover>
            </Box>
          </FormControl>
        </Box>

        <Box>
          <Heading size="sm" color={textColor} mb={4}>
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

        <Button colorScheme="pink" w="full" onClick={handleSave}>
          Save Settings
        </Button>

        <Button colorScheme="red" bg={"red.400"} w="full" onClick={openDialog}>
          Delete Account
        </Button>
      </VStack>

      <ConfirmDialog
        isOpen={isDialogOpen}
        onClose={closeDialog}
        onConfirm={handleDeleteAccount}
        title="Delete Account?"
        description="Are you sure you want to delete your account?<br /><br />Instead of deleting, you have the option to hide your account."
        confirmText="Delete"
        cancelText="Cancel"
        isLoading={deleteAccountLoading}
      />
    </Box>
  );
};

export default SettingsPage;
