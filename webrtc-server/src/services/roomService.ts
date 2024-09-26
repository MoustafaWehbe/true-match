import {
  RoomDto,
  RoomDtoApiResponse,
  RoomParticipantDtoApiResponse,
  SimpleApiResponseApiResponse,
} from "@dapp/shared/src/types/openApiGen";

import axiosInstance from "./axiosInstance";
import { handleError } from "./errorHandler";

const getRoomById = async (
  token: string,
  roomId: number
): Promise<RoomDtoApiResponse | undefined> => {
  try {
    const response = await axiosInstance.get<RoomDtoApiResponse>(
      `api/room/${roomId}`,
      {
        headers: { Authorization: `Bearer ${token}` },
      }
    );
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

const leaveRoom = async (
  roomId: number,
  token: string
): Promise<SimpleApiResponseApiResponse | undefined> => {
  try {
    const response = await axiosInstance.post<SimpleApiResponseApiResponse>(
      `api/room-participant/leave/${roomId}`,
      {},
      { headers: { Authorization: `Bearer ${token}` } }
    );
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

const updateRoom = async (
  token: string,
  room: RoomDto,
  roomId: number
): Promise<RoomDtoApiResponse | undefined> => {
  try {
    const response = await axiosInstance.put<RoomDtoApiResponse>(
      `api/room/${roomId}`,
      room,
      {
        headers: { Authorization: `Bearer ${token}` },
      }
    );
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

const joinRoom = async (
  token: string,
  roomId: number,
  socketId: string
): Promise<RoomParticipantDtoApiResponse | undefined> => {
  try {
    const response = await axiosInstance.post<RoomParticipantDtoApiResponse>(
      `api/room-participant/join/${roomId}`,
      {
        roomId,
        socketId,
      },
      {
        headers: { Authorization: `Bearer ${token}` },
      }
    );
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

export { getRoomById, updateRoom, joinRoom, leaveRoom };
