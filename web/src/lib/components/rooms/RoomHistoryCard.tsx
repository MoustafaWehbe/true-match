import { useState } from "react";
import { FiMoreVertical } from "react-icons/fi";
import { useSelector } from "react-redux";
import { CalendarIcon, ChevronDownIcon, ChevronUpIcon } from "@chakra-ui/icons";
import {
  Box,
  Button,
  Flex,
  Icon,
  IconButton,
  Popover,
  PopoverArrow,
  PopoverBody,
  PopoverContent,
  PopoverTrigger,
  Stack,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
import { format } from "date-fns";

import { RoomDto } from "@truematch/shared/src/types/openApiGen";

import PreviewProfileModal from "../profile/Preview/PreviewProfileModal";

import { RootState } from "~/lib/state/store";

interface RoomHistoryCardProps {
  room: RoomDto;
}

const RoomHistoryCard = ({ room }: RoomHistoryCardProps) => {
  const cardBg = useColorModeValue("white", "gray.700");
  const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const currentUser = useSelector((state: RootState) => state.user.user);
  const [isPreviewProfileModalOpen, setIsPreviewProfileModalOpen] =
    useState(false);

  const [isDescriptionExpanded, setIsDescriptionExpanded] = useState(false);

  const toggleExpand = () => {
    setIsDescriptionExpanded((prev) => !prev);
  };

  const isOwner = currentUser && currentUser.id === room?.user?.id;

  const handleViewProfile = () => {
    setIsPreviewProfileModalOpen(true);
  };

  const handleClosePreviewProfileModal = () => {
    setIsPreviewProfileModalOpen(false);
  };

  const moreOptionsBgColor = useColorModeValue("whiteAlpha.900", "gray.700");
  const moreOptionsTextColor = useColorModeValue("gray.800", "whiteAlpha.900");
  const moreOptionsHoverColor = useColorModeValue("pink.500", "pink.300");

  return (
    <Box
      role="group"
      bg={cardBg}
      color={cardTextColor}
      borderRadius="lg"
      boxShadow="lg"
      height={330}
      transition="transform 0.2s"
      _hover={{ transform: "scale(1.05)", cursor: "pointer", opacity: 0.9 }}
      position={"relative"}
      display={"flex"}
      flexDirection={"column"}
      gap={0}
      overflowY={"auto"}
      css={{
        "&::-webkit-scrollbar": {
          width: "0px",
        },
        scrollbarWidth: "none",
      }}
    >
      <Flex
        direction={"column"}
        paddingTop={2}
        paddingLeft={6}
        paddingBottom={2}
        gap={4}
        background={"linear-gradient(45deg, gray, transparent)"}
      >
        <Flex justifyContent={"space-between"} alignItems={"center"}>
          <Text
            fontWeight="bold"
            fontSize={"medium"}
            sx={{
              textOverflow: "ellipsis",
              overflow: "hidden",
              lineClamp: "2",
              display: "-webkit-box",
              "-webkit-box-orient": "vertical",
              "-webkit-line-clamp": "1",
            }}
          >
            {room.title}
          </Text>
          {!isOwner && (
            <Popover trigger="click" placement="top-end">
              <PopoverTrigger>
                <Button
                  as={IconButton}
                  aria-label="Options"
                  icon={<FiMoreVertical />}
                  variant="ghost"
                  bg="transparent"
                  _hover={{ bg: "transparent" }}
                  height={"auto"}
                  width={"fit-content"}
                  padding={0}
                />
              </PopoverTrigger>
              <PopoverContent bg={moreOptionsBgColor} width={"auto"}>
                <PopoverArrow />
                <PopoverBody
                  display={"flex"}
                  flexDir={"column"}
                  width={"fit-content"}
                  alignItems={"start"}
                >
                  <Button
                    aria-label="view user"
                    variant="link"
                    onClick={handleViewProfile}
                    color={moreOptionsTextColor}
                    _hover={{ color: moreOptionsHoverColor }}
                    cursor={"pointer"}
                    mt="10px"
                  >
                    View profile
                  </Button>
                </PopoverBody>
              </PopoverContent>
            </Popover>
          )}
        </Flex>
        <Text fontSize={"small"} mt={"-10px"}>
          by {room.user?.firstName} {room.user?.lastName}
        </Text>
      </Flex>
      <Box
        minHeight={"35%"}
        bgImage={"url(/images/default-user-image-female.jpg)"}
        bgSize="cover"
        bgPosition="center"
      />
      <Button
        position="absolute"
        top="35%"
        left="50%"
        transform="translate(-50%, -50%)"
        size="sm"
        colorScheme="teal"
        transition="opacity 0.2s ease-in-out"
        onClick={handleViewProfile}
        opacity={0}
        _groupHover={{ opacity: 1 }}
      >
        View Profile
      </Button>
      <Box p={6} flex={8}>
        <Stack justifyContent={"space-between"}>
          <Box>
            <Text as="label" fontSize={"small"}>
              Room description
            </Text>
            <Flex
              alignItems="start"
              onClick={toggleExpand}
              cursor="pointer"
              position="relative"
            >
              <Text
                fontSize={{ base: "small", md: "medium" }}
                sx={{
                  textOverflow: isDescriptionExpanded ? "unset" : "ellipsis",
                  overflow: isDescriptionExpanded ? "unset" : "hidden",
                  display: isDescriptionExpanded ? "block" : "-webkit-box",
                  "-webkit-box-orient": "vertical",
                  "-webkit-line-clamp": isDescriptionExpanded ? "unset" : "1",
                  whiteSpace: isDescriptionExpanded ? "normal" : "nowrap",
                  cursor: "pointer",
                }}
                title={
                  !isDescriptionExpanded
                    ? "Click to expand"
                    : "Click to collapse"
                }
                userSelect={"none"}
              >
                {room.description}
              </Text>
              <Icon
                as={isDescriptionExpanded ? ChevronUpIcon : ChevronDownIcon}
                ml={2}
                boxSize={5}
                color="gray.500"
              />
            </Flex>
          </Box>
          <Box>
            <Text as="label" fontSize={"small"}>
              Scheduled at
            </Text>
            <Stack direction="row" align="center">
              <CalendarIcon fontSize={"x-small"} />
              <Text fontSize={{ base: "small", md: "medium" }}>
                {format(new Date(room.scheduledAt!), "MMMM do, yyyy h:mm a")}
              </Text>
            </Stack>
          </Box>
        </Stack>
      </Box>

      {isPreviewProfileModalOpen && (
        <PreviewProfileModal
          isOpen={isPreviewProfileModalOpen}
          onClose={handleClosePreviewProfileModal}
          userId={room.user?.id!}
        />
      )}
    </Box>
  );
};

export default RoomHistoryCard;
