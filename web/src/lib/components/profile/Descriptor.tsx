import { Text } from "@chakra-ui/react";
import MultiSelection from "./MultiSelection";
import SingleSelection from "./SingleSelection";
import Measurement from "./Measurement";
import { Descriptor as DescriptorType } from "shared/src/types/openApiGen";
import AdvancedSingleSelection from "./AdvancedSingleSelection";

const Descriptor = ({ descriptor }: { descriptor: DescriptorType }) => {
  switch (descriptor.type) {
    case "multiSelectionSet":
      return <MultiSelection descriptor={descriptor} />;
    case "single_selection_set":
      return <SingleSelection descriptor={descriptor} />;
    case "choice_selector_v1":
      return <AdvancedSingleSelection descriptor={descriptor} />;
    case "measurement":
      return <Measurement descriptor={descriptor} />;
    default:
      return <Text>Unsupported Descriptor</Text>;
  }
};

export default Descriptor;
