"use client";

import { useDispatch, useSelector } from "react-redux";
import { Box } from "@chakra-ui/react";
import { useEffect } from "react";

import ProfileDescriptors from "./ProfileDescriptors";
import { AppDispatch, RootState } from "~/lib/state/store";
import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import ImageSelector from "./ImageSelector";

const Profile = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { user } = useSelector((state: RootState) => state.user);

  useEffect(() => {
    dispatch(getAvailableDescriptors());
  }, [dispatch]);

  return (
    <Box maxWidth={"70%"} margin={"0 auto"}>
      <ImageSelector media={user?.media} />
      <br />
      <hr />
      <br />
      <ProfileDescriptors />
    </Box>
  );
};

export default Profile;
