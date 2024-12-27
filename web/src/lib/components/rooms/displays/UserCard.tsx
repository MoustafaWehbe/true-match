import { Avatar, Box, Center, Text } from "@chakra-ui/react";

import { UserDto } from "@dapp/shared/src/types/openApiGen";

import { glowingAnimation } from "~/lib/consts/styles";
import { calculateAge } from "~/lib/utils/date/date";
import { constructMediaUrl } from "~/lib/utils/url";

const UserCard = ({
  user,
  color,
  isMe,
}: {
  user: UserDto;
  color: string;
  isMe: boolean;
}) => {
  return (
    <Center flexDir="column">
      <Box
        position="relative"
        bg="white"
        color={"black"}
        fontWeight={900}
        borderRadius="10px"
        display="flex"
        flexDir="column"
        alignItems="center"
        justifyContent="center"
        border="2px solid"
        borderColor={color}
        width={{ base: "85px", md: "100px" }}
        height={{ base: "85px", md: "100px" }}
      >
        <Box
          position="absolute"
          rounded="full"
          p={2}
          bg={"rgba(0, 128, 255, 0.1)"}
          animation={`${glowingAnimation(color)} 2s infinite`}
          top={{ base: -10, md: "-55" }}
          left={0}
          zIndex={4}
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

        <Box
          flex="1"
          display={"flex"}
          flexDir={"column"}
          justifyContent={"center"}
          width={"100%"}
          padding={"0 6px"}
          marginTop={"20px"}
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
          <Box>{calculateAge(new Date(user?.userProfile?.birthDate!))}</Box>
        </Box>
      </Box>
    </Center>
  );
};

export default UserCard;
