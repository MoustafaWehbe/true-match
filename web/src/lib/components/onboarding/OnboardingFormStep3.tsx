import React, { useState } from "react";
import {
  Box,
  Button,
  Heading,
  SimpleGrid,
  Text,
  useColorModeValue,
  useColorMode,
} from "@chakra-ui/react";
import { CreateOrUpdateUserProfileDto } from "@dapp/shared/src/types/openApiGen";
import { useSelector } from "react-redux";
import { RootState } from "~/lib/state/store";

interface OnboardingFormStep3Props {
  onSubmit: (
    values: Pick<CreateOrUpdateUserProfileDto, "selectedDescriptors">
  ) => void;
}

const OnboardingFormStep3 = ({ onSubmit }: OnboardingFormStep3Props) => {
  const [selectedChoice, setSelectedChoice] = useState<string>();
  const { availableDescriptors } = useSelector(
    (state: RootState) => state.availableDescriptor
  );
  const { colorMode } = useColorMode();
  const textColor = useColorModeValue("gray.600", "gray.300");

  const relationshipGoalsData = (availableDescriptors || [])[2];
  const relationshipGoalsDataDescriptors =
    (availableDescriptors || [])[2]?.descriptors || [];

  if (!relationshipGoalsData) {
    return null;
  }

  const handleNext = () => {
    if (selectedChoice) {
      onSubmit({
        selectedDescriptors: [
          {
            availableDescriptorId: relationshipGoalsData.id,
            descriptorId: relationshipGoalsDataDescriptors[0].id,
            choicesIds: [selectedChoice],
          },
        ],
      });
    }
  };

  const handleSelect = (id: string) => {
    if (selectedChoice === id) {
      setSelectedChoice(undefined);
    } else {
      setSelectedChoice(id);
    }
  };

  return (
    <Box p={6}>
      {/* Section Header */}
      <Heading size="lg" mb={2}>
        {relationshipGoalsData.sectionName}
      </Heading>
      <Text fontSize="md" color={textColor} mb={6}>
        {relationshipGoalsDataDescriptors[0].subPrompt}
      </Text>

      <SimpleGrid columns={[1, 2, 3]} spacing={4}>
        {relationshipGoalsDataDescriptors[0].choices?.map((choice) => (
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

      <Button
        mt={6}
        onClick={handleNext}
        isDisabled={!selectedChoice}
        colorScheme="teal"
      >
        Next
      </Button>
    </Box>
  );
};

export default OnboardingFormStep3;
