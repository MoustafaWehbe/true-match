import React, { useEffect, useMemo, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { ChevronDownIcon } from "@chakra-ui/icons";
import {
  Box,
  Button,
  Link,
  Modal,
  ModalBody,
  ModalContent,
  ModalFooter,
  ModalHeader,
  ModalOverlay,
  Stack,
  Text,
  useDisclosure,
} from "@chakra-ui/react";

import { openApiTypes } from "@dapp/shared";

import { getGenders } from "~/lib/state/gender/genderSlice";
import { AppDispatch, RootState } from "~/lib/state/store";

interface OnboardingFormStep2GenderProps {
  onSubmit: (
    values: Pick<
      openApiTypes.CreateOrUpdateUserProfileDto,
      "userProfileGenders"
    >
  ) => void;
}

const OnboardingFormStep2Gender = ({
  onSubmit,
}: OnboardingFormStep2GenderProps) => {
  const [selectedMainGender, setSelectedMainGender] =
    useState<openApiTypes.GenderDto>();
  const [selectedSubgenders, setSelectedSubgenders] = useState<
    openApiTypes.GenderDto[]
  >([]);
  const {
    isOpen: isAddMoreGendersOpen,
    onOpen: onAddMoreGendersOpen,
    onClose: onAddMoreGendersClose,
  } = useDisclosure();
  const { genders } = useSelector((state: RootState) => state.gender);
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    dispatch(getGenders());
  }, [dispatch]);

  const handleMainGenderSelect = (gender: openApiTypes.GenderDto) => {
    setSelectedMainGender(gender);
    setSelectedSubgenders([]);
  };

  const handleSubgenderSelect = (subgender: openApiTypes.GenderDto) => {
    setSelectedSubgenders((prev) =>
      prev.includes(subgender)
        ? prev.filter((id: any) => id !== subgender)
        : [...prev, subgender]
    );
  };

  const handleNext = () => {
    onSubmit({
      userProfileGenders: [
        { genderId: selectedMainGender?.id, isMain: true },
        ...selectedSubgenders.map((sg) => ({ genderId: sg.id, isMain: false })),
      ],
    });
  };

  const mainGenders = useMemo(
    () => genders?.filter((gender) => !gender.parentId),
    [genders]
  );

  return (
    <Box p={4}>
      <Text fontSize="lg" mb={4}>
        What is your gender?
      </Text>
      <Stack spacing={4}>
        {mainGenders?.map((gender) => (
          <Button
            key={gender.id}
            colorScheme="pink"
            variant={selectedMainGender?.id === gender.id ? "solid" : "outline"}
            onClick={() => handleMainGenderSelect(gender)}
            width="100%"
            display={"flex"}
            flexDirection={"column"}
            padding={4}
            height={"auto"}
            overflow={"hidden"}
          >
            <Box whiteSpace="normal">
              {gender.name}{" "}
              {selectedMainGender?.id === gender.id &&
                selectedSubgenders.length > 0 &&
                "(" + selectedSubgenders.map((sg) => sg.name).join(", ") + ")"}
            </Box>
            {selectedMainGender?.id === gender.id &&
              selectedMainGender?.children?.length && (
                <Box mt={2}>
                  <Link color="blue.500" onClick={onAddMoreGendersOpen}>
                    Add more about your gender <ChevronDownIcon />
                  </Link>
                </Box>
              )}
          </Button>
        ))}
      </Stack>

      <Button
        mt={6}
        onClick={handleNext}
        disabled={!selectedMainGender}
        colorScheme="teal"
      >
        Next
      </Button>

      <Modal isOpen={isAddMoreGendersOpen} onClose={onAddMoreGendersClose}>
        <ModalOverlay />
        <ModalContent>
          <ModalHeader>Add more about your gender:</ModalHeader>
          <ModalBody>
            <Stack spacing={4}>
              {selectedMainGender?.children?.map((subgender) => (
                <Button
                  key={subgender.id}
                  variant={
                    selectedSubgenders.find((sg) => sg.id === subgender.id)
                      ? "solid"
                      : "outline"
                  }
                  colorScheme="pink"
                  onClick={() => handleSubgenderSelect(subgender)}
                >
                  {subgender.name}
                </Button>
              ))}
            </Stack>
          </ModalBody>
          <ModalFooter>
            <Button colorScheme="blue" onClick={onAddMoreGendersClose}>
              Done
            </Button>
          </ModalFooter>
        </ModalContent>
      </Modal>
    </Box>
  );
};

export default OnboardingFormStep2Gender;
