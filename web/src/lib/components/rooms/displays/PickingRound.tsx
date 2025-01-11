import { useState } from "react";
import { useSelector } from "react-redux";
import { CloseIcon } from "@chakra-ui/icons";
import { Box, Flex, Grid, GridItem, Text } from "@chakra-ui/react";

import { UserDto } from "@truematch/shared/src/types/openApiGen";

import PreviewProfile from "../../profile/Preview";
import ConfirmDialog from "../../shared/ConfirmDialog";

import { RootState } from "~/lib/state/store";

const PickingRound = ({
  users,
  isOwner,
  onRemoveUser,
}: {
  users: UserDto[];
  isOwner: boolean;
  onRemoveUser: (userId?: string) => void;
}) => {
  const { roomContent } = useSelector((state: RootState) => state.room);
  const [userToBeRemoved, setUserToBeRemoved] = useState<string>();

  const onRemove = async (user: UserDto) => {
    if (!user.id) {
      return;
    } else if (users.length <= 2) {
      return;
    }
    setUserToBeRemoved(user.id);
  };

  const removeTheUser = () => {
    onRemoveUser(userToBeRemoved);
    setUserToBeRemoved(undefined);
  };

  if (!roomContent) {
    return null;
  }

  const pickRound = roomContent[roomContent.length - 2];

  return (
    <Box
      position="fixed"
      top="0"
      bottom="0"
      left="0"
      width="100vw"
      maxHeight="100vh"
      bg="rgba(0, 0, 0, 0.9)"
      zIndex="1000"
      animation="fadeIn 0.3s ease-in-out"
      sx={{
        "@keyframes fadeIn": {
          "0%": { opacity: 0 },
          "100%": { opacity: 1 },
        },
      }}
      overflowY={"auto"}
    >
      <Box textAlign={"center"} mt={10} mb={10}>
        <Text fontSize="lg" fontWeight="bold">
          {pickRound.title}
        </Text>
        <Text>{pickRound.description}</Text>
      </Box>
      <Grid
        templateColumns={{
          base: "1fr",
          md: "repeat(2, 1fr)",
          lg:
            users.length <= 2
              ? `repeat(${users.length}, 1fr)`
              : "repeat(3, 1fr)",
        }}
        gap={4}
        p={4}
        placeItems="center"
        alignItems="start"
        justifyContent={users.length <= 2 ? "center" : "start"}
      >
        {users.map((user, index) => {
          return (
            <GridItem
              key={index}
              bg="pink.100"
              borderRadius="md"
              boxShadow="md"
              p={4}
              display="flex"
              alignItems="center"
              justifyContent="center"
              width={"100%"}
            >
              <Flex
                key={index}
                direction={"column"}
                width={"100%"}
                justifyContent={"center"}
                alignItems={"center"}
                gap={4}
              >
                {isOwner && (
                  <Box
                    display="flex"
                    alignItems="center"
                    justifyContent="center"
                    position="relative"
                    w="60px"
                    h="60px"
                    borderRadius="full"
                    bg="red.500"
                    boxShadow="lg"
                    transition="all 0.3s ease-in-out"
                    _hover={{
                      bg: "red.600",
                      transform: "scale(1.1)",
                      boxShadow: "2xl",
                    }}
                    _active={{
                      transform: "scale(0.95)",
                      boxShadow: "lg",
                    }}
                    onClick={() => onRemove(user)}
                    cursor="pointer"
                  >
                    <CloseIcon
                      boxSize={6}
                      color="white"
                      transition="transform 0.2s ease-in-out"
                      _groupHover={{
                        transform: "rotate(180deg)",
                      }}
                    />
                  </Box>
                )}
                <PreviewProfile user={user} />
              </Flex>
            </GridItem>
          );
        })}
      </Grid>
      <ConfirmDialog
        isOpen={!!userToBeRemoved}
        onClose={() => setUserToBeRemoved(undefined)}
        onConfirm={removeTheUser}
        title="Remove user?"
        description="Are you sure you want to remove this user?"
        confirmText="Remove"
        cancelText="Cancel"
      />
    </Box>
  );
};

export default PickingRound;
