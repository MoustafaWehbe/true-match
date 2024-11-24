"use client";

import { BsEmojiHeartEyes } from "react-icons/bs";
import { BsChatDots } from "react-icons/bs";
import { CiUser } from "react-icons/ci";
import { MdOutlineLiveTv } from "react-icons/md";
import {
  Box,
  Heading,
  Link,
  List,
  ListIcon,
  ListItem,
  Stack,
  useColorModeValue,
} from "@chakra-ui/react";
import NextLink from "next/link";

const DrawerContent = () => {
  const bgColor = useColorModeValue("whiteAlpha.900", "gray.700");
  const headingColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const linkColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const hoverColor = useColorModeValue("pink.500", "pink.300");
  const iconColor = useColorModeValue("pink.400", "pink.200");

  return (
    <Box
      bg={bgColor}
      p={6}
      borderRadius="lg"
      boxShadow={{ base: "none", md: "xl" }}
    >
      <Stack spacing={6} align="center" mb={6}>
        <Heading fontSize="2xl" color={headingColor}>
          Menu
        </Heading>
      </Stack>
      <List fontSize="1.2em" spacing={4} color={linkColor}>
        <ListItem>
          <NextLink href="/browse-rooms" passHref prefetch={true}>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={BsEmojiHeartEyes} color={iconColor} />
              Browse rooms
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/my-rooms" passHref prefetch={true}>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={MdOutlineLiveTv} color={iconColor} />
              My rooms
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/chat" passHref prefetch={true}>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={BsChatDots} color={iconColor} />
              Chat
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/profile" passHref prefetch={true}>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={CiUser} color={iconColor} />
              Profile
            </Link>
          </NextLink>
        </ListItem>
      </List>
    </Box>
  );
};

export default DrawerContent;
