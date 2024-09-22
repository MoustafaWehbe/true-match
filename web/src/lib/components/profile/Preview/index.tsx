import { useState } from "react";
import { useSelector } from "react-redux";
import {
  ChevronDownIcon,
  ChevronLeftIcon,
  ChevronRightIcon,
  ChevronUpIcon,
} from "@chakra-ui/icons";
import {
  Box,
  Button,
  Collapse,
  Flex,
  Heading,
  IconButton,
  Image,
  Progress,
  Text,
  useColorModeValue,
  useDisclosure,
  VStack,
  Wrap,
} from "@chakra-ui/react";

import env from "~/lib/consts/env";
import { RootState } from "~/lib/state/store";
import { calculateAge } from "~/lib/utils/date/date";

const PreviewProfile = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const { availableDescriptors } = useSelector(
    (state: RootState) => state.availableDescriptor
  );
  const { isOpen, onToggle } = useDisclosure();
  const [expanded, setExpanded] = useState(false);
  const [currentImageIndex, setCurrentImageIndex] = useState(0);

  const textColor = useColorModeValue("gray.800", "white");
  const bgColor = useColorModeValue("pink.50", "gray.800");
  const sectionBgColor = useColorModeValue("white", "gray.700");

  const toggleExpand = () => {
    setExpanded(!expanded);
    onToggle();
  };

  const handleNextImage = () => {
    setCurrentImageIndex((prevIndex) => {
      return (prevIndex + 1) % (user?.media?.length || 1);
    });
  };

  const handlePrevImage = () => {
    setCurrentImageIndex((prevIndex) => {
      return (
        (prevIndex - 1 + (user?.media?.length || 1)) %
        (user?.media?.length || 1)
      );
    });
  };

  return (
    <Box
      w="full"
      maxW="md"
      mx="auto"
      borderWidth="1px"
      borderRadius="lg"
      overflow="hidden"
      bg={bgColor}
      shadow="md"
    >
      {/* Progress Bar */}
      <Box p={4} bg={bgColor}>
        <Progress
          value={((currentImageIndex + 1) / (user?.media?.length || 1)) * 100}
          colorScheme="pink"
          borderRadius="md"
          height="6px"
        />
        <Text mt={2} textAlign="center" color={textColor}>
          Image {currentImageIndex + 1} of {user?.media?.length || 1}
        </Text>
      </Box>
      {/* Profile Picture and Basic Info Section */}
      <Box position="relative">
        {/* User Image */}
        <Image
          src={env.apiUrl + "" + user?.media?.[currentImageIndex]?.url}
          alt={user?.firstName!}
          objectFit="cover"
          w="full"
          h="500px"
        />

        {/* Left Arrow */}
        <IconButton
          aria-label="Previous image"
          icon={<ChevronLeftIcon />}
          position="absolute"
          top="50%"
          left="4"
          transform="translateY(-50%)"
          onClick={handlePrevImage}
          bg="rgba(0, 0, 0, 0.6)"
          color="white"
          _hover={{ bg: "rgba(0, 0, 0, 0.8)" }}
        />

        {/* Right Arrow */}
        <IconButton
          aria-label="Next image"
          icon={<ChevronRightIcon />}
          position="absolute"
          top="50%"
          right="4"
          transform="translateY(-50%)"
          onClick={handleNextImage}
          bg="rgba(0, 0, 0, 0.6)"
          color="white"
          _hover={{ bg: "rgba(0, 0, 0, 0.8)" }}
        />

        {/* User's Name and Info Overlay */}
        <Box position="absolute" bottom="4" left="4" color="white">
          <Text fontSize="2xl" fontWeight="bold">
            {user?.firstName},{" "}
            {calculateAge(new Date(user?.userProfile?.birthDate!))}
          </Text>
          <Text>
            {user?.userProfile?.location?.fullAddress || "Unknow location"}
          </Text>
        </Box>
        <Flex
          justify="center"
          py={2}
          position={"absolute"}
          bottom="4"
          right="4"
        >
          <IconButton
            aria-label={expanded ? "Collapse profile" : "Expand profile"}
            icon={expanded ? <ChevronUpIcon /> : <ChevronDownIcon />}
            onClick={toggleExpand}
            colorScheme="pink"
          />
        </Flex>
      </Box>

      <Collapse in={isOpen} animateOpacity>
        <Box p={6} bg={sectionBgColor}>
          <VStack align="start" spacing={3} mb={6}>
            <Heading
              size="lg"
              color={textColor}
              paddingBottom={2}
              borderBottom="1px solid"
              borderColor={"pink.400"}
            >
              Basic Info
            </Heading>
            <Text color={textColor}>
              <b>Bio: </b>
              {user?.userProfile?.bio}
            </Text>
            <Text color={textColor}>
              <b>Job: </b>
              {user?.userProfile?.job}
            </Text>
            <Text color={textColor}>
              <b>School: </b>
              {user?.userProfile?.school}
            </Text>
            <Text color={textColor}>
              <b>Location: </b>
              {user?.userProfile?.location?.fullAddress}
            </Text>
          </VStack>
          {availableDescriptors?.map((avlbleDesc) => {
            const selectedDescs = user?.userProfile?.selectedDescriptors?.find(
              (sDesc) => sDesc.availableDescriptorId === avlbleDesc.id
            );
            if (selectedDescs) {
              return (
                <VStack align="start" spacing={3} mb={4} key={avlbleDesc.id}>
                  <Heading
                    size="lg"
                    color={textColor}
                    paddingBottom={2}
                    borderBottom="1px solid"
                    borderColor={"pink.400"}
                  >
                    {avlbleDesc.sectionName}
                  </Heading>
                  {avlbleDesc.descriptors?.map((desc, index) => {
                    const selectedDesc =
                      user?.userProfile?.selectedDescriptors?.find(
                        (sDesc) =>
                          sDesc.availableDescriptorId === avlbleDesc.id &&
                          sDesc.descriptorId === desc.id
                      );
                    if (selectedDesc) {
                      return (
                        <Box key={desc + "" + index}>
                          <Text color={textColor}>
                            {desc.name && <b>{desc.name} </b>}
                            <Wrap spacing={2} justify={"start"} mt={2}>
                              {selectedDesc.choicesIds?.map(
                                (choiceId, index) => {
                                  return (
                                    <Button
                                      key={choiceId + " " + index}
                                      variant={"outline"}
                                      colorScheme={"pink"}
                                      display="flex"
                                      flexDirection="column"
                                      alignItems="center"
                                      height="30px"
                                      width="auto"
                                    >
                                      <Text
                                        fontSize="sm"
                                        fontWeight="bold"
                                        whiteSpace={"normal"}
                                        overflow="hidden"
                                        textOverflow="ellipsis"
                                      >
                                        {desc?.choices?.find(
                                          (descChoice) =>
                                            descChoice.id === choiceId
                                        )?.name || ""}
                                      </Text>
                                    </Button>
                                  );
                                }
                              )}
                            </Wrap>
                          </Text>
                        </Box>
                      );
                    }
                  })}
                </VStack>
              );
            }
          })}
        </Box>
      </Collapse>
    </Box>
  );
};

export default PreviewProfile;
