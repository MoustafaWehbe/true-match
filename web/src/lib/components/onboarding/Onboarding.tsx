"use client";

import React, { useEffect, useState } from "react";
import { Box, useToast } from "@chakra-ui/react";
import OnboardingFormStep1 from "./OnboardingFormStep1";
import UploadImagesForm from "./UploadImageForm";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "~/lib/state/store";
import {
  createUserMedia,
  createOrUpdateUserProfile,
} from "~/lib/state/user/userSlice";
import { openApiTypes } from "@dapp/shared";
import OnboardingFormStep2 from "./OnboardingFormStep2";
import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import OnboardingFormStep3 from "./OnboardingFormStep3";
import OnboardingFormStep4 from "./OnboardingFormStep4";
import OnboardingLocationAccess from "./OnboardingLocationAccess";

const Onboarding = () => {
  const [step, setStep] = useState(1);
  const dispatch = useDispatch<AppDispatch>();
  const toast = useToast();
  const { user } = useSelector((state: RootState) => state.user);

  useEffect(() => {
    dispatch(getAvailableDescriptors());
  }, [dispatch]);

  const onStep1Submit = async (
    values: Pick<openApiTypes.CreateOrUpdateUserProfileDto, "birthDate">
  ) => {
    await dispatch(
      createOrUpdateUserProfile({
        ...values,
      })
    );
    setStep(2);
  };

  const onStep2Submit = async (
    values: Pick<
      openApiTypes.CreateOrUpdateUserProfileDto,
      "userProfileGenders"
    >
  ) => {
    await dispatch(
      createOrUpdateUserProfile({
        ...values,
      })
    );
    setStep(3);
  };

  const getMergedDescriptors = (
    values: Pick<
      openApiTypes.CreateOrUpdateUserProfileDto,
      "selectedDescriptors"
    >
  ) => {
    const avDesc = values.selectedDescriptors!;
    const existingAvDesc: Array<openApiTypes.SelectedDescriptor> =
      JSON.parse(JSON.stringify(user?.userProfile?.selectedDescriptors)) || [];
    const indexIfAlreadyExist = existingAvDesc?.findIndex(
      (desc) => desc.availableDescriptorId === avDesc[0].availableDescriptorId
    );
    if (
      existingAvDesc &&
      indexIfAlreadyExist !== undefined &&
      indexIfAlreadyExist !== -1
    ) {
      existingAvDesc[indexIfAlreadyExist] = avDesc[0];
    } else if (existingAvDesc) {
      existingAvDesc.push(avDesc[0]);
    }
    return existingAvDesc;
  };

  const onStep3Submit = async (
    values: Pick<
      openApiTypes.CreateOrUpdateUserProfileDto,
      "selectedDescriptors"
    >
  ) => {
    await dispatch(
      createOrUpdateUserProfile({
        selectedDescriptors: getMergedDescriptors(values),
      })
    );
    setStep(4);
  };

  const onStep4Submit = async (
    values: Pick<
      openApiTypes.CreateOrUpdateUserProfileDto,
      "selectedDescriptors"
    >
  ) => {
    await dispatch(
      createOrUpdateUserProfile({
        selectedDescriptors: getMergedDescriptors(values),
      })
    );
    setStep(5);
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

    images.forEach(async (file) => {
      if (!file) {
        return;
      }
      try {
        await dispatch(createUserMedia(file));
      } catch (error) {
        console.error("Error uploading file:", error);
      }
    });
    setStep(6);
  };

  const onLocationSubmit = async (
    values: Pick<openApiTypes.CreateOrUpdateUserProfileDto, "pos">
  ) => {
    await dispatch(
      createOrUpdateUserProfile({
        ...values,
      })
    );
    window.location.href = "/";
  };

  return (
    <Box width="100%" maxWidth="600px" mx="auto">
      {step === 1 && <OnboardingFormStep1 onSubmit={onStep1Submit} />}
      {step === 2 && <OnboardingFormStep2 onSubmit={onStep2Submit} />}
      {step === 3 && <OnboardingFormStep3 onSubmit={onStep3Submit} />}
      {step === 4 && <OnboardingFormStep4 onSubmit={onStep4Submit} />}
      {step === 5 && <UploadImagesForm onSubmit={onUserImagesSubmit} />}
      {step === 6 && <OnboardingLocationAccess onSubmit={onLocationSubmit} />}
    </Box>
  );
};

export default Onboarding;
