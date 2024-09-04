import {
  Button,
  Modal,
  ModalOverlay,
  ModalContent,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Text,
} from "@chakra-ui/react";
import React from "react";

interface ConfirmDialogProps {
  isOpen: boolean;
  onClose: () => void;
  onConfirm: () => void;
  title?: string;
  description?: string;
  confirmText?: string;
  cancelText?: string;
  isLoading?: boolean; // Optional loading state for the confirm button
}

const ConfirmDialog: React.FC<ConfirmDialogProps> = ({
  isOpen,
  onClose,
  onConfirm,
  title = "Are you sure?",
  description = "Do you really want to perform this action? This action cannot be undone.",
  confirmText = "Confirm",
  cancelText = "Cancel",
  isLoading = false,
}) => {
  return (
    <Modal isOpen={isOpen} onClose={onClose} isCentered>
      <ModalOverlay />
      <ModalContent>
        <ModalHeader>{title}</ModalHeader>
        <ModalBody>
          <Text>{description}</Text>
        </ModalBody>
        <ModalFooter>
          <Button variant="ghost" mr={3} onClick={onClose}>
            {cancelText}
          </Button>
          <Button
            colorScheme="red"
            onClick={onConfirm}
            isLoading={isLoading} // Display loading indicator if needed
          >
            {confirmText}
          </Button>
        </ModalFooter>
      </ModalContent>
    </Modal>
  );
};

export default ConfirmDialog;
