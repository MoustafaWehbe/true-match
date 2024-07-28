import { UserApiResponse } from "../openApiGen";
import axiosInstance from "./axiosInstance";
import { handleError } from "./errorHandler";

const verifyUser = async (token: string): Promise<UserApiResponse> => {
  try {
    const response = await axiosInstance.get<UserApiResponse>("/me", {
      headers: { Authorization: `Bearer ${token}` },
    });
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

export { verifyUser };
