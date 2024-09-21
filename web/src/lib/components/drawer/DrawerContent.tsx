import { BsEmojiHeartEyes } from "react-icons/bs";
import { BsChatDots } from "react-icons/bs";
import { GrSchedulePlay } from "react-icons/gr";
import { MdOutlineLiveTv } from "react-icons/md";
import { RiCalendarScheduleLine } from "react-icons/ri";
import { useSelector } from "react-redux";
import {
  Avatar,
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

import { RootState } from "~/lib/state/store";

const DrawerContent = () => {
  const bgColor = useColorModeValue("whiteAlpha.900", "gray.700");
  const headingColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const linkColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const hoverColor = useColorModeValue("pink.500", "pink.300");
  const iconColor = useColorModeValue("pink.400", "pink.200");

  const { user } = useSelector((state: RootState) => state.user);

  return (
    <Box bg={bgColor} p={6} borderRadius="lg" boxShadow="xl">
      <Stack spacing={6} align="center" mb={6}>
        <Heading fontSize="2xl" color={headingColor}>
          Menu
        </Heading>
      </Stack>
      <List fontSize="1.2em" spacing={4} color={linkColor}>
        <ListItem>
          <NextLink href="/swipe-to-match" passHref>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={RiCalendarScheduleLine} color={iconColor} />
              Swipe to match
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/browse-rooms" passHref>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={MdOutlineLiveTv} color={iconColor} />
              Browse rooms
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/my-rooms" passHref>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={GrSchedulePlay} color={iconColor} />
              My rooms
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/matches" passHref>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={BsEmojiHeartEyes} color={iconColor} />
              Matches
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/chat" passHref>
            <Link _hover={{ textDecoration: "none", color: hoverColor }}>
              <ListIcon as={BsChatDots} color={iconColor} />
              Chat
            </Link>
          </NextLink>
        </ListItem>
        <ListItem>
          <NextLink href="/profile" passHref>
            <Link
              display="flex"
              alignItems="center"
              _hover={{ textDecoration: "none", color: hoverColor }}
            >
              <Avatar
                size={"xs"}
                name={user?.firstName!}
                backgroundColor="pink.500"
                color={"white"}
                cursor={"pointer"}
                mr="20px"
              />
              Profile
            </Link>
          </NextLink>
        </ListItem>
      </List>
    </Box>
  );
};

export default DrawerContent;
