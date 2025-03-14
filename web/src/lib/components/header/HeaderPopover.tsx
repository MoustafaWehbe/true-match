import React from "react";
import { CiUser } from "react-icons/ci";
import { CiSettings } from "react-icons/ci";
import { IoIosLogOut } from "react-icons/io";
import { RiMoonFill, RiSunLine } from "react-icons/ri";
import {
  Avatar,
  Box,
  Button,
  Icon,
  keyframes,
  Popover,
  PopoverArrow,
  PopoverBody,
  PopoverContent,
  PopoverFooter,
  PopoverTrigger,
  useColorMode,
  useColorModeValue,
} from "@chakra-ui/react";
import { useRouter } from "next/navigation";

import { openApiTypes } from "@truematch/shared";

type Props = {
  onLogout: () => void;
  user: openApiTypes.User;
};

const bounceAnimation = keyframes`
  0%, 100% {
    transform: translateY(0);
  }
  50% {
    transform: translateY(-5px);
  }
`;

const HeaderPopover = ({ onLogout, user }: Props) => {
  const bgColor = useColorModeValue("whiteAlpha.900", "gray.700");
  const textColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const hoverColor = useColorModeValue("pink.500", "pink.300");
  const { colorMode, toggleColorMode } = useColorMode();
  const router = useRouter();

  return (
    <Popover trigger="hover" placement="top-end">
      <PopoverTrigger>
        <Avatar
          size="sm"
          name={user.firstName!}
          backgroundColor="pink.400"
          color="white"
          cursor="pointer"
          mr="20px"
          animation={`${bounceAnimation} 2s infinite`}
        />
      </PopoverTrigger>
      <PopoverContent
        width="170px"
        bg={bgColor}
        borderColor={useColorModeValue("gray.200", "gray.600")}
        animation={`${bounceAnimation} 2s infinite`}
      >
        <PopoverArrow />
        <PopoverBody>
          <Box mt="10px">
            <Button
              aria-label="View profile"
              variant="link"
              leftIcon={<Icon as={CiUser} />}
              color={textColor}
              _hover={{ color: hoverColor }}
              onClick={() => router.push("/profile")}
            >
              View profile
            </Button>
          </Box>
          <Box mt="10px">
            <Button
              aria-label="Settings"
              variant="link"
              leftIcon={<Icon as={CiSettings} />}
              color={textColor}
              _hover={{ color: hoverColor }}
              onClick={() => router.push("/settings")}
            >
              Settings
            </Button>
          </Box>
          <Box mt="10px">
            <Button
              aria-label="theme toggle"
              variant="link"
              leftIcon={colorMode === "light" ? <RiMoonFill /> : <RiSunLine />}
              onClick={toggleColorMode}
              color={textColor}
              _hover={{ color: hoverColor }}
            >
              {colorMode === "light" ? "Dark mode" : "Light mode"}
            </Button>
          </Box>
        </PopoverBody>
        <PopoverFooter>
          <Box>
            <Button
              aria-label="Logout"
              variant="link"
              leftIcon={<Icon as={IoIosLogOut} />}
              onClick={onLogout}
              color={textColor}
              _hover={{ color: hoverColor }}
            >
              Logout
            </Button>
          </Box>
        </PopoverFooter>
      </PopoverContent>
    </Popover>
  );
};

export default HeaderPopover;
