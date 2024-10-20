import { Socket } from "socket.io";

import { UserDtoApiResponse } from "@dapp/shared/src/types/openApiGen";

import { userService } from "../services";

const authMiddleware = async (socket: Socket, next: (err?: any) => void) => {
  const token = socket.handshake.auth.token;
  if (!token) {
    return next(new Error("Authentication error"));
  }

  let user: UserDtoApiResponse | undefined | null = null;
  try {
    user = await userService.verifyUser(token);
    if (user && user.statusCode !== 200 && user.statusCode !== 201) {
      socket.disconnect(true);
      return next(new Error("Unauthorized"));
    }
    socket.data.user = user?.data;
    next();
  } catch (error) {
    socket.disconnect(true);
    return next(new Error("Unauthorized"));
  }
};

export default authMiddleware;
