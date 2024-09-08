"use client";

import { Box, Flex, IconButton } from "@chakra-ui/react";
import SwipeCard from "./SwipeCard";
import { createRef, useMemo, useRef, useState } from "react";
import { CloseIcon } from "@chakra-ui/icons";
import { FaHeart, FaUndoAlt } from "react-icons/fa";

const Swipe = () => {
  const users = [
    {
      id: 1,
      name: "moustafa wehbe",
      bio: "Love hiking and outdoor adventures.",
    },
    { id: 2, name: "mohamad", bio: "A foodie at heart and a coffee addict." },
    { id: 3, name: "Salam salama", bio: "Welll not sure yet about this one" },
    { id: 4, name: "haidar haidoura", bio: "I do not work, I am a princes" },
  ];
  const [currentIndex, setCurrentIndex] = useState(users.length - 1);

  const currentIndexRef = useRef(currentIndex);

  const updateCurrentIndex = (val: number) => {
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

  const swipe = async (dir: string) => {
    if (canSwipe && currentIndex < users.length) {
      await childRefs[currentIndex].current.swipe(dir);
    }
  };

  const onCardLeftScreen = (idx: number) => {
    // handle the case in which go back is pressed before card goes outOfFrame
    currentIndexRef.current >= idx && childRefs[idx].current.restoreCard();
    // TODO: when quickly swipe and restore multiple times the same card,
    // it happens multiple outOfFrame events are queued and the card disappear
    // during latest swipes. Only the last outOfFrame event should be considered valid
  };

  const onSwipe = (index: number) => {
    setTimeout(() => {
      updateCurrentIndex(index - 1);
    }, 500);
  };

  return (
    <Box display="flex" justifyContent="center" height="100vh">
      {users.map((_, index) => (
        <SwipeCard
          key={index}
          user={users[index]}
          index={index}
          onUndo={onUndo}
          onCardLeftScreen={onCardLeftScreen}
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
