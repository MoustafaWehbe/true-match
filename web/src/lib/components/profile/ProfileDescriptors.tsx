import { VStack } from "@chakra-ui/react";
import Section from "./Section";
import { useSelector } from "react-redux";
import { RootState } from "~/lib/state/store";
import { SelectedDescriptor } from "shared/src/types/openApiGen";

const ProfileDescriptors = ({
  onSelect,
}: {
  onSelect: (desc: SelectedDescriptor) => void;
}) => {
  const { availableDescriptors } = useSelector(
    (state: RootState) => state.availableDescriptor
  );

  return (
    <VStack spacing={8} align="stretch">
      {availableDescriptors?.map((section, index) => (
        <Section
          key={section.id + " " + index}
          section={section}
          onSelect={onSelect}
        />
      ))}
    </VStack>
  );
};

export default ProfileDescriptors;
