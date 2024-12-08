import { Box, Flex } from "@chakra-ui/react";

interface MyAudioProps {
  localAudioRef: React.RefObject<HTMLAudioElement>;
}

const MyAudio = ({ localAudioRef }: MyAudioProps) => {
  return (
    <>
      <Flex
        position={"absolute"}
        bottom={8}
        left={8}
        direction={"column"}
        gap={2}
        fontSize={{ base: "s", md: "lg", lg: "xl" }}
        fontWeight={"bold"}
      >
        <Box color={"white"}>You</Box>
      </Flex>
      <audio
        muted
        ref={localAudioRef}
        autoPlay
        style={{
          borderRadius: "10px",
          height: "100%",
          objectFit: "cover",
        }}
      />
    </>
  );
};
export default MyAudio;
