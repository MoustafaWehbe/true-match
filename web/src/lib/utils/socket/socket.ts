import { io } from "socket.io-client";

import env from "~/lib/consts/env";
import { TOKEN } from "~/lib/consts/localStorage";

export const roomSocket = io(`${env.socketServerUrl}/room`, {
  autoConnect: false,
  auth: {
    token: localStorage.getItem(TOKEN),
  },
});

export const chatSocket = io(`${env.socketServerUrl}/chat`, {
  autoConnect: false,
  auth: {
    token: localStorage.getItem(TOKEN),
  },
});
