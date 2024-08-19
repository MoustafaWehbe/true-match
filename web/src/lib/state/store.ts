import { configureStore } from "@reduxjs/toolkit";
import userReducer from "./user/userSlice";
import roomReducer from "./room/roomSlice";
import questionSlice from "./question/questionSlice";

export const store = configureStore({
  reducer: {
    user: userReducer,
    room: roomReducer,
    question: questionSlice,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
