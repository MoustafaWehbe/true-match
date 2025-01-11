import { Text } from "@chakra-ui/react";

const NoDataText = ({ text }: { text: string }) => (
  <Text
    textAlign={"center"}
    fontSize="medium"
    fontWeight={"bold"}
    color="darkgray"
    marginTop={8}
    as="p"
  >
    {text}
  </Text>
);

export default NoDataText;
