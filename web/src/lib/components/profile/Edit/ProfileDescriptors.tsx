import { memo } from "react";
import { useSelector } from "react-redux";
import { VStack } from "@chakra-ui/react";

import { SelectedDescriptor } from "@truematch/shared/src/types/openApiGen";

import Section from "./Section";

import { RootState } from "~/lib/state/store";

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
