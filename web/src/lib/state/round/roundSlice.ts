import { createSlice, PayloadAction } from "@reduxjs/toolkit";

export interface RoundState {
  currentRound: number | null;
  timer: number;
  isPaused: boolean;
}

const initialState: RoundState = {
  currentRound: null,
  timer: 0,
  isPaused: false,
};

const roundSlice = createSlice({
  name: "round",
  initialState,
  reducers: {
    startRound: (state, action: PayloadAction<number>) => {
      state.currentRound = action.payload;
    },
    setTimer: (state, action: PayloadAction<number>) => {
      state.timer = action.payload;
    },
    pauseRound: (state) => {
      state.isPaused = true;
    },
    resumeRound: (state) => {
      state.isPaused = false;
    },
    skipRound: (state, action: PayloadAction<number>) => {
      state.currentRound = action.payload;
    },
    resetRound: (state) => {
      state.currentRound = null;
      state.timer = 0;
      state.isPaused = false;
    },
  },
});

export const {
  startRound,
  setTimer,
  pauseRound,
  resumeRound,
  skipRound,
  resetRound,
} = roundSlice.actions;

export default roundSlice.reducer;
