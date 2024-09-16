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
} from "@chakra-ui/react";
import React, { useEffect } from "react";

import { AppDispatch, RootState } from "~/lib/state/store";
import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import EditProfile from "./Edit";
import PreviewProfile from "./Preview";

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
    <Tabs maxWidth={"50%"} margin={"0 auto"}>
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