import {
  Box,
  Button,
  Image,
  Text,
  useColorMode,
  VStack,
} from "@chakra-ui/react";
import { useState } from "react";
import { CreateOrUpdateUserProfileDto } from "shared/src/types/openApiGen";

interface OnboardingLocationAccessProps {
  onSubmit: (values: Pick<CreateOrUpdateUserProfileDto, "pos">) => void;
}

const OnboardingLocationAccess = ({
  onSubmit,
}: OnboardingLocationAccessProps) => {
  const { colorMode } = useColorMode();
  const [locationAccessGranted, setLocationAccessGranted] = useState(false);

  const requestLocationAccess = () => {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(
        (position) => {
          setLocationAccessGranted(true);
          console.log("Location Accessed:", position);
          const { latitude, longitude } = position.coords;

          const point: any = {
            type: "Point",
            coordinates: [longitude, latitude],
          };
          onSubmit({ pos: point });
        },
        (error) => {
          console.error("Location Access Denied", error);
        }
      );
    } else {
      alert("Geolocation is not supported by this browser.");
    }
  };

  return (
    <Box
      w="100%"
      h="100vh"
      display="flex"
      justifyContent="center"
      alignItems="center"
    >
      <VStack
        spacing={8}
        textAlign="center"
        p={8}
        borderRadius="md"
        boxShadow="lg"
        bg={colorMode === "light" ? "white" : "gray.700"}
        maxW="md"
      >
        <Text fontSize="2xl" fontWeight="bold">
          We Need Your Location!
        </Text>
        <Text
          fontSize="lg"
          color={colorMode === "light" ? "gray.600" : "gray.300"}
        >
          Please allow us to access your location to improve your experience.
          This will help us show nearby matches.
        </Text>

        <Image
          src="/images/location-access.jpg"
          alt="Location Access Illustration"
          boxSize="250px"
          objectFit="cover"
          rounded={"50%"}
        />

        {!locationAccessGranted ? (
          <Button colorScheme="teal" onClick={requestLocationAccess}>
            Allow Location Access
          </Button>
        ) : (
          <Text fontSize="lg" fontWeight="medium" color="green.500">
            Location access granted! You can start meeting new people ;)
          </Text>
        )}
      </VStack>
    </Box>
  );
};

export default OnboardingLocationAccess;
