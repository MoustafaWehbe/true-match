import React from "react";
import { useFormik } from "formik";
import * as Yup from "yup";
import {
  Box,
  Button,
  FormControl,
  FormLabel,
  Input,
  Select,
  Textarea,
  Stack,
  Heading,
  FormErrorMessage,
} from "@chakra-ui/react";
import { CreateUserProfileDto } from "shared/src/types/openApiGen";

interface UserProfileFormProps {
  onSubmit: (CreateUserProfileDto: any) => void;
}

const defaultValues: CreateUserProfileDto = {
  gender: 0,
  nationality: "",
  placeToLive: "",
  bio: "",
  height: 0,
  relationshipGoal: "",
  education: "",
  zodiac: "",
  loveStyle: "",
};

const UserProfileForm = ({ onSubmit }: UserProfileFormProps) => {
  const formik = useFormik({
    initialValues: defaultValues,
    validationSchema: Yup.object({
      gender: Yup.string().required("Gender is required"),
      nationality: Yup.string().required("Nationality is required"),
      placeToLive: Yup.string().required("Place to live is required"),
      bio: Yup.string().required("Bio is required"),
      height: Yup.number()
        .required("Height is required")
        .min(100, "Height is too short")
        .max(250, "Height is too tall"),
      relationshipGoal: Yup.string().required("Relationship goal is required"),
      education: Yup.string().required("Education level is required"),
      zodiac: Yup.string().required("Zodiac sign is required"),
      loveStyle: Yup.string().required("Love style is required"),
    }),
    onSubmit: (values) => {
      onSubmit(values);
    },
  });
  return (
    <Box>
      <Heading textAlign="center" mb={6}>
        Complete Your Profile
      </Heading>
      <form onSubmit={formik.handleSubmit}>
        <Stack spacing={4}>
          <FormControl
            isInvalid={!!(formik.touched.gender && formik.errors.gender)}
          >
            <FormLabel>Gender</FormLabel>
            <Select
              id="gender"
              name="gender"
              onChange={formik.handleChange}
              value={formik.values.gender}
            >
              <option value="">Select Gender</option>
              <option value="Male">Male</option>
              <option value="Female">Female</option>
              <option value="Other">Other</option>
            </Select>
            {formik.touched.gender && formik.errors.gender && (
              <FormErrorMessage>{formik.errors.gender}</FormErrorMessage>
            )}
          </FormControl>

          <FormControl
            isInvalid={
              !!(formik.touched.nationality && formik.errors.nationality)
            }
          >
            <FormLabel>Nationality</FormLabel>
            <Input
              id="nationality"
              name="nationality"
              onChange={formik.handleChange}
              value={formik.values.nationality}
            />
            {formik.touched.nationality && formik.errors.nationality && (
              <FormErrorMessage>{formik.errors.nationality}</FormErrorMessage>
            )}
          </FormControl>

          <FormControl
            isInvalid={
              !!(formik.touched.placeToLive && formik.errors.placeToLive)
            }
          >
            <FormLabel>Place to Live</FormLabel>
            <Input
              id="placeToLive"
              name="placeToLive"
              onChange={formik.handleChange}
              value={formik.values.placeToLive}
            />
            {formik.touched.placeToLive && formik.errors.placeToLive && (
              <FormErrorMessage>{formik.errors.placeToLive}</FormErrorMessage>
            )}
          </FormControl>

          <FormControl isInvalid={!!(formik.touched.bio && formik.errors.bio)}>
            <FormLabel>Bio</FormLabel>
            <Textarea
              id="bio"
              name="bio"
              onChange={formik.handleChange}
              value={formik.values.bio}
            />
            {formik.touched.bio && formik.errors.bio && (
              <FormErrorMessage>{formik.errors.bio}</FormErrorMessage>
            )}
          </FormControl>

          <FormControl
            isInvalid={!!(formik.touched.height && formik.errors.height)}
          >
            <FormLabel>Height</FormLabel>
            <Input
              type="number"
              id="height"
              name="height"
              onChange={formik.handleChange}
              value={formik.values.height}
            />
            {formik.touched.height && formik.errors.height && (
              <FormErrorMessage>{formik.errors.height}</FormErrorMessage>
            )}
          </FormControl>

          <FormControl
            isInvalid={
              !!(
                formik.touched.relationshipGoal &&
                formik.errors.relationshipGoal
              )
            }
          >
            <FormLabel>Relationship Goal</FormLabel>
            <Select
              id="relationshipGoal"
              name="relationshipGoal"
              onChange={formik.handleChange}
              value={formik.values.relationshipGoal}
            >
              <option value="">Select Relationship Goal</option>
              <option value="Serious Relationship">Serious Relationship</option>
              <option value="Casual Relationship">Casual Relationship</option>
              <option value="Friendship">Friendship</option>
            </Select>
            {formik.touched.relationshipGoal &&
              formik.errors.relationshipGoal && (
                <FormErrorMessage>
                  {formik.errors.relationshipGoal}
                </FormErrorMessage>
              )}
          </FormControl>

          <FormControl
            isInvalid={!!(formik.touched.education && formik.errors.education)}
          >
            <FormLabel>Education</FormLabel>
            <Input
              id="education"
              name="education"
              onChange={formik.handleChange}
              value={formik.values.education}
            />
            {formik.touched.education && formik.errors.education && (
              <FormErrorMessage>{formik.errors.education}</FormErrorMessage>
            )}
          </FormControl>

          <FormControl
            isInvalid={!!(formik.touched.zodiac && formik.errors.zodiac)}
          >
            <FormLabel>Zodiac Sign</FormLabel>
            <Input
              id="zodiac"
              name="zodiac"
              onChange={formik.handleChange}
              value={formik.values.zodiac}
            />
            {formik.touched.zodiac && formik.errors.zodiac && (
              <FormErrorMessage>{formik.errors.zodiac}</FormErrorMessage>
            )}
          </FormControl>

          <FormControl
            isInvalid={!!(formik.touched.loveStyle && formik.errors.loveStyle)}
          >
            <FormLabel>Love Style</FormLabel>
            <Input
              id="loveStyle"
              name="loveStyle"
              onChange={formik.handleChange}
              value={formik.values.loveStyle}
            />
            {formik.touched.loveStyle && formik.errors.loveStyle && (
              <FormErrorMessage>{formik.errors.loveStyle}</FormErrorMessage>
            )}
          </FormControl>

          <Button type="submit" colorScheme="pink">
            Next
          </Button>
        </Stack>
      </form>
    </Box>
  );
};

export default UserProfileForm;
