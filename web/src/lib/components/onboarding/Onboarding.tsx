"use client";

import React, { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Box, useToast } from "@chakra-ui/react";
import { useRouter } from "next/navigation";

import { openApiTypes } from "@dapp/shared";

import OnboardingFormStep1Dob from "./OnboardingFormStep1Dob";
import OnboardingFormStep2Gender from "./OnboardingFormStep2Gender";
import OnboardingFormStep3RelationGoals from "./OnboardingFormStep3RelationGoals";
import OnboardingFormStep4Interests from "./OnboardingFormStep4Interests";
import OnboardingLocationAccess from "./OnboardingLocationAccess";
import UploadImagesForm from "./UploadImageForm";

import { getAvailableDescriptors } from "~/lib/state/availableDescriptor/availableDescriptorSlice";
import { AppDispatch, RootState } from "~/lib/state/store";
import {
  createOrUpdateUserProfile,
  createUserMedia,
} from "~/lib/state/user/userSlice";

const Onboarding = () => {
  const [step, setStep] = useState(1);
  const dispatch = useDispatch<AppDispatch>();
  const toast = useToast();
  const { user } = useSelector((state: RootState) => state.user);
  const router = useRouter();

  useEffect(() => {
    if (!user?.userProfile?.birthDate) {
      setStep(1);
    } else if (!user.userProfile.userProfileGenders?.length) {
      setStep(2);
    } else if (
      !(
        user.userProfile.selectedDescriptors &&
        user.userProfile.selectedDescriptors.find(
          (desc) => desc.availableDescriptorId === 3
        )
      )
    ) {
      setStep(3);
    } else if (
      !(
        user.userProfile.selectedDescriptors &&
        user.userProfile.selectedDescriptors.find(
          (desc) => desc.availableDescriptorId === 2
        )
      )
    ) {
      setStep(4);
    } else if (!user.media?.length) {
      setStep(5);
    } else if (!user.userProfile.pos) {
      setStep(6);
    } else {
      window.location.href = "/";
    }
  }, [router, user?.media, user?.userProfile]);

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
    window.location.href = "/browse-rooms";
  };

  return (
    <Box width="100%" maxWidth="600px" mx="auto">
      {step === 1 && <OnboardingFormStep1Dob onSubmit={onStep1Submit} />}
      {step === 2 && <OnboardingFormStep2Gender onSubmit={onStep2Submit} />}
      {step === 3 && (
        <OnboardingFormStep3RelationGoals onSubmit={onStep3Submit} />
      )}
      {step === 4 && <OnboardingFormStep4Interests onSubmit={onStep4Submit} />}
      {step === 5 && <UploadImagesForm onSubmit={onUserImagesSubmit} />}
      {step === 6 && <OnboardingLocationAccess onSubmit={onLocationSubmit} />}
    </Box>
  );
};

export default Onboarding;
