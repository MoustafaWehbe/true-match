import { RoomDtoApiResponse, RoomDto } from "../openApiGen";
import axiosInstance from "./axiosInstance";
import { handleError } from "./errorHandler";

const getRoomById = async (
  token: string,
  roomId: number
): Promise<RoomDtoApiResponse> => {
  try {
    const response = await axiosInstance.get<RoomDtoApiResponse>(
      `/room/${roomId}`,
      {
        headers: { Authorization: `Bearer ${token}` },
      }
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
): Promise<RoomDtoApiResponse> => {
  try {
    const response = await axiosInstance.put<RoomDtoApiResponse>(
      `/room/${roomId}`,
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

export { getRoomById, updateRoom };
