"use client";

import React, { useEffect, useState } from "react";
import { Box, useToast } from "@chakra-ui/react";
import UserProfileForm from "./UserProfileForm";
import UploadImagesForm from "./UploadImageForm";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "~/lib/state/store";
import { createUserMedia, createUserProfile } from "~/lib/state/user/userSlice";
import { CreateUserProfileDto } from "shared/src/types/openApiGen";

const CompleteProfile = () => {
  const [step, setStep] = useState(2);
  const dispatch = useDispatch<AppDispatch>();
  const { userProfileCreated } = useSelector((state: RootState) => state.user);
  const toast = useToast();

  useEffect(() => {
    if (userProfileCreated) {
      setStep(2);
    }
  }, [userProfileCreated]);

  const onUserProfileSubmit = (values: CreateUserProfileDto) => {
    setStep(2);

    // dispatch(
    //   createUserProfile({
    //     ...values,
    //   })
    // );
  };

  const onUserImagesSubmit = (images: (File | null)[]) => {
    if (!images || !images.length) {
      toast({
        title: "Please select images.",
        status: "error",
        duration: 5000,
        isClosable: true,
      });
      return;
    }

    images.forEach((file) => {
      if (!file) {
        return;
      }
      try {
        dispatch(createUserMedia(file));
      } catch (error) {
        console.error("Error uploading file:", error);
      }
    });
  };

  return (
    <Box width="100%" maxWidth="600px" mx="auto">
      {step === 1 && <UserProfileForm onSubmit={onUserProfileSubmit} />}
      {step === 2 && <UploadImagesForm onSubmit={onUserImagesSubmit} />}
    </Box>
  );
};

export default CompleteProfile;
