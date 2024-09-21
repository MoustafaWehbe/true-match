import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";

import {
  AvailableDescriptorDto,
  AvailableDescriptorDtoListApiResponse,
} from "@dapp/shared/src/types/openApiGen";

import axiosInstance, { defaultHeaders } from "~/lib/utils/api/axiosConfig";

export interface QuestionSate {
  availableDescriptors: Array<AvailableDescriptorDto> | null;
  availableDescriptorsLoading: boolean;
}

export const getAvailableDescriptors = createAsyncThunk<
  Array<AvailableDescriptorDto> | null,
  undefined,
  { rejectValue: string }
>("availableDescriptors/get-all", async (_, { rejectWithValue }) => {
  try {
    const response =
      await axiosInstance.get<AvailableDescriptorDtoListApiResponse>(
        "/api/available-descriptors",
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

const initialState: QuestionSate = {
  availableDescriptors: null,
  availableDescriptorsLoading: false,
};

const questionSlice = createSlice({
  name: "question",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getAvailableDescriptors.pending, (state) => {
        state.availableDescriptorsLoading = true;
      })
      .addCase(
        getAvailableDescriptors.fulfilled,
        (
          state,
          action: PayloadAction<Array<AvailableDescriptorDto> | null>
        ) => {
          state.availableDescriptorsLoading = false;
          state.availableDescriptors = action.payload;
        }
      )
      .addCase(getAvailableDescriptors.rejected, (state) => {
        state.availableDescriptorsLoading = false;
      });
  },
});

export default questionSlice.reducer;
