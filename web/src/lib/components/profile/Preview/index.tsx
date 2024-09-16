import {
  Box,
  Text,
  IconButton,
  Flex,
  Image,
  Collapse,
  VStack,
  Heading,
  Tag,
  SimpleGrid,
  useDisclosure,
  useColorModeValue,
  Progress,
} from "@chakra-ui/react";
import {
  ChevronDownIcon,
  ChevronLeftIcon,
  ChevronRightIcon,
  ChevronUpIcon,
} from "@chakra-ui/icons";
import { useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "~/lib/state/store";
import { urlToFile } from "~/lib/utils/file/file";
import env from "~/lib/consts/env";
import { calculateAge } from "~/lib/utils/date/date";

const PreviewProfile = () => {
  const { user } = useSelector((state: RootState) => state.user);
  const { isOpen, onToggle } = useDisclosure();
  const [expanded, setExpanded] = useState(false);
  const [images, setImages] = useState<(File | null)[]>(Array(6).fill(null));
  const [currentImageIndex, setCurrentImageIndex] = useState(0);

  const textColor = useColorModeValue("gray.800", "white");
  const bgColor = useColorModeValue("pink.50", "gray.800");
  const sectionBgColor = useColorModeValue("white", "gray.700");
  const borderColor = useColorModeValue("gray.300", "gray.600");

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

  useEffect(() => {
    const fetchImages = async () => {
      const mediaImages: File[] = [];
      await new Promise<void>((res, reject) =>
        user?.media!.forEach((item, index) => {
          urlToFile(env.apiUrl + item.url, "profile " + index, "image/jpeg")
            .then((file) => {
              mediaImages.push(file);
              if (index === user?.media?.length! - 1) {
                res();
              }
            })
            .catch((error) => {
              console.error("Error creating File:", error);
              reject(error);
            });
        })
      );
      setImages(mediaImages);
    };
    if (user?.media && user?.media.length) {
      fetchImages();
    }
  }, [user?.media]);

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
          src={env.apiUrl + "" + user?.media?.[currentImageIndex].url}
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
          <Text>{user?.userProfile?.location || "Unknow location"}</Text>
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

      {/* Collapse/Expand Button */}

      {/* Expanded Profile Info */}
      <Collapse in={isOpen} animateOpacity>
        <Box p={6} bg={sectionBgColor}>
          {/* Bio Section */}
          <VStack align="start" spacing={3} mb={6}>
            <Heading size="md" color={textColor}>
              Bio
            </Heading>
            <Text color={textColor}>
              {user?.userProfile?.bio || "No bio available"}
            </Text>
          </VStack>

          {/* Basic Info Section */}
          <VStack align="start" spacing={3} mb={6}>
            <Heading size="md" color={textColor}>
              Basic Info
            </Heading>
            <Text color={textColor}>
              Height:{" "}
              {user?.userProfile?.selectedDescriptors?.find(
                (desc) => desc.availableDescriptorId === 1
              )?.singleValue || "N/A"}
            </Text>
            <Text color={textColor}>
              Gender:{" "}
              {user?.userProfile?.userProfileGenders?.toString() || "N/A"}
            </Text>
          </VStack>

          {/* Interests Section */}
          <VStack align="start" spacing={3} mb={6}>
            <Heading size="md" color={textColor}>
              Interests
            </Heading>
            {/* <SimpleGrid columns={2} spacing={2}>
              {user?.userProfile?.interests?.map(
                (interest: string, index: number) => (
                  <Tag key={index} colorScheme="pink" size="lg">
                    {interest}
                  </Tag>
                )
              ) || <Text>No interests added</Text>}
            </SimpleGrid> */}
          </VStack>

          {/* Job and School Section */}
          <VStack align="start" spacing={3}>
            <Heading size="md" color={textColor}>
              Job & School
            </Heading>
            <Text color={textColor}>
              Job: {user?.userProfile?.job || "N/A"}
            </Text>
            <Text color={textColor}>
              School: {user?.userProfile?.school || "N/A"}
            </Text>
          </VStack>
        </Box>
      </Collapse>
    </Box>
  );
};

export default PreviewProfile;
