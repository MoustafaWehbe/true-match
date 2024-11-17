import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";

import { openApiTypes } from "@dapp/shared";

import axiosInstance, { defaultHeaders } from "~/lib/utils/api/axiosConfig";

export interface RejectErrorCustomType {
  status: number;
  data: string;
}

export interface RoomSate {
  roomContent: Array<openApiTypes.RoomContentDto> | null;
  roomContentLoading: boolean;
  createRoomLoading: boolean;
  getRoomsLoading: boolean;
  getMyRoomsLoading: boolean;
  rooms: openApiTypes.RoomDtoPagedResponse | null;
  myRooms: openApiTypes.RoomDtoPagedResponse | null;
  activeRoom: openApiTypes.RoomDto | null;
  activeRoomLoading: boolean;
  updateRoomLoading: boolean;
  deletingRoom: boolean;
  isRegistering: boolean;
  isdeRegistering: boolean;
  ishidingRoom: boolean;
  isStartingRoom: boolean;
  actionPerformedOnRoomId: string | null;
}

export const getRoomContent = createAsyncThunk<
  Array<openApiTypes.RoomContentDto> | null,
  undefined,
  { rejectValue: string }
>("room/getAll", async (_, { rejectWithValue }) => {
  try {
    const response =
      await axiosInstance.get<openApiTypes.RoomContentDtoListApiResponse>(
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
  openApiTypes.RoomDtoPagedResponse,
  {
    PageNumber: number;
    PageSize: number;
    Status: openApiTypes.AllRoomStatus;
  },
  { rejectValue: string }
>(
  "room/getRooms",
  async ({ PageNumber, PageSize, Status }, { rejectWithValue }) => {
    try {
      const response =
        await axiosInstance.get<openApiTypes.RoomDtoPagedResponse>(
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
  openApiTypes.RoomDtoPagedResponse,
  { PageNumber: number; PageSize: number; Status: openApiTypes.MyRoomStatus },
  { rejectValue: string }
>(
  "room/getMyRooms",
  async ({ PageNumber, PageSize, Status }, { rejectWithValue }) => {
    try {
      const response =
        await axiosInstance.get<openApiTypes.RoomDtoPagedResponse>(
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
  openApiTypes.RoomDto | undefined,
  openApiTypes.CreateRoomDto,
  { rejectValue: string }
>("room/create", async (roomData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<openApiTypes.RoomDtoApiResponse>(
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

export const hideRoom = createAsyncThunk<
  openApiTypes.SimpleApiResponseApiResponse,
  openApiTypes.HideRoomDto,
  { rejectValue: string }
>("room/hideRoom", async (roomDto, { rejectWithValue }) => {
  try {
    const response =
      await axiosInstance.post<openApiTypes.SimpleApiResponseApiResponse>(
        `/api/room/hide-room`,
        roomDto,
        { headers: defaultHeaders }
      );
    return response.data;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const updateRoom = createAsyncThunk<
  openApiTypes.RoomDto | undefined,
  openApiTypes.UpdateRoomDto & { id: string },
  { rejectValue: string }
>("room/update", async (roomData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.put<openApiTypes.RoomDtoApiResponse>(
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
  openApiTypes.RoomDto | null,
  string,
  { rejectValue: string }
>("room/getRoomById", async (roomId, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.get<openApiTypes.RoomDtoApiResponse>(
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
  openApiTypes.SimpleApiResponseApiResponse,
  string,
  { rejectValue: string }
>("room/delete", async (roomId, { rejectWithValue }) => {
  try {
    const response =
      await axiosInstance.delete<openApiTypes.SimpleApiResponseApiResponse>(
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

export const startRoom = createAsyncThunk<
  openApiTypes.RoomDtoApiResponse | undefined,
  { id: string },
  { rejectValue: RejectErrorCustomType }
>("room/start", async (roomData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<openApiTypes.RoomDtoApiResponse>(
      `/api/room/start-room/${roomData.id}`,
      {},
      { headers: defaultHeaders }
    );
    return response.data;
  } catch (error) {
    let errorMessage: RejectErrorCustomType = {
      data: "Something went wrong!",
      status: 200,
    };
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = {
        status: error.response.status,
        data: error.response.data || errorMessage.data,
      };
    }
    return rejectWithValue(errorMessage);
  }
});

// start room-participant
export const registerRoom = createAsyncThunk<
  openApiTypes.RoomParticipantDto | undefined,
  string,
  { rejectValue: RejectErrorCustomType }
>("room/registerRoom", async (roomId, { rejectWithValue }) => {
  try {
    const response =
      await axiosInstance.post<openApiTypes.RoomParticipantDtoApiResponse>(
        `/api/room-participant/register/${roomId}`,
        {},
        { headers: defaultHeaders }
      );
    return response.data.data;
  } catch (error) {
    let errorMessage: RejectErrorCustomType = {
      data: "Something went wrong!",
      status: 200,
    };
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = {
        status: error.response.status,
        data: error.response.data || errorMessage.data,
      };
    }
    return rejectWithValue(errorMessage);
  }
});

export const deregisterRoom = createAsyncThunk<
  openApiTypes.SimpleApiResponseApiResponse,
  string,
  { rejectValue: RejectErrorCustomType }
>("room/deregisterRoom", async (roomId, { rejectWithValue }) => {
  try {
    const response =
      await axiosInstance.post<openApiTypes.SimpleApiResponseApiResponse>(
        `/api/room-participant/deregister/${roomId}`,
        {},
        { headers: defaultHeaders }
      );
    return response.data;
  } catch (error) {
    let errorMessage: RejectErrorCustomType = {
      data: "Something went wrong!",
      status: 200,
    };
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = {
        status: error.response.status,
        data: error.response.data || errorMessage.data,
      };
    }
    return rejectWithValue(errorMessage);
  }
});
// end room-participant

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
  isRegistering: false,
  isdeRegistering: false,
  ishidingRoom: false,
  actionPerformedOnRoomId: null,
  isStartingRoom: false,
};

const roomSlice = createSlice({
  name: "room",
  initialState,
  reducers: {
    clearRooms(state) {
      state.rooms = null;
    },
    clearMyRooms(state) {
      state.myRooms = null;
    },
    removeRoomsByUserId(state, action) {
      const userId = action.payload as string;
      if (state.rooms?.data?.length) {
        state.rooms.data = state.rooms.data.filter(
          (r) => r.user?.id !== userId
        );
      }
    },
    removeRoomById(state, action) {
      if (state.rooms?.data?.length) {
        state.rooms.data = state.rooms.data.filter(
          (r) => r.id !== action.payload
        );
      }
    },
    updateSystemQuestions(state, action) {
      if (state.activeRoom) {
        if (state.activeRoom.roomState) {
          state.activeRoom.roomState.roundQuestions = action.payload;
        } else {
          state.activeRoom.roomState = { roundQuestions: action.payload };
        }
      }
    },
    updateActiveRoomState(state, action) {
      if (state.activeRoom) {
        state.activeRoom.roomState = action.payload;
      }
    },
    updateActiveRoomStatePartially(state, action) {
      if (state.activeRoom) {
        state.activeRoom.roomState = {
          ...state.activeRoom.roomState,
          ...action.payload,
        };
      }
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getRoomContent.pending, (state) => {
        state.roomContentLoading = true;
      })
      .addCase(
        getRoomContent.fulfilled,
        (
          state,
          action: PayloadAction<Array<openApiTypes.RoomContentDto> | null>
        ) => {
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
        (state, action: PayloadAction<openApiTypes.RoomDto | undefined>) => {
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
        (
          state,
          action: PayloadAction<openApiTypes.RoomDtoPagedResponse | null>
        ) => {
          state.getRoomsLoading = false;
          if (!state.rooms?.data) {
            state.rooms = action.payload;
          } else if (action.payload?.data) {
            state.rooms = {
              ...action.payload,
              data: [...state.rooms?.data, ...action.payload?.data],
            };
          }
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
        (
          state,
          action: PayloadAction<openApiTypes.RoomDtoPagedResponse | null>
        ) => {
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
        (state, action: PayloadAction<openApiTypes.RoomDto | null>) => {
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
      })
      .addCase(registerRoom.pending, (state, action) => {
        state.isRegistering = true;
        state.actionPerformedOnRoomId = action.meta.arg;
      })
      .addCase(registerRoom.fulfilled, (state, action) => {
        state.isRegistering = false;
        if (state.rooms?.data?.length) {
          const roomIndex = state.rooms.data.findIndex(
            (r) => r.id === action.meta.arg
          );
          if (roomIndex !== -1) {
            const room = state.rooms.data[roomIndex];
            room.participantCount = room.participantCount
              ? room.participantCount + 1
              : 1;
            room.isParticipanting = true;
          }
        }
      })
      .addCase(registerRoom.rejected, (state) => {
        state.isRegistering = false;
      })
      .addCase(deregisterRoom.pending, (state, action) => {
        state.isdeRegistering = true;
        state.actionPerformedOnRoomId = action.meta.arg;
      })
      .addCase(deregisterRoom.fulfilled, (state, action) => {
        state.isdeRegistering = false;
        if (state.rooms?.data?.length) {
          const roomIndex = state.rooms.data.findIndex(
            (r) => r.id === action.meta.arg
          );
          if (roomIndex !== -1) {
            const room = state.rooms.data[roomIndex];
            room.participantCount = room.participantCount
              ? room.participantCount - 1
              : 0;
            room.isParticipanting = false;
          }
        }
      })
      .addCase(deregisterRoom.rejected, (state) => {
        state.isdeRegistering = false;
      })
      .addCase(hideRoom.pending, (state, action) => {
        state.ishidingRoom = true;
        state.actionPerformedOnRoomId = action.meta.arg.roomId;
      })
      .addCase(hideRoom.fulfilled, (state, action) => {
        state.ishidingRoom = false;
        if (state.rooms?.data?.length) {
          state.rooms.data = state.rooms.data.filter(
            (r) => r.id !== action.meta.arg.roomId
          );
        }
      })
      .addCase(hideRoom.rejected, (state) => {
        state.ishidingRoom = false;
      })
      .addCase(startRoom.pending, (state) => {
        state.isStartingRoom = true;
      })
      .addCase(startRoom.fulfilled, (state) => {
        state.isStartingRoom = false;
      })
      .addCase(startRoom.rejected, (state) => {
        state.isStartingRoom = false;
      });
  },
});

export const { clearRooms } = roomSlice.actions;
export const { clearMyRooms } = roomSlice.actions;
export const { removeRoomsByUserId } = roomSlice.actions;
export const { removeRoomById } = roomSlice.actions;
export const { updateSystemQuestions } = roomSlice.actions;
export const { updateActiveRoomState } = roomSlice.actions;
export const { updateActiveRoomStatePartially } = roomSlice.actions;

export default roomSlice.reducer;
