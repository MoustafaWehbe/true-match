import { io } from 'socket.io-client';
import env from '~/lib/consts/env';
import { TOKEN } from '~/lib/consts/localStorage';

export const socket = io(env.socketServerUrl!, {
  autoConnect: true,
  auth: {
    token: localStorage.getItem(TOKEN),
  },
});
