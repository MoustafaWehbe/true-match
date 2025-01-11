import React, { useEffect, useMemo, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Box, Button, Stack, Text } from "@chakra-ui/react";

import { openApiTypes } from "@truematch/shared";

import { getGenders } from "~/lib/state/gender/genderSlice";
import { AppDispatch, RootState } from "~/lib/state/store";

interface OnboardingFormStep2GenderProps {
  onSubmit: (
    values: Pick<
      openApiTypes.CreateOrUpdateUserProfileDto,
      "userProfileGenderPreferences"
    >
  ) => void;
}

const OnboardingFormStep2Gender = ({
  onSubmit,
}: OnboardingFormStep2GenderProps) => {
  const [genderPreferences, setGenderPreferences] = useState<string[]>([]);

  const { genders } = useSelector((state: RootState) => state.gender);
  const dispatch = useDispatch<AppDispatch>();

  useEffect(() => {
    dispatch(getGenders());
  }, [dispatch]);

  const handleMainGenderSelect = (id: string) => {
    setGenderPreferences((prev) =>
      prev.includes(id)
        ? prev.filter((genderId) => genderId !== id)
        : [...prev, id]
    );
  };

  const handleNext = () => {
    onSubmit({
      userProfileGenderPreferences: genderPreferences,
    });
  };

  const mainGenders = useMemo(
    () => genders?.filter((gender) => !gender.parentId),
    [genders]
  );

  return (
    <Box p={4}>
      <Text fontSize="lg" mb={4}>
        Gender Preferences{" "}
        <Text as="span" fontSize={"small"}>
          (select one or more options)
        </Text>
      </Text>
      <Stack spacing={4}>
        {mainGenders?.map((gender) => (
          <Button
            key={gender.id}
            colorScheme="pink"
            variant={
              genderPreferences.includes(gender.id!) ? "solid" : "outline"
            }
            onClick={() => handleMainGenderSelect(gender?.id!)}
            width="100%"
            display={"flex"}
            flexDirection={"column"}
            padding={4}
            height={"auto"}
            overflow={"hidden"}
            boxSizing="border-box"
            borderWidth={"1px"}
          >
            <Box whiteSpace="normal">{gender.name}</Box>
          </Button>
        ))}
      </Stack>

      <Button
        mt={6}
        onClick={handleNext}
        isDisabled={genderPreferences.length === 0}
        colorScheme="teal"
      >
        Next
      </Button>
    </Box>
  );
};

export default OnboardingFormStep2Gender;
