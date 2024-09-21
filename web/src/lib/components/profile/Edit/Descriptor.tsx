import React from "react";
import { Text } from "@chakra-ui/react";

import {
  Descriptor as DescriptorType,
  SelectedDescriptor,
} from "@dapp/shared/src/types/openApiGen";

import AdvancedSingleSelection from "./AdvancedSingleSelection";
import Measurement from "./Measurement";
import MultiSelection from "./MultiSelection";
import SingleSelection from "./SingleSelection";

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
