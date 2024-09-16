import { Text } from "@chakra-ui/react";
import MultiSelection from "./MultiSelection";
import SingleSelection from "./SingleSelection";
import Measurement from "./Measurement";
import {
  Descriptor as DescriptorType,
  SelectedDescriptor,
} from "shared/src/types/openApiGen";
import AdvancedSingleSelection from "./AdvancedSingleSelection";

const Descriptor = ({
  descriptor,
  availableDescriptorId,
  onSelect,
}: {
  descriptor: DescriptorType;
  availableDescriptorId: number;
  onSelect: (desc: SelectedDescriptor) => void;
}) => {
  switch (descriptor.type) {
    case "multiSelectionSet":
      return (
        <MultiSelection
          descriptor={descriptor}
          onSelect={onSelect}
          availableDescriptorId={availableDescriptorId}
        />
      );
    case "single_selection_set":
      return (
        <SingleSelection
          descriptor={descriptor}
          onSelect={onSelect}
          availableDescriptorId={availableDescriptorId}
        />
      );
    case "choice_selector_v1":
      return (
        <AdvancedSingleSelection
          descriptor={descriptor}
          onSelect={onSelect}
          availableDescriptorId={availableDescriptorId}
        />
      );
    case "measurement":
      return (
        <Measurement
          descriptor={descriptor}
          onSelect={onSelect}
          availableDescriptorId={availableDescriptorId}
        />
      );
    default:
      return <Text>Unsupported Descriptor</Text>;
  }
};

export default Descriptor;