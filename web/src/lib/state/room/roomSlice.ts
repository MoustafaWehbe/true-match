import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import {
  RoomContentDto,
  RoomContentDtoListApiResponse,
  RoomDto,
  RoomDtoApiResponse,
  CreateRoomDto,
  RoomDtoPagedResponse,
} from '~/lib/openApiGen';
import axiosInstance from '~/lib/utils/api/axiosConfig';

export interface RoomSate {
  roomContent: Array<RoomContentDto> | null;
  createdRoom?: RoomDto;
  roomContentLoading: boolean;
  createRoomLoading: boolean;
  getRoomsLoading: boolean;
  rooms: RoomDtoPagedResponse | null;
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

export const getRooms = createAsyncThunk<
  RoomDtoPagedResponse,
  { PageNumber: number; PageSize: number; Status: number },
  { rejectValue: string }
>(
  'room/getRooms',
  async ({ PageNumber, PageSize, Status }, { rejectWithValue }) => {
    try {
      const response = await axiosInstance.get<RoomDtoPagedResponse>(
        '/api/room',
        {
          params: { PageNumber, PageSize, Status },
        }
      );
      return response.data ?? null;
    } catch (error) {
      let errorMessage = 'Something went wrong!';
      if (axios.isAxiosError(error) && error.response) {
        errorMessage = error.response.data.message || errorMessage;
      }
      return rejectWithValue(errorMessage);
    }
  }
);

export const createRoom = createAsyncThunk<
  RoomDto | undefined,
  CreateRoomDto,
  { rejectValue: string }
>('room/create', async (roomData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<RoomDtoApiResponse>(
      '/api/room',
      roomData
    );
    return response.data.data;
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
  createRoomLoading: false,
  getRoomsLoading: false,
  rooms: null,
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
      })
      .addCase(createRoom.pending, (state) => {
        state.createRoomLoading = true;
      })
      .addCase(
        createRoom.fulfilled,
        (state, action: PayloadAction<RoomDto | undefined>) => {
          state.createRoomLoading = false;
          state.createdRoom = action.payload;
        }
      )
      .addCase(createRoom.rejected, (state) => {
        state.createRoomLoading = false;
      })
      .addCase(getRooms.pending, (state) => {
        state.getRoomsLoading = true;
      })
      .addCase(
        getRooms.fulfilled,
        (state, action: PayloadAction<RoomDtoPagedResponse | null>) => {
          state.getRoomsLoading = false;
          state.rooms = action.payload;
        }
      )
      .addCase(getRooms.rejected, (state) => {
        state.getRoomsLoading = false;
      });
  },
});

export default roomSlice.reducer;
