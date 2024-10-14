import { Flex, Link, Text } from "@chakra-ui/react";

const Footer = () => {
  return (
    <Flex as="footer" width="full" justifyContent="center" gap={4}>
      <Text fontSize="sm">
        <Link href="/" isExternal rel="noopener noreferrer">
          Help
        </Link>
      </Text>
      <Text fontSize="sm">
        <Link href="/" isExternal rel="noopener noreferrer">
          Privacy
        </Link>
      </Text>
      <Text fontSize="sm">
        <Link href="/" isExternal rel="noopener noreferrer">
          Terms
        </Link>
      </Text>
      <Text fontSize="sm">
        {new Date().getFullYear()} -{" "}
        <Link href="/" isExternal rel="noopener noreferrer">
          App by Moustafa
        </Link>
      </Text>
    </Flex>
  );
};

export default Footer;
