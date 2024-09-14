import { Box, Text, SimpleGrid, Button, useColorMode } from "@chakra-ui/react";
import { useState } from "react";
import { Descriptor as DescriptorType } from "shared/src/types/openApiGen";

const AdvancedSingleSelection = ({
  descriptor,
}: {
  descriptor: DescriptorType;
}) => {
  const [selectedChoice, setSelectedChoice] = useState<string>();
  const { colorMode } = useColorMode();

  const handleSelect = (id: string) => {
    if (selectedChoice === id) {
      setSelectedChoice(undefined);
    } else {
      setSelectedChoice(id);
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
            p={4}
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
