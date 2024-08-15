"use client";

import { Box, Flex, IconButton } from "@chakra-ui/react";
import SwipeCard from "./SwipeCard";
import { createRef, useMemo, useRef, useState } from "react";
import { CloseIcon } from "@chakra-ui/icons";
import { FaHeart, FaUndoAlt } from "react-icons/fa";

const Swipe = () => {
  const users = [
    { name: "moustafa wehbe", bio: "Love hiking and outdoor adventures." },
    { name: "mohamad", bio: "A foodie at heart and a coffee addict." },
    { name: "Salam salama", bio: "Welll not sure yet about this one" },
    { name: "haidar haidoura", bio: "I do not work, I am a princes" },
  ];
  const [currentIndex, setCurrentIndex] = useState(users.length - 1);

  const currentIndexRef = useRef(currentIndex);

  const updateCurrentIndex = (val) => {
    setCurrentIndex(val);
    currentIndexRef.current = val;
  };

  const canSwipe = currentIndex >= 0;

  const canGoBack = currentIndex < users.length - 1;

  const childRefs = useMemo(
    () =>
      Array(users.length)
        .fill(0)
        .map(() => createRef<any>()),
    [users.length]
  );

  const onUndo = async () => {
    if (!canGoBack) return;
    const newIndex = currentIndex + 1;
    updateCurrentIndex(newIndex);
    await childRefs[newIndex].current.restoreCard();
  };

  const swipe = async (dir) => {
    if (canSwipe && currentIndex < users.length) {
      await childRefs[currentIndex].current.swipe(dir); // Swipe the card!
    }
  };

  const outOfFrame = (idx: number) => {
    // handle the case in which go back is pressed before card goes outOfFrame
    currentIndexRef.current >= idx && childRefs[idx].current.restoreCard();
    // TODO: when quickly swipe and restore multiple times the same card,
    // it happens multiple outOfFrame events are queued and the card disappear
    // during latest swipes. Only the last outOfFrame event should be considered valid
  };

  // set last direction and decrease current index
  const onSwipe = (index: number) => {
    updateCurrentIndex(index - 1);
  };

  return (
    <Box display="flex" justifyContent="center" height="100vh">
      {users.map((_, index) => (
        <SwipeCard
          key={index}
          user={users[index]}
          index={index}
          onUndo={onUndo}
          outOfFrame={outOfFrame}
          ref={childRefs[index]}
          onSwipe={onSwipe}
          isActive={currentIndex === index}
        />
      ))}
      <Flex justify="space-around" gap={4} position="absolute" bottom={"65px"}>
        <IconButton
          aria-label="Swipe Left"
          icon={<CloseIcon />}
          colorScheme="red"
          onClick={() => swipe("left")}
          size="lg"
          isRound
          variant={"outline"}
        />
        <IconButton
          aria-label="Undo"
          icon={<FaUndoAlt />}
          colorScheme="yellow"
          onClick={onUndo}
          size="lg"
          isRound
          variant={"outline"}
        />
        <IconButton
          aria-label="Swipe Right"
          icon={<FaHeart />}
          colorScheme="green"
          onClick={() => swipe("right")}
          size="lg"
          isRound
          variant={"outline"}
        />
      </Flex>
    </Box>
  );
};

export default Swipe;
