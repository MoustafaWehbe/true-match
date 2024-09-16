import { Box, Button, useToast } from "@chakra-ui/react";
import ImageSelector from "./ImageSelector";
import ProfileDescriptors from "./ProfileDescriptors";
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "~/lib/state/store";
import { SelectedDescriptor } from "shared/src/types/openApiGen";
import { useCallback, useEffect, useState } from "react";
import { createOrUpdateUserProfile } from "~/lib/state/user/userSlice";
import BasicInfo, { BasicInfoType } from "./BasicInfo";

const EditProfile = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const [selectedSelectors, setSelectedSelectors] =
    useState<Array<SelectedDescriptor>>();
  const dispatch = useDispatch<AppDispatch>();
  const toast = useToast();
  const [basicFormData, setBasicFormData] = useState<BasicInfoType>({
    bio: "",
    job: "",
    school: "",
  });

  useEffect(() => {
    if (user?.userProfile?.selectedDescriptors) {
      setSelectedSelectors(user?.userProfile?.selectedDescriptors);
    }
  }, [user]);

  const onDescriptorChange = useCallback((desc: SelectedDescriptor) => {
    setSelectedSelectors((existingAvDesc) => {
      if (existingAvDesc) {
        const existingAvDescClone = [...existingAvDesc];
        const indexIfAlreadyExist = existingAvDesc?.findIndex(
          (existingDesc) =>
            existingDesc.availableDescriptorId === desc.availableDescriptorId &&
            existingDesc.descriptorId === desc.descriptorId
        );
        if (
          existingAvDescClone &&
          indexIfAlreadyExist !== undefined &&
          indexIfAlreadyExist !== -1
        ) {
          existingAvDescClone[indexIfAlreadyExist] = desc;
        } else {
          existingAvDescClone.push(desc);
        }
        return existingAvDescClone;
      } else {
        return [desc];
      }
    });
  }, []);

  const onSave = async () => {
    await dispatch(
      createOrUpdateUserProfile({
        selectedDescriptors: selectedSelectors!,
        bio:
          basicFormData.bio !== user?.userProfile?.bio
            ? basicFormData.bio
            : null,
        job:
          basicFormData.job !== user?.userProfile?.job
            ? basicFormData.job
            : null,
        school:
          basicFormData.school !== user?.userProfile?.school
            ? basicFormData.school
            : null,
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
    <Box>
      <ImageSelector media={user?.media} />
      <br />
      <hr />
      <br />
      <BasicInfo
        basicFormData={basicFormData}
        setBasicFormData={setBasicFormData}
      />
      <ProfileDescriptors onSelect={onDescriptorChange} />
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
  );
};

export default EditProfile;
