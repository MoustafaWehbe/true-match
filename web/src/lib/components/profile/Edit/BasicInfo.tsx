import {
  Box,
  FormControl,
  FormLabel,
  Textarea,
  Text,
  Input,
  useColorModeValue,
  Heading,
  Flex,
} from "@chakra-ui/react";
import { ChangeEvent, useEffect } from "react";
import { useSelector } from "react-redux";
import { RootState } from "~/lib/state/store";

export type BasicInfoType = {
  bio: string;
  job: string;
  school: string;
};

interface BasicInfoProps {
  basicFormData: BasicInfoType;
  setBasicFormData: (basicFormData: BasicInfoType) => void;
}

const BasicInfo = ({ basicFormData, setBasicFormData }: BasicInfoProps) => {
  const maxBioLength = 250;
  const { user } = useSelector((state: RootState) => state.user);

  const textColor = useColorModeValue("gray.800", "white");
  const placeholderColor = useColorModeValue("gray.500", "gray.400");
  const borderColor = useColorModeValue("gray.300", "gray.600");

  useEffect(() => {
    setBasicFormData({
      bio: user?.userProfile?.bio || "",
      job: user?.userProfile?.job || "",
      school: user?.userProfile?.school || "",
    });
  }, [setBasicFormData, user?.userProfile]);

  const handleInputChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setBasicFormData({
      ...basicFormData,
      [name as keyof BasicInfoType]: value,
    });
  };

  return (
    <Box p={5} shadow="md" borderWidth="1px" borderRadius="lg" mb="8">
      <Flex justify="space-between" align="center" cursor="pointer">
        <Heading fontSize="xl">Basic info</Heading>
      </Flex>
      <FormControl mb={4} mt={4}>
        <FormLabel color={textColor}>Bio</FormLabel>
        <Textarea
          value={basicFormData.bio}
          onChange={handleInputChange}
          placeholder="Tell us about yourself..."
          size="sm"
          maxLength={maxBioLength}
          borderColor={borderColor}
          _placeholder={{ color: placeholderColor }}
          name="bio"
        />
        <Text fontSize="sm" color={placeholderColor}>
          {basicFormData.bio.length}/{maxBioLength} characters
        </Text>
      </FormControl>

      <FormControl mb={4}>
        <FormLabel color={textColor}>Job</FormLabel>
        <Input
          name="job"
          placeholder="What do you do for a living?"
          borderColor={borderColor}
          _placeholder={{ color: placeholderColor }}
          onChange={handleInputChange}
          value={basicFormData.job}
        />
      </FormControl>

      <FormControl mb={4}>
        <FormLabel color={textColor}>School</FormLabel>
        <Input
          name="school"
          placeholder="Where did you go to school?"
          borderColor={borderColor}
          _placeholder={{ color: placeholderColor }}
          onChange={handleInputChange}
          value={basicFormData.school}
        />
      </FormControl>
    </Box>
  );
};

export default BasicInfo;
