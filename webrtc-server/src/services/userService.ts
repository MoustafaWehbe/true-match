import { UserDtoApiResponse } from "@dapp/shared/src/types/openApiGen";

import axiosInstance from "./axiosInstance";
import { handleError } from "./errorHandler";

const verifyUser = async (
  token: string
): Promise<UserDtoApiResponse | undefined> => {
  try {
    const response = await axiosInstance.get<UserDtoApiResponse>("/me", {
      headers: { Authorization: `Bearer ${token}` },
    });
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

export { verifyUser };
