"use client";

import { BsEmojiHeartEyes } from "react-icons/bs";
import { BsChatDots } from "react-icons/bs";
import { CiSettings, CiUser } from "react-icons/ci";
import { MdHistory } from "react-icons/md";
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
import { usePathname } from "next/navigation";

const DrawerContent = () => {
  const bgColor = useColorModeValue("whiteAlpha.900", "gray.700");
  const headingColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const linkColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const activeColor = useColorModeValue("pink.500", "pink.300");
  const hoverColor = useColorModeValue("pink.500", "pink.300");
  const iconColor = useColorModeValue("pink.400", "pink.200");
  const activeIconColor = useColorModeValue("pink.600", "pink.400");
  const pathname = usePathname();

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
            <Link
              _hover={{ textDecoration: "none", color: hoverColor }}
              color={pathname === "/browse-rooms" ? activeColor : linkColor}
            >
              <ListIcon
                as={BsEmojiHeartEyes}
                color={
                  pathname === "/browse-rooms" ? activeIconColor : iconColor
                }
              />
              Browse rooms
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/my-rooms" passHref prefetch={true}>
            <Link
              _hover={{ textDecoration: "none", color: hoverColor }}
              color={pathname === "/my-rooms" ? activeColor : linkColor}
            >
              <ListIcon
                as={MdOutlineLiveTv}
                color={pathname === "/my-rooms" ? activeIconColor : iconColor}
              />
              My rooms
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/rooms-history" passHref prefetch={true}>
            <Link
              _hover={{ textDecoration: "none", color: hoverColor }}
              color={pathname === "/rooms-history" ? activeColor : linkColor}
            >
              <ListIcon
                as={MdHistory}
                color={
                  pathname === "/rooms-history" ? activeIconColor : iconColor
                }
              />
              History
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/chat" passHref prefetch={true}>
            <Link
              _hover={{ textDecoration: "none", color: hoverColor }}
              color={pathname === "/chat" ? activeColor : linkColor}
            >
              <ListIcon
                as={BsChatDots}
                color={pathname === "/chat" ? activeIconColor : iconColor}
              />
              Chat
            </Link>
          </NextLink>
        </ListItem>
        <hr />
        <ListItem>
          <NextLink href="/profile" passHref prefetch={true}>
            <Link
              _hover={{ textDecoration: "none", color: hoverColor }}
              color={pathname === "/profile" ? activeColor : linkColor}
            >
              <ListIcon
                as={CiUser}
                color={pathname === "/profile" ? activeIconColor : iconColor}
              />
              Profile
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/settings" passHref prefetch={true}>
            <Link
              _hover={{ textDecoration: "none", color: hoverColor }}
              color={pathname === "/settings" ? activeColor : linkColor}
            >
              <ListIcon
                as={CiSettings}
                color={pathname === "/settings" ? activeIconColor : iconColor}
              />
              Settings
            </Link>
          </NextLink>
        </ListItem>
      </List>
    </Box>
  );
};

export default DrawerContent;
