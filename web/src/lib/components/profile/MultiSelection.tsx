import {
  Box,
  Text,
  HStack,
  Checkbox,
  Wrap,
  WrapItem,
  Button,
  useColorMode,
} from "@chakra-ui/react";
import { useState } from "react";
import { Descriptor as DescriptorType } from "shared/src/types/openApiGen";

const MultiSelection = ({ descriptor }: { descriptor: DescriptorType }) => {
  const [selectedChoices, setSelectedChoices] = useState<string[]>([]);
  const { colorMode } = useColorMode();

  const handleSelect = (id: string) => {
    const alreadySelected = selectedChoices.includes(id);
    const updatedSelections = alreadySelected
      ? selectedChoices.filter((opt) => opt !== id)
      : [...selectedChoices, id];
    setSelectedChoices(updatedSelections);
  };

  return (
    <Box>
      <Text mb={2}>{descriptor.prompt}</Text>
      <Wrap spacing={4} justify={"center"}>
        {descriptor.choices?.map((choice) => (
          <WrapItem key={choice.id} width="auto" justifyContent={"center"}>
            <Button
              key={choice.id}
              variant={
                selectedChoices.includes(choice.id!) ? "solid" : "outline"
              }
              colorScheme={"pink"}
              display="flex"
              flexDirection="column"
              alignItems="center"
              height="40px"
              width="auto"
              onClick={() => handleSelect(choice.id!)}
              _hover={{
                bg:
                  colorMode === "light"
                    ? `${choice.style}.100`
                    : `${choice.style}.900`,
              }}
            >
              <Text
                fontSize="sm"
                fontWeight="bold"
                whiteSpace={"normal"}
                overflow="hidden"
                textOverflow="ellipsis"
              >
                {choice.name}
              </Text>
            </Button>
          </WrapItem>
        ))}
      </Wrap>
      {/* <HStack spacing={4}>
        {descriptor.choices?.map((choice) => (
          <Checkbox
            key={choice.id}
            isChecked={selectedOptions.includes(choice.id!)}
            onChange={() => handleSelect(choice.id!)}
          >
            {choice.name}
          </Checkbox>
        ))}
      </HStack> */}
    </Box>
  );
};

export default MultiSelection;
