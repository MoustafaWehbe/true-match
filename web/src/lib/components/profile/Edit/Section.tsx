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
import {
  AvailableDescriptorDto,
  SelectedDescriptor,
} from "shared/src/types/openApiGen";
import { ChevronDownIcon, ChevronRightIcon } from "@chakra-ui/icons";

const Section = ({
  section,
  onSelect,
}: {
  section: AvailableDescriptorDto;
  onSelect: (desc: SelectedDescriptor) => void;
}) => {
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
        {section.prompt !==
          section.descriptors![0].prompt?.slice(
            0,
            section.descriptors![0].prompt.length - 1
          ) && <Text mt={4}>{section.prompt}</Text>}
        <Stack
          spacing={5}
          mt={4}
          maxHeight={250}
          overflowY={"auto"}
          sx={{
            "::-webkit-scrollbar": {
              display: "none",
            },
          }}
        >
          {section.descriptors?.map((descriptor) => (
            <Box key={descriptor.id}>
              <Descriptor
                descriptor={descriptor}
                availableDescriptorId={section.id!}
                onSelect={onSelect}
              />
              <br />
              <hr />
            </Box>
          ))}
        </Stack>
      </Collapse>
    </Box>
  );
};

export default Section;
