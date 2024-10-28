"use client";

import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  Modal,
  ModalBody,
  ModalCloseButton,
  ModalContent,
  ModalOverlay,
} from "@chakra-ui/react";

import PreviewProfile from ".";

import { AppDispatch, RootState } from "~/lib/state/store";
import { getUserById } from "~/lib/state/user/userSlice";

interface PreviewProfileModalProp {
  isOpen: boolean;
  userId: string;
  onClose: () => void;
}

function PreviewProfileModal({
  isOpen,
  userId,
  onClose,
}: PreviewProfileModalProp) {
  const dispatch = useDispatch<AppDispatch>();
  const { userById } = useSelector((state: RootState) => state.user);

  useEffect(() => {
    dispatch(getUserById({ id: userId }));
  }, [dispatch, userId]);

  if (!userById) {
    return null;
  }

  return (
    <Modal isOpen={isOpen} onClose={onClose}>
      <ModalCloseButton size={"lg"} zIndex={10000} position={"fixed"} />
      <ModalOverlay />
      <ModalContent background={"transparent"} boxShadow={"none"}>
        <ModalBody>
          <PreviewProfile user={userById} />
        </ModalBody>
      </ModalContent>
    </Modal>
  );
}

export default PreviewProfileModal;
