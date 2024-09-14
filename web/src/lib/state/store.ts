import { configureStore } from "@reduxjs/toolkit";
import userReducer from "./user/userSlice";
import roomReducer from "./room/roomSlice";
import questionSlice from "./question/questionSlice";
import genderSlice from "./gender/genderSlice";
import availableDescriptorSlice from "./availableDescriptor/availableDescriptorSlice";

export const store = configureStore({
  reducer: {
    user: userReducer,
    room: roomReducer,
    question: questionSlice,
    gender: genderSlice,
    availableDescriptor: availableDescriptorSlice,
  },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
