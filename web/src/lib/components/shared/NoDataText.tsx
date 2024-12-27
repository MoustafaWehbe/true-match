import { Text } from "@chakra-ui/react";

const NoDataText = ({ text }: { text: string }) => {
  return (
    <Text
      textAlign={"center"}
      fontSize={"large"}
      fontWeight={"bold"}
      color="darkgray"
      marginTop={8}
      as="p"
    >
      {text}
    </Text>
  );
};

export default NoDataText;
