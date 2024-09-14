import {
  Box,
  Heading,
  Text,
  Stack,
  Flex,
  Icon,
  useDisclosure,
  Collapse,
} from "@chakra-ui/react";
import Descriptor from "./Descriptor";
import { AvailableDescriptorDto } from "shared/src/types/openApiGen";
import { ChevronDownIcon, ChevronRightIcon } from "@chakra-ui/icons";

const Section = ({ section }: { section: AvailableDescriptorDto }) => {
  const { isOpen, onToggle } = useDisclosure({ defaultIsOpen: false });

  return (
    <Box p={5} shadow="md" borderWidth="1px" borderRadius="lg">
      <Flex
        justify="space-between"
        align="center"
        cursor="pointer"
        onClick={onToggle}
      >
        <Heading fontSize="xl">{section.sectionName}</Heading>
        <Icon as={isOpen ? ChevronDownIcon : ChevronRightIcon} w={6} h={6} />
      </Flex>
      <Collapse in={isOpen} animateOpacity>
        <Text mt={4}>{section.prompt}</Text>
        <Stack spacing={5} mt={4} maxHeight={250} overflowY={"auto"}>
          {section.descriptors?.map((descriptor) => (
            <Descriptor key={descriptor.id} descriptor={descriptor} />
          ))}
        </Stack>
      </Collapse>
    </Box>
  );
};

export default Section;
