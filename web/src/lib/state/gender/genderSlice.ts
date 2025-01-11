import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";

import {
  GenderDto,
  GenderDtoListApiResponse,
} from "@truematch/shared/src/types/openApiGen";

import axiosInstance, { defaultHeaders } from "~/lib/utils/api/axiosConfig";

export interface GenderSate {
  genders: Array<GenderDto> | null;
  gendersLoading: boolean;
}

export const getGenders = createAsyncThunk<
  Array<GenderDto> | null,
  undefined,
  { rejectValue: string }
>("genders/get-all", async (_, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.get<GenderDtoListApiResponse>(
      "/api/genders",
      { headers: defaultHeaders }
    );
    return response.data.data ?? null;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

const initialState: GenderSate = {
  genders: null,
  gendersLoading: false,
};

const genderSlice = createSlice({
  name: "gender",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getGenders.pending, (state) => {
        state.gendersLoading = true;
      })
      .addCase(
        getGenders.fulfilled,
        (state, action: PayloadAction<Array<GenderDto> | null>) => {
          state.gendersLoading = false;
          state.genders = action.payload;
        }
      )
      .addCase(getGenders.rejected, (state) => {
        state.gendersLoading = false;
      });
  },
});

export default genderSlice.reducer;
