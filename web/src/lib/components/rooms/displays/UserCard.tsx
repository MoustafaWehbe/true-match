import { FiX } from "react-icons/fi";
import { Avatar, Box, Center, Text } from "@chakra-ui/react";

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
    <Center flexDir="column">
      <Box
        position="relative"
        bg="white"
        color={"black"}
        borderRadius="10px"
        display="flex"
        flexDir="column"
        alignItems="center"
        justifyContent="center"
        border="1px solid"
        borderColor={color}
        width={{ base: "85px", md: "100px" }}
        height={{ base: "85px", md: "100px" }}
      >
        <Box
          position="absolute"
          rounded="full"
          bg={"rgba(0, 128, 255, 0.1)"}
          animation={`${glowingAnimation(color)} 2s infinite`}
          top={{ base: -10, md: "-55" }}
          left={0}
          zIndex={4}
          transition="transform 0.2s ease-in-out"
          _hover={{
            transform: "scale(1.1)",
            cursor: "pointer",
          }}
          onClick={() => onUserCardClicked(user.id)}
        >
          <Avatar
            src={constructMediaUrl(
              user?.media?.length ? user?.media[0].url : ""
            )}
            size={{ base: "md", md: "lg" }}
            name={user.firstName!}
            borderWidth="2px"
          />
        </Box>

        {isOwner && (
          <Box
            position="absolute"
            rounded="full"
            zIndex={4}
            transition="transform 0.2s ease-in-out"
            _hover={{
              transform: "scale(1.1)",
              cursor: "pointer",
            }}
            onClick={() => onRemoveUser(user.id)}
            top="-10px"
            background="white"
            border="1px solid"
            right="-6px"
            color="red"
          >
            <FiX size="15px" />
          </Box>
        )}
        <Box
          flex="1"
          display={"flex"}
          flexDir={"column"}
          justifyContent={"center"}
          width={"100%"}
          padding={"0 6px"}
          marginTop={"20px"}
          color={"grey"}
          fontWeight={600}
          fontSize={"medium"}
        >
          <Text textTransform={"uppercase"}>{user?.firstName}</Text>
          {isMe && (
            <Text
              fontSize={"x-small"}
              fontWeight={"100"}
              textTransform={"none"}
            >
              (you)
            </Text>
          )}
          <Box fontWeight={600} fontSize={"small"}>
            {calculateAge(new Date(user?.userProfile?.birthDate!))}
          </Box>
        </Box>
      </Box>
    </Center>
  );
};

export default UserCard;
