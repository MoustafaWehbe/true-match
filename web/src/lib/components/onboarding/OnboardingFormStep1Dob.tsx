import React from "react";
import {
  Box,
  Button,
  FormControl,
  FormLabel,
  Grid,
  Heading,
  Input,
  Stack,
  useColorModeValue,
} from "@chakra-ui/react";
import { useFormik } from "formik";
import * as Yup from "yup";

import { openApiTypes } from "@dapp/shared";

interface OnboardingFormStep1DobProps {
  onSubmit: (
    values: Pick<openApiTypes.CreateOrUpdateUserProfileDto, "birthDate">
  ) => void;
}

function OnboardingFormStep1Dob({ onSubmit }: OnboardingFormStep1DobProps) {
  const formik = useFormik({
    initialValues: {
      day: "",
      month: "",
      year: "",
    },
    validationSchema: Yup.object({
      day: Yup.number()
        .required("Day is required")
        .min(1, "Invalid day")
        .max(31, "Invalid day"),
      month: Yup.number()
        .required("Month is required")
        .min(1, "Invalid month")
        .max(12, "Invalid month"),
      year: Yup.number()
        .required("Year is required")
        .min(1900, "Invalid year")
        .max(new Date().getFullYear() - 18, "Invalid year"),
    }),
    onSubmit: (values) => {
      const { day, month, year } = values;
      const birthDate = new Date(`${year}-${month}-${day}`);

      onSubmit({ birthDate });
    },
  });

  const bgColor = useColorModeValue("white", "gray.700");
  const textColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const boxShadow = useColorModeValue("lg", "dark-lg");

  return (
    <Box
      p={6}
      borderRadius="md"
      boxShadow={boxShadow}
      bg={bgColor}
      maxWidth="500px"
      mx="auto"
      mt={12}
    >
      <Heading as="h2" fontSize="2xl" mb={6} color={textColor}>
        Onboarding
      </Heading>
      <form onSubmit={formik.handleSubmit}>
        <Stack spacing={6}>
          <FormControl isInvalid={!!formik.touched.day && !!formik.errors.day}>
            <FormLabel color={textColor}>Birth Day</FormLabel>
            <Grid templateColumns="repeat(3, 1fr)" gap={4}>
              <Input
                placeholder="Day"
                name="day"
                value={formik.values.day}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                color={textColor}
                bg={bgColor}
              />
              <Input
                placeholder="Month"
                name="month"
                value={formik.values.month}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                color={textColor}
                bg={bgColor}
              />
              <Input
                placeholder="Year"
                name="year"
                value={formik.values.year}
                onChange={formik.handleChange}
                onBlur={formik.handleBlur}
                color={textColor}
                bg={bgColor}
              />
            </Grid>
            {formik.touched.day && formik.errors.day && (
              <Box color="red.500" mt={2}>
                {formik.errors.day}
              </Box>
            )}
            {formik.touched.month && formik.errors.month && (
              <Box color="red.500" mt={2}>
                {formik.errors.month}
              </Box>
            )}
            {formik.touched.year && formik.errors.year && (
              <Box color="red.500" mt={2}>
                {formik.errors.year}
              </Box>
            )}
          </FormControl>
          <Button colorScheme={"teal"} type="submit">
            Next
          </Button>
        </Stack>
      </form>
    </Box>
  );
}

export default OnboardingFormStep1Dob;
