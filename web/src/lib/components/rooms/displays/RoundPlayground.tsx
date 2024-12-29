import { FaArrowRight } from "react-icons/fa";
import { useSelector } from "react-redux";
import {
  Box,
  Button,
  Flex,
  Text,
  useColorModeValue,
  useMediaQuery,
} from "@chakra-ui/react";

import Timer from "./Timer";

import { size } from "~/lib/consts";
import { RootState } from "~/lib/state/store";

interface RoundPlaygroundProps {
  onNextQuestionClicked?: () => void;
  currentIndexForSystemQuestion: number;
  currentRound: number | null;
  isOwner: boolean;
}

const RoundPlayground = ({
  onNextQuestionClicked,
  currentIndexForSystemQuestion = 0,
  currentRound,
  isOwner,
}: RoundPlaygroundProps) => {
  const { roomContent: rounds, activeRoom } = useSelector(
    (state: RootState) => state.room
  );
  const questionBgGradient = useColorModeValue(
    "linear(to-r, teal.300, blue.500)",
    "linear(to-r, pink.500, purple.500)"
  );
  const [isLaptopOrDesktop] = useMediaQuery(`(min-width: ${size.desktop})`);

  const progressCircleThickness = isLaptopOrDesktop ? 5 : 4;
  const progressCircleSize = isLaptopOrDesktop ? 140 : 70;

  if (!rounds || currentRound === null || !rounds[currentRound]) {
    return null;
  }
  return (
    <Flex
      justifyContent={"center"}
      alignItems={{ base: "start", md: "center" }}
      gap={{ base: 2, md: 20 }}
      direction={{ base: "column-reverse", md: "row" }}
    >
      <Flex
        color="white"
        direction="column"
        align="start"
        justify="center"
        borderRadius="lg"
        maxW={"100%"}
      >
        <Flex justifyContent={"center"} alignItems={"start"} gap={2}>
          <Text fontSize={{ base: "md", lg: "3xl" }} mb={2} fontWeight={"bold"}>
            {rounds[currentRound].title}
          </Text>
        </Flex>
        <Text
          fontSize={{ base: "sm", lg: "xl" }}
          color="gray.200"
          mb={4}
          opacity={0.85}
        >
          {rounds[currentRound].description}
        </Text>
        {currentRound === 2 && activeRoom?.roomState?.roundQuestions && (
          <Box width={"100%"}>
            <Flex
              bgGradient={questionBgGradient}
              color="white"
              p={4}
              borderRadius="2xl"
              boxShadow="lg"
              textAlign="center"
              border="2px solid white"
              w="100%"
              align="center"
              justify="center"
              transform="scale(1)"
              transition="transform 0.3s ease-in-out"
              _hover={{ transform: "scale(1.05)" }}
            >
              <Text
                fontSize={{ base: "lg", md: "3xl" }}
                fontWeight="bold"
                fontStyle="italic"
                lineHeight="1.2"
              >
                {
                  activeRoom?.roomState?.roundQuestions[
                    currentIndexForSystemQuestion
                  ].name
                }
              </Text>
            </Flex>

            {isOwner && (
              <Button
                leftIcon={<FaArrowRight />}
                onClick={onNextQuestionClicked}
                colorScheme="pink"
                color="pink.200"
                variant="ghost"
                size={{ base: "sm", lg: "md" }}
                padding={0}
                mt={2}
              >
                Next question
              </Button>
            )}
          </Box>
        )}
      </Flex>
      <Box width={{ base: "100%", md: "auto" }}>
        <Timer
          progressCircleSize={progressCircleSize}
          progressCircleThickness={progressCircleThickness}
          currentRound={activeRoom?.roomState?.currentRound!}
          timer={activeRoom?.roomState?.timeRemainingForRoundBeforePause!}
        />
      </Box>
    </Flex>
  );
};
export default RoundPlayground;
