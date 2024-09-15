"use client";

import { useDispatch, useSelector } from "react-redux";
import {
  Box,
  Button,
  TabList,
  TabPanel,
  TabPanels,
  Tabs,
  useMultiStyleConfig,
  useTab,
  useToast,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";

import ProfileDescriptors from "./ProfileDescriptors";
import { AppDispatch, RootState } from "~/lib/state/store";
import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import ImageSelector from "./ImageSelector";
import { SelectedDescriptor } from "shared/src/types/openApiGen";
import { createOrUpdateUserProfile } from "~/lib/state/user/userSlice";

const CustomTab = React.forwardRef((props: any, ref: any) => {
  // 1. Reuse the `useTab` hook
  const tabProps = useTab({ ...props, ref });
  // const isSelected = !!tabProps["aria-selected"];

  // 2. Hook into the Tabs `size`, `variant`, props
  const styles = useMultiStyleConfig("Tabs", tabProps);

  return (
    <Button __css={styles.tab} {...tabProps}>
      <Box as="span" mr="2">
        {props.children === "Preview" ? "😎" : "🤳🏽"}
      </Box>
      {tabProps.children}
    </Button>
  );
});

CustomTab.displayName = "CustomTab";

const Profile = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { user } = useSelector((state: RootState) => state.user);
  const [selectedSelectors, setSelectedSelectors] =
    useState<Array<SelectedDescriptor>>();
  const toast = useToast();

  useEffect(() => {
    if (user?.userProfile?.selectedDescriptors) {
      setSelectedSelectors(user?.userProfile?.selectedDescriptors);
    }
  }, [user]);

  useEffect(() => {
    dispatch(getAvailableDescriptors());
  }, [dispatch]);

  if (!user || !user.userProfile) {
    return null;
  }

  const onSelect = (desc: SelectedDescriptor) => {
    const existingAvDesc: Array<SelectedDescriptor> = JSON.parse(
      JSON.stringify(user?.userProfile?.selectedDescriptors)
    );

    const indexIfAlreadyExist = existingAvDesc?.findIndex(
      (existingDesc) =>
        existingDesc.availableDescriptorId === desc.availableDescriptorId &&
        existingDesc.descriptorId === desc.descriptorId
    );
    if (
      existingAvDesc &&
      indexIfAlreadyExist !== undefined &&
      indexIfAlreadyExist !== -1
    ) {
      existingAvDesc[indexIfAlreadyExist] = desc;
    } else if (existingAvDesc) {
      existingAvDesc.push(desc);
    }

    setSelectedSelectors(existingAvDesc);
    // return existingAvDesc;
  };

  const onSave = async () => {
    await dispatch(
      createOrUpdateUserProfile({
        selectedDescriptors: selectedSelectors!,
      })
    );
    toast({
      title: "Profile updated.",
      description: "Your profile has been updated successfully.",
      status: "success",
      duration: 5000,
      isClosable: true,
    });
  };

  return (
    <Tabs maxWidth={"50%"} margin={"0 auto"}>
      <TabList>
        <CustomTab>Edit</CustomTab>
        <CustomTab>Preview</CustomTab>
      </TabList>
      <TabPanels>
        <TabPanel>
          <Box>
            <ImageSelector media={user?.media} />
            <br />
            <hr />
            <br />
            <ProfileDescriptors onSelect={onSelect} />
            <Button
              size="md"
              bgGradient="linear(to-r, teal.500, green.500)"
              color="white"
              _hover={{ bgGradient: "linear(to-r, teal.600, green.600)" }}
              _active={{ bgGradient: "linear(to-r, teal.700, green.700)" }}
              boxShadow="xl"
              onClick={onSave}
              mt={4}
              float={"right"}
            >
              Save
            </Button>
          </Box>
        </TabPanel>
        <TabPanel>Preview</TabPanel>
      </TabPanels>
    </Tabs>
  );
};

export default Profile;
