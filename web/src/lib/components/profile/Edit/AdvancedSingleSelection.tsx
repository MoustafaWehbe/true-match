import React, { useEffect, useMemo, useState } from "react";
import { useSelector } from "react-redux";
import { Box, Button, SimpleGrid, Text, useColorMode } from "@chakra-ui/react";

import {
  Descriptor as DescriptorType,
  SelectedDescriptor,
} from "@truematch/shared/src/types/openApiGen";

import { RootState } from "~/lib/state/store";

const AdvancedSingleSelection = ({
  descriptor,
  onSelect,
  availableDescriptorId,
}: {
  descriptor: DescriptorType;
  availableDescriptorId: number;
  onSelect: (desc: SelectedDescriptor) => void;
}) => {
  const [selectedChoice, setSelectedChoice] = useState<string>();
  const { colorMode } = useColorMode();
  const { user } = useSelector((state: RootState) => state.user);

  const existingDescValue = useMemo(
    () =>
      user?.userProfile?.selectedDescriptors?.find(
        (desc) =>
          desc.availableDescriptorId === availableDescriptorId &&
          desc.descriptorId === descriptor.id
      ),
    [
      availableDescriptorId,
      descriptor.id,
      user?.userProfile?.selectedDescriptors,
    ]
  );

  useEffect(() => {
    if (existingDescValue?.choicesIds?.length) {
      setSelectedChoice(existingDescValue?.choicesIds[0]);
    }
  }, [existingDescValue]);

  const handleSelect = (id: string) => {
    if (selectedChoice === id) {
      setSelectedChoice(undefined);
    } else {
      setSelectedChoice(id);
      onSelect({
        availableDescriptorId,
        descriptorId: descriptor.id,
        choicesIds: [id],
      });
    }
  };

  return (
    <Box>
      <Text mb={2}>{descriptor.prompt}</Text>
      <SimpleGrid columns={[1, 2, 3]} spacing={4}>
        {descriptor.choices?.map((choice) => (
          <Button
            key={choice.id}
            variant={selectedChoice === choice.id ? "solid" : "outline"}
            colorScheme={choice.style!}
            display="flex"
            flexDirection="column"
            alignItems="center"
            p={2}
            borderRadius="lg"
            height="auto"
            onClick={() => handleSelect(choice.id!)}
            _hover={{
              bg:
                colorMode === "light"
                  ? `${choice.style}.100`
                  : `${choice.style}.900`,
            }}
          >
            <Text fontSize="2xl" mt={2}>
              {choice.emoji}
            </Text>

            <Text fontSize="lg" fontWeight="bold" mt={2} whiteSpace={"normal"}>
              {choice.name}
            </Text>
          </Button>
        ))}
      </SimpleGrid>
    </Box>
  );
};

export default AdvancedSingleSelection;
