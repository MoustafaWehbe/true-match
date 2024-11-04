import axiosInstance from "./axiosInstance";
import { handleError } from "./errorHandler";

const saveMessage = async (
  message: CreateMessageDto,
  token: string
): Promise<MessageDtoApiResponse | undefined> => {
  try {
    const response = await axiosInstance.post<MessageDtoApiResponse>(
      `api/message/`,
      message,
      { headers: { Authorization: `Bearer ${token}` } }
    );
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

const updateMessageStatus = async (
  token: string,
  messageStatus: MessageStatus,
  messageId: number
): Promise<{}> => {
  try {
    const response = await axiosInstance.put<{}>(
      `api/message/${messageId}/status`,
      { status: messageStatus },
      {
        headers: { Authorization: `Bearer ${token}` },
      }
    );
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

export { saveMessage, updateMessageStatus };
