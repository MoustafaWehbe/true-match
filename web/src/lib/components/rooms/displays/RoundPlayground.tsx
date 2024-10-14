import { FaArrowRight } from "react-icons/fa";
import { useSelector } from "react-redux";
import { Box, Button, Flex, Text } from "@chakra-ui/react";

import { RootState } from "~/lib/state/store";

interface RoundPlaygroundProps {
  onNextQuestionClicked: () => void;
  currentIndexForSystemQuestion: number;
  currentRound: number | null;
}

const RoundPlayground = ({
  onNextQuestionClicked,
  currentIndexForSystemQuestion,
  currentRound,
}: RoundPlaygroundProps) => {
  const { roomContent: rounds } = useSelector((state: RootState) => state.room);
  const { systemQuestions } = useSelector((state: RootState) => state.question);

  if (!rounds || currentRound === null || !rounds[currentRound]) {
    return null;
  }
  return (
    <Flex
      top="0"
      left="0"
      color="white"
      direction="column"
      align="start"
      justify="center"
      p={4}
      borderRadius="lg"
      maxWidth={"75%"}
    >
      <Flex justifyContent={"center"} alignItems={"start"} gap={2}>
        <Text fontSize={{ base: "md", lg: "2xl" }} mb={2}>
          {rounds[currentRound].title}
        </Text>
        {currentRound === 2 && systemQuestions && (
          <Button
            float={"right"}
            leftIcon={<FaArrowRight />}
            onClick={onNextQuestionClicked}
            colorScheme="blue"
            color="blue.200"
            variant="ghost"
            size={{ base: "sm", lg: "md" }}
          >
            Next question
          </Button>
        )}
      </Flex>
      <Text fontSize={{ base: "sm", lg: "md" }} mb={4}>
        {rounds[currentRound].description}
      </Text>
      {currentRound === 2 && systemQuestions && (
        <Box width={"100%"}>
          <Text mb={2}>
            {systemQuestions[currentIndexForSystemQuestion].name}
          </Text>
        </Box>
      )}
    </Flex>
  );
};
export default RoundPlayground;
