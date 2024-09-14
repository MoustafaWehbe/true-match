import { VStack } from "@chakra-ui/react";
import Section from "./Section";
import { useSelector } from "react-redux";
import { RootState } from "~/lib/state/store";

const ProfileDescriptors = () => {
  const { availableDescriptors } = useSelector(
    (state: RootState) => state.availableDescriptor
  );

  return (
    <VStack spacing={8} align="stretch">
      {availableDescriptors?.map((section) => (
        <Section key={section.id} section={section} />
      ))}
    </VStack>
  );
};

export default ProfileDescriptors;
