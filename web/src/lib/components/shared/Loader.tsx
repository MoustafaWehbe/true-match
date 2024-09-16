import { Spinner, Center, useColorModeValue } from "@chakra-ui/react";

interface LoaderProps {
  isLoading: boolean;
}

const Loader: React.FC<LoaderProps> = ({ isLoading }) => {
  const loaderColor = useColorModeValue("pink.500", "pink.300");

  return (
    <>
      {isLoading && (
        <Center
          position="absolute"
          top="0"
          left="0"
          right="0"
          bottom="0"
          zIndex="overlay"
        >
          <Spinner size="xl" color={loaderColor} />
        </Center>
      )}
    </>
  );
};

export default Loader;
