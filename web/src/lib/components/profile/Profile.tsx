"use client";

import React, { useEffect } from "react";
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
} from "@chakra-ui/react";

import EditProfile from "./Edit";
import PreviewProfile from "./Preview";

import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import { AppDispatch, RootState } from "~/lib/state/store";

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

  useEffect(() => {
    dispatch(getAvailableDescriptors());
  }, [dispatch]);

  if (!user || !user.userProfile) {
    return null;
  }

  return (
    <Tabs
      maxWidth={{ base: "90%", md: "75%", lg: "50%" }}
      margin={"0 auto"}
      marginTop={{ base: "50px", md: "0px" }}
    >
      <TabList>
        <CustomTab>Edit</CustomTab>
        <CustomTab>Preview</CustomTab>
      </TabList>
      <TabPanels>
        <TabPanel>
          <EditProfile />
        </TabPanel>
        <TabPanel>
          <PreviewProfile />
        </TabPanel>
      </TabPanels>
    </Tabs>
  );
};

export default Profile;
