import {
  Box,
  Button,
  Flex,
  forwardRef,
  Text,
  useColorModeValue,
} from "@chakra-ui/react";
import SwipeCardCore from "./SwipeCardCore";
import { InfoIcon } from "@chakra-ui/icons";
import { sharedCardContainerStyles } from "./SwipeCard";

interface CardSwipeableProps {
  user: any;
  index: number;
  isActive: boolean;
  onCardLeftScreen: (idx: number) => void;
  handleIsExpanded: () => void;
  onSwipe: (idx: number) => void;
}

const CardSwipeable = forwardRef<CardSwipeableProps, any>(
  (
    { user, index, isActive, onCardLeftScreen, handleIsExpanded, onSwipe },
    ref
  ) => {
    const cardBg = useColorModeValue("white", "gray.700");
    const cardTextColor = useColorModeValue("gray.800", "whiteAlpha.900");

    return (
      <Box sx={sharedCardContainerStyles} style={{ zIndex: isActive ? 1 : -1 }}>
        <SwipeCardCore
          preventSwipe={["up", "down"]}
          ref={ref}
          onCardLeftScreen={() => onCardLeftScreen(index)}
          onSwipe={() => onSwipe(index)}
          style={{
            height: "100%",
          }}
          swipeRequirementType="distance"
        >
          <Box
            bg={cardBg}
            color={cardTextColor}
            boxShadow="md"
            position="relative"
            transition="height 0.3s ease-in-out"
            display="flex"
            height="100%"
            flexDirection="column"
            borderRadius="20px"
            border="1px solid transparent"
          >
            <Box
              h="80%"
              bgImage={"url(/images/default-user-image-female.jpg)"}
              bgSize="cover"
              bgPosition="center"
            />

            <Box p={4} transition="height 0.3s ease-in-out">
              <Flex justify="space-between" align="center" mb={2}>
                <Text fontWeight="bold" fontSize="xl">
                  {user.name}
                </Text>
                <Button
                  size="sm"
                  colorScheme="teal"
                  onClick={handleIsExpanded}
                  aria-label="More info"
                  variant="outline"
                >
                  <InfoIcon />
                </Button>
              </Flex>
              <Text noOfLines={2}>{"user.description"}</Text>
            </Box>
          </Box>
        </SwipeCardCore>
      </Box>
    );
  }
);

CardSwipeable.displayName = "CardSwipeable";
export default CardSwipeable;
