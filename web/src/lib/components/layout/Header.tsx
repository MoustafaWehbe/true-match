import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  Box,
  Flex,
  Heading,
  Image,
  keyframes,
  Link,
  Stack,
  useColorModeValue,
} from "@chakra-ui/react";

import HeaderPopover from "../header/HeaderPopover";

import { AppDispatch, RootState } from "~/lib/state/store";
import { logoutUser } from "~/lib/state/user/userSlice";

const Header = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { user, logoutResponseMessage } = useSelector(
    (state: RootState) => state.user
  );

  useEffect(() => {
    if (logoutResponseMessage) {
      window.location.href = "/login";
    }
  });

  const onLogout = () => {
    dispatch(logoutUser());
  };
  const bgColor = useColorModeValue("whiteAlpha.900", "gray.700");
  const textColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const hoverColor = useColorModeValue("pink.500", "pink.300");
  const borderColor = useColorModeValue("gray.200", "gray.600");

  const bounceAnimation = keyframes`
    0%, 100% {
      transform: translateY(0);
    }
    50% {
      transform: translateY(-5px);
    }
  `;

  return (
    <Flex
      as="nav"
      p="5"
      mb="3px"
      alignItems="center"
      width="full"
      height="60px"
      justifyContent="space-between"
      bg={bgColor}
      boxShadow="rgba(0, 0, 0, 0.12) 0px 1px 1px"
      borderRadius="lg"
      border={`1px solid ${borderColor}`}
    >
      <Box animation={`${bounceAnimation} 2s infinite`}>
        <Heading
          as={Link}
          href="/"
          fontSize="1.5em"
          color={textColor}
          _hover={{ textDecoration: "none", color: hoverColor }}
        >
          <Stack direction={"row"} gap={2} justify={"center"} align={"center"}>
            <Image
              src="/true-match-logo-transparent.png"
              alt="Error 404 not found Illustration"
              width={"50px"}
              height={"50px"}
            />
            <Box as="span">TrueMatch</Box>
          </Stack>
        </Heading>
      </Box>

      {/* <Text>Title here</Text> */}

      {user && <HeaderPopover onLogout={onLogout} user={user} />}
    </Flex>
  );
};

export default Header;
