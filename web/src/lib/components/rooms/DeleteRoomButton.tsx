import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { Button } from "@chakra-ui/react";

import ConfirmDialog from "../shared/ConfirmDialog";

import { deleteRoom } from "~/lib/state/room/roomSlice";
import { AppDispatch } from "~/lib/state/store";

const DeleteRoomButton: React.FC<{ roomId: number }> = ({ roomId }) => {
  const [isDialogOpen, setIsDialogOpen] = useState(false);
  const [isDeleting, setIsDeleting] = useState(false);
  const dispatch = useDispatch<AppDispatch>();

  const openDialog = () => setIsDialogOpen(true);
  const closeDialog = () => setIsDialogOpen(false);

  const handleDelete = async () => {
    setIsDeleting(true);
    try {
      await dispatch(deleteRoom(roomId));
    } catch (error) {
      console.error("Failed to delete room:", error);
    } finally {
      setIsDeleting(false);
      closeDialog();
    }
  };

  return (
    <>
      <Button colorScheme="red" variant={"solid"} onClick={openDialog}>
        Delete Room
      </Button>

      <ConfirmDialog
        isOpen={isDialogOpen}
        onClose={closeDialog}
        onConfirm={handleDelete}
        title="Delete Room?"
        description="Are you sure you want to delete this room? This action cannot be undone."
        confirmText="Delete"
        cancelText="Cancel"
        isLoading={isDeleting} // Display loading when deleting
      />
    </>
  );
};

export default DeleteRoomButton;
