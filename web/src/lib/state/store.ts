import { configureStore } from '@reduxjs/toolkit';
import userReducer from './user/userSlice';
import roomReducer from './room/roomSlice';

export const store = configureStore({
  reducer: {
    user: userReducer,
    room: roomReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
