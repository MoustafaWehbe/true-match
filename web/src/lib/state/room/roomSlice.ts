import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import {
  RoomContentDto,
  RoomContentDtoListApiResponse,
} from '~/lib/openApiGen';
import axiosInstance from '~/lib/utils/api/axiosConfig';

export interface RoomSate {
  roomContent: Array<RoomContentDto> | null;
  roomContentLoading: boolean;
}

export const getRoomContent = createAsyncThunk<
  Array<RoomContentDto> | null,
  undefined,
  { rejectValue: string }
>('room/getAll', async (_, { rejectWithValue }) => {
  try {
    const response =
      await axiosInstance.get<RoomContentDtoListApiResponse>(
        '/api/room-content'
      );
    return response.data.data ?? null;
  } catch (error) {
    let errorMessage = 'Something went wrong!';
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

const initialState: RoomSate = {
  roomContent: null,
  roomContentLoading: false,
};

const roomSlice = createSlice({
  name: 'room',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getRoomContent.pending, (state) => {
        state.roomContentLoading = true;
      })
      .addCase(
        getRoomContent.fulfilled,
        (state, action: PayloadAction<Array<RoomContentDto> | null>) => {
          state.roomContentLoading = false;
          state.roomContent = action.payload;
        }
      )
      .addCase(getRoomContent.rejected, (state) => {
        state.roomContentLoading = false;
      });
  },
});

export default roomSlice.reducer;
