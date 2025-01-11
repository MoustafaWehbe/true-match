import React, { useState } from "react";
import { useSelector } from "react-redux";
import {
  Box,
  Button,
  Heading,
  Input,
  Text,
  useColorMode,
  useColorModeValue,
  Wrap,
  WrapItem,
} from "@chakra-ui/react";

import { CreateOrUpdateUserProfileDto } from "@truematch/shared/src/types/openApiGen";

import { RootState } from "~/lib/state/store";

interface OnboardingFormStep4InterestsProps {
  onSubmit: (
    values: Pick<CreateOrUpdateUserProfileDto, "selectedDescriptors">
  ) => void;
}

const OnboardingFormStep4Interests = ({
  onSubmit,
}: OnboardingFormStep4InterestsProps) => {
  const [selectedChoices, setSelectedChoices] = useState<string[]>([]);
  const { availableDescriptors } = useSelector(
    (state: RootState) => state.availableDescriptor
  );
  const { colorMode } = useColorMode();
  const textColor = useColorModeValue("gray.600", "gray.300");

  const interestsData = (availableDescriptors || [])[1];
  const interestsDataDescriptors =
    (availableDescriptors || [])[1]?.descriptors || [];
  const [searchTerm, setSearchTerm] = useState("");

  if (!interestsData) {
    return null;
  }

  const handleNext = () => {
    if (selectedChoices?.length) {
      onSubmit({
        selectedDescriptors: [
          {
            availableDescriptorId: interestsData.id,
            descriptorId: interestsDataDescriptors[0].id,
            choicesIds: [...selectedChoices],
          },
        ],
      });
    }
  };

  const handleSelect = (id: string) => {
    if (selectedChoices?.includes(id)) {
      setSelectedChoices((prev) => prev.filter((choiceId) => choiceId !== id));
    } else {
      if (
        selectedChoices.length >= interestsDataDescriptors[0].maxSelections!
      ) {
        return;
      }
      setSelectedChoices((prev) => [...prev, id]);
    }
  };

  const filteredChoices = interestsDataDescriptors[0].choices?.filter(
    (choice) => choice.name?.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  return (
    <Box p={6}>
      <Heading size="lg" mb={2}>
        {interestsData.sectionName}
      </Heading>
      <Text fontSize="md" color={textColor} mb={6}>
        {interestsData.prompt}
      </Text>
      <Input
        placeholder="Search choices"
        value={searchTerm}
        onChange={handleSearch}
        mb={4}
        variant={"flushed"}
      />
      <Wrap spacing={4} justify={"center"}>
        {filteredChoices?.map((choice) => (
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

      <Button
        mt={6}
        onClick={handleNext}
        isDisabled={
          selectedChoices.length < interestsDataDescriptors[0].minSelections!
        }
        colorScheme="teal"
      >
        Next {selectedChoices.length} /{" "}
        {interestsDataDescriptors[0].maxSelections!}
      </Button>
    </Box>
  );
};

export default OnboardingFormStep4Interests;
