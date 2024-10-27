import { configureStore } from "@reduxjs/toolkit";

import availableDescriptorSlice from "./availableDescriptor/availableDescriptorSlice";
import genderSlice from "./gender/genderSlice";
import questionSlice from "./question/questionSlice";
import roomReducer from "./room/roomSlice";
import userReducer from "./user/userSlice";

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
