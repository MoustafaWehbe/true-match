import { FiX } from "react-icons/fi";
import { Box, Center, Text } from "@chakra-ui/react";

import { UserDto } from "@dapp/shared/src/types/openApiGen";

import { glowingAnimation } from "~/lib/consts/styles";
import { calculateAge } from "~/lib/utils/date/date";
import { constructMediaUrl } from "~/lib/utils/url";

const UserCard = ({
  user,
  color,
  isMe,
  isOwner,
  onUserCardClicked,
  onRemoveUser,
}: {
  user: UserDto;
  color: string;
  isMe: boolean;
  isOwner: boolean;
  onUserCardClicked: (userId?: string | null) => void;
  onRemoveUser: (userId?: string | null) => void;
}) => {
  return (
    <Center
      flexDir="column"
      animation={`${glowingAnimation(color)} 2s infinite`}
      transition="transform 0.2s ease-in-out"
      _hover={{
        transform: "scale(1.1)",
        cursor: "pointer",
      }}
      onClick={() => onUserCardClicked(user.id)}
      padding={2}
    >
      <Box
        position="relative"
        bg="white"
        color={"black"}
        borderRadius="50%"
        display="flex"
        flexDir="column"
        alignItems="center"
        justifyContent="center"
        border="1px solid"
        borderColor={color}
        width={{ base: "80px", md: "100px" }}
        height={{ base: "80px", md: "100px" }}
        bgImage={`url(${constructMediaUrl(
          user?.media?.length ? user?.media[0].url : ""
        )})`}
        bgSize="cover"
        bgPosition="center"
      >
        {isOwner && (
          <Box
            position="absolute"
            rounded="full"
            zIndex={4}
            transition="transform 0.2s ease-in-out"
            _hover={{
              transform: "scale(1.2)",
              cursor: "pointer",
            }}
            onClick={(e) => {
              e.preventDefault();
              e.stopPropagation();
              onRemoveUser(user.id);
            }}
            top="-15px"
            background="white"
            border="1px solid"
            right="-16px"
            color="red.800"
          >
            <FiX size="15px" />
          </Box>
        )}
      </Box>
      <Box
        flex="1"
        display={"flex"}
        flexDir={"column"}
        justifyContent={"center"}
        width={"100%"}
        padding={"0 6px"}
        color="white"
        fontWeight={900}
        fontSize={"medium"}
      >
        <Text textTransform={"uppercase"}>
          {user?.firstName}
          {isMe && (
            <Text
              as="span"
              fontSize={"x-small"}
              fontWeight={"200"}
              textTransform={"none"}
            >
              (you)
            </Text>
          )}
        </Text>
        <Box fontWeight={600} fontSize={"small"}>
          {calculateAge(new Date(user?.userProfile?.birthDate!))}
        </Box>
      </Box>
    </Center>
  );
};

export default UserCard;
