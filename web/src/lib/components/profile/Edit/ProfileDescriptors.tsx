import { VStack } from "@chakra-ui/react";
import Section from "./Section";
import { useSelector } from "react-redux";
import { RootState } from "~/lib/state/store";
import { SelectedDescriptor } from "@dapp/shared/src/types/openApiGen";
import { memo } from "react";

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

export default memo(ProfileDescriptors);
