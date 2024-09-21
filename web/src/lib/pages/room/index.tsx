"use client";

import { useParams } from "next/navigation";

import Room from "~/lib/components/rooms/Room";

const RoomPage = () => {
  const { id } = useParams<{ id: string }>();

  if (!id) {
    return null;
  }

  return <Room roomId={id as string} />;
};

export default RoomPage;
