import { Button } from "@chakra-ui/react";

interface StartRoundProps {
  startRounds: () => void;
  isDisabled?: boolean;
}

const StartRound = ({ startRounds, isDisabled }: StartRoundProps) => {
  return (
    <Button
      colorScheme="red"
      variant="outline"
      onClick={startRounds}
      float={"right"}
      size={{ base: "sm", md: "lg" }}
      isDisabled={isDisabled}
    >
      Start Rounds
    </Button>
  );
};

export default StartRound;
