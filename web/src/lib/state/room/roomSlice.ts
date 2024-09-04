import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";
import {
  RoomContentDto,
  RoomContentDtoListApiResponse,
  RoomDto,
  RoomDtoApiResponse,
  CreateRoomDto,
  RoomDtoPagedResponse,
  AllRoomStatus,
  MyRoomStatus,
  SimpleApiResponseApiResponse,
  UpdateRoomDto,
} from "shared/src/types/openApiGen";
import axiosInstance, { defaultHeaders } from "~/lib/utils/api/axiosConfig";

export interface RoomSate {
  roomContent: Array<RoomContentDto> | null;
  roomContentLoading: boolean;
  createRoomLoading: boolean;
  getRoomsLoading: boolean;
  getMyRoomsLoading: boolean;
  rooms: RoomDtoPagedResponse | null;
  myRooms: RoomDtoPagedResponse | null;
  activeRoom: RoomDto | null;
  activeRoomLoading: boolean;
  updateRoomLoading: boolean;
  deletingRoom: boolean;
}

export const getRoomContent = createAsyncThunk<
  Array<RoomContentDto> | null,
  undefined,
  { rejectValue: string }
>("room/getAll", async (_, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.get<RoomContentDtoListApiResponse>(
      "/api/room-content",
      {
        headers: defaultHeaders,
      }
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

export const getRooms = createAsyncThunk<
  RoomDtoPagedResponse,
  { PageNumber: number; PageSize: number; Status: AllRoomStatus },
  { rejectValue: string }
>(
  "room/getRooms",
  async ({ PageNumber, PageSize, Status }, { rejectWithValue }) => {
    try {
      const response = await axiosInstance.get<RoomDtoPagedResponse>(
        "/api/room",
        {
          params: { PageNumber, PageSize, Status },
          headers: defaultHeaders,
        }
      );
      return response.data ?? null;
    } catch (error) {
      let errorMessage = "Something went wrong!";
      if (axios.isAxiosError(error) && error.response) {
        errorMessage = error.response.data.message || errorMessage;
      }
      return rejectWithValue(errorMessage);
    }
  }
);

export const getMyRooms = createAsyncThunk<
  RoomDtoPagedResponse,
  { PageNumber: number; PageSize: number; Status: MyRoomStatus },
  { rejectValue: string }
>(
  "room/getMyRooms",
  async ({ PageNumber, PageSize, Status }, { rejectWithValue }) => {
    try {
      const response = await axiosInstance.get<RoomDtoPagedResponse>(
        "/api/room/my-rooms",
        {
          params: { PageNumber, PageSize, Status },
          headers: defaultHeaders,
        }
      );
      return response.data ?? null;
    } catch (error) {
      let errorMessage = "Something went wrong!";
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
>("room/create", async (roomData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<RoomDtoApiResponse>(
      "/api/room",
      roomData,
      { headers: defaultHeaders }
    );
    return response.data.data;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const updateRoom = createAsyncThunk<
  RoomDto | undefined,
  UpdateRoomDto & { id: number },
  { rejectValue: string }
>("room/update", async (roomData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.put<RoomDtoApiResponse>(
      `/api/room/${roomData.id}`,
      roomData,
      { headers: defaultHeaders }
    );
    return response.data.data;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const getRoomById = createAsyncThunk<
  RoomDto | null,
  number,
  { rejectValue: string }
>("room/getRoomById", async (roomId, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.get<RoomDtoApiResponse>(
      `/api/room/${roomId}`,
      { headers: defaultHeaders }
    );
    return response.data.data ?? null;
  } catch (error: any) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const deleteRoom = createAsyncThunk<
  SimpleApiResponseApiResponse,
  number,
  { rejectValue: string }
>("room/delete", async (roomId, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.delete<SimpleApiResponseApiResponse>(
      `/api/room/${roomId}`
    );
    return response.data;
  } catch (error) {
    let errorMessage = "Failed to delete the room!";
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
  activeRoom: null,
  activeRoomLoading: false,
  updateRoomLoading: false,
  myRooms: null,
  getMyRoomsLoading: false,
  deletingRoom: false,
};

const roomSlice = createSlice({
  name: "room",
  initialState,
  reducers: {
    clearRooms(state) {
      state.rooms = null;
    },
  },
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
          if (action.payload) {
            state.myRooms?.data?.unshift(action.payload);
          }
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
          if (!state.rooms?.data) {
            state.rooms = action.payload;
          } else if (action.payload?.data) {
            state.rooms = {
              ...action.payload,
              data: [...state.rooms?.data, ...action.payload?.data],
            };
          }
          // if (
          //   state.rooms?.currentPage &&
          //   state.rooms.currentPage >= 2 &&
          //   action.payload?.data &&
          //   state.rooms?.data
          // ) {
          //   state.rooms = {
          //     ...action.payload,
          //     data: [...state.rooms?.data, ...action.payload?.data],
          //   };
          // } else {
          //   state.rooms = action.payload;
          // }
        }
      )
      .addCase(getRooms.rejected, (state) => {
        state.getRoomsLoading = false;
      })
      .addCase(getMyRooms.pending, (state) => {
        state.getMyRoomsLoading = true;
      })
      .addCase(
        getMyRooms.fulfilled,
        (state, action: PayloadAction<RoomDtoPagedResponse | null>) => {
          state.getMyRoomsLoading = false;
          state.myRooms = action.payload;
        }
      )
      .addCase(getMyRooms.rejected, (state) => {
        state.getMyRoomsLoading = false;
      })
      .addCase(getRoomById.pending, (state) => {
        state.activeRoomLoading = true;
      })
      .addCase(
        getRoomById.fulfilled,
        (state, action: PayloadAction<RoomDto | null>) => {
          state.activeRoomLoading = false;
          state.activeRoom = action.payload;
        }
      )
      .addCase(getRoomById.rejected, (state) => {
        state.activeRoomLoading = false;
      })
      .addCase(updateRoom.pending, (state) => {
        state.updateRoomLoading = true;
      })
      .addCase(updateRoom.fulfilled, (state, action) => {
        state.updateRoomLoading = false;
        if (state.myRooms?.data?.length && action.payload) {
          const index = state.myRooms.data.findIndex(
            (r) => r.id === action.payload?.id
          );
          if (index !== -1) {
            state.myRooms.data[index] = action.payload;
          }
        }
      })
      .addCase(updateRoom.rejected, (state) => {
        state.updateRoomLoading = false;
      })
      .addCase(deleteRoom.pending, (state) => {
        state.deletingRoom = true;
      })
      .addCase(deleteRoom.fulfilled, (state, action) => {
        state.deletingRoom = false;
        if (state.myRooms?.data) {
          state.myRooms.data = state.myRooms?.data?.filter(
            (room) => room.id !== action.meta.arg
          );
        }
      })
      .addCase(deleteRoom.rejected, (state) => {
        state.deletingRoom = false;
      });
  },
});

export const { clearRooms } = roomSlice.actions;

export default roomSlice.reducer;
