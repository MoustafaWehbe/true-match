import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  Box,
  Button,
  Flex,
  Grid,
  GridItem,
  Text,
  useToast,
} from "@chakra-ui/react";
import { useRouter } from "next/navigation";

import { UserDto } from "@dapp/shared/src/types/openApiGen";

import PreviewProfile from "../../profile/Preview";

import { CHAT_MATCH_ID_QUERY_PARAM } from "~/lib/consts";
import { createMatch } from "~/lib/state/match/matchSlice";
import { AppDispatch, RootState } from "~/lib/state/store";

const FinalRound = ({
  users,
  isOwner,
}: {
  users: UserDto[];
  isOwner: boolean;
}) => {
  const dispatch = useDispatch<AppDispatch>();
  const toast = useToast();
  const router = useRouter();
  const { matchFromCreate } = useSelector((state: RootState) => state.match);
  const { roomContent } = useSelector((state: RootState) => state.room);

  useEffect(() => {
    if (matchFromCreate?.id) {
      setTimeout(() => {
        router.push(`/chat?${CHAT_MATCH_ID_QUERY_PARAM}=${matchFromCreate.id}`);
      }, 1000);
    }
  }, [matchFromCreate, router]);

  const onSelect = async (user: UserDto) => {
    if (!user.id) {
      return;
    }
    const res = await dispatch(
      createMatch({
        origin: 0,
        user2Id: user.id,
      })
    );
    if (res.meta.requestStatus !== "rejected") {
      toast({
        title: "Congrats!",
        description: `You matched with ${user.firstName}`,
        status: "success",
        duration: 5000,
        isClosable: true,
      });
    } else {
      toast({
        title: "Failed",
        description: `An error occured while matching with ${user.firstName}`,
        status: "error",
        duration: 5000,
        isClosable: true,
      });
    }
  };

  if (!roomContent) {
    return null;
  }

  const finalRound = roomContent[roomContent.length - 1];

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
          {finalRound.title}
        </Text>
        <Text>{finalRound.description}</Text>
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
                  <Button
                    onClick={() => onSelect(user)}
                    mt="6"
                    w="70%"
                    maxW={"300px"}
                    bg="pink.600"
                    color="white"
                    borderRadius="full"
                    position="relative"
                    overflow="hidden"
                    _hover={{
                      bg: "pink.500",
                      transform: "scale(1.1)",
                    }}
                    _active={{
                      bg: "pink.600",
                      transform: "scale(0.95)",
                    }}
                    transition="all 0.2s ease-in-out"
                    sx={{
                      "&::before, &::after": {
                        content: '""',
                        position: "absolute",
                        top: "60%",
                        left: "90%",
                        width: "100%",
                        height: "100%",
                        borderRadius: "50%",
                        opacity: 0,
                        pointerEvents: "none",
                        animation: "sparkle 1s infinite",
                      },
                      "&::before": {
                        content: '"🌟"',
                        fontSize: "30px",
                        transform: "translate(-50%, -50%)",
                        animation: "sparkleStars 1s infinite",
                      },
                      "&::after": {
                        content: '"💖"',
                        fontSize: "25px",
                        transform: "translate(-50%, -50%)",
                        animation: "sparkleHearts 1.5s infinite",
                      },
                      "&:hover::before, &:hover::after": {
                        opacity: 1,
                      },
                      "@keyframes sparkleStars": {
                        "0%": {
                          opacity: 0.3,
                          transform: "translate(-50%, -50%) scale(1)",
                        },
                        "50%": {
                          opacity: 1,
                          transform: "translate(-50%, -50%) scale(1.3)",
                        },
                        "100%": {
                          opacity: 0.3,
                          transform: "translate(-50%, -50%) scale(1)",
                        },
                      },
                      "@keyframes sparkleHearts": {
                        "0%": {
                          opacity: 0.3,
                          transform: "translate(-50%, -50%) scale(1)",
                        },
                        "50%": {
                          opacity: 1,
                          transform: "translate(-50%, -50%) scale(1.2)",
                        },
                        "100%": {
                          opacity: 0.3,
                          transform: "translate(-50%, -50%) scale(1)",
                        },
                      },
                      "@keyframes sparkle": {
                        "0%": { opacity: 0.1 },
                        "50%": { opacity: 1 },
                        "100%": { opacity: 0.1 },
                      },
                    }}
                  >
                    Match
                  </Button>
                )}
                <PreviewProfile user={user} />
              </Flex>
            </GridItem>
          );
        })}
      </Grid>
    </Box>
  );
};

export default FinalRound;
