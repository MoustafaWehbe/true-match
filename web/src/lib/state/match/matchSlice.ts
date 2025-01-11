import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";

import {
  CreateMatchDto,
  MatchDto,
  MatchDtoListApiResponse,
  MessageDto,
  MessageDtoListApiResponse,
  SimpleApiResponseApiResponse,
} from "@truematch/shared/src/types/openApiGen";

import axiosInstance, { defaultHeaders } from "~/lib/utils/api/axiosConfig";

export interface MatchSate {
  getMatchesLoading: boolean;
  getMessagesLoading: boolean;
  matches: Array<MatchDto> | null;
  activeMatchId: string | null;
  messages: Array<MessageDto> | null;
  isCreatingMatch: boolean;
  matchFromCreate?: MatchDto | null;
  deletingMatch: boolean;
}

export const getMatches = createAsyncThunk<
  Array<MatchDto> | null,
  undefined,
  { rejectValue: string }
>("match/getMatches", async (_, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.get<MatchDtoListApiResponse>(
      "/api/match",
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

export const getMessages = createAsyncThunk<
  Array<MessageDto> | null,
  { senderId: string; receiverId: string },
  { rejectValue: string }
>(
  "match/getMessages",
  async ({ senderId, receiverId }, { rejectWithValue }) => {
    try {
      const response = await axiosInstance.get<MessageDtoListApiResponse>(
        `/api/message/conversation/${senderId}/${receiverId}`,
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
  }
);

export const createMatch = createAsyncThunk<
  MatchDto | undefined,
  CreateMatchDto,
  { rejectValue: string }
>("match/create", async (payload, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<CreateMatchDto>(
      `/api/match`,
      payload,
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

export const deleteMatch = createAsyncThunk<
  SimpleApiResponseApiResponse,
  string,
  { rejectValue: string }
>("match/delete", async (matchId, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.delete<SimpleApiResponseApiResponse>(
      `/api/match/${matchId}`
    );
    return response.data;
  } catch (error) {
    let errorMessage = "Failed to delete the match!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

const initialState: MatchSate = {
  getMatchesLoading: false,
  getMessagesLoading: false,
  matches: null,
  activeMatchId: null,
  messages: null,
  isCreatingMatch: false,
  matchFromCreate: null,
  deletingMatch: false,
};

const matchSlice = createSlice({
  name: "match",
  initialState,
  reducers: {
    setActiveMatchId(state, action) {
      state.activeMatchId = action.payload;
    },
    updateMessages(state, action) {
      state.messages = state.messages || [];
      state.messages = [...state.messages, action.payload];
    },
    clearMessages(state) {
      state.messages = [];
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getMatches.pending, (state) => {
        state.getMatchesLoading = true;
      })
      .addCase(
        getMatches.fulfilled,
        (state, action: PayloadAction<Array<MatchDto> | null>) => {
          state.getMatchesLoading = false;
          state.matches = action.payload;
        }
      )
      .addCase(getMatches.rejected, (state) => {
        state.getMatchesLoading = false;
      })
      .addCase(getMessages.pending, (state) => {
        state.getMessagesLoading = true;
      })
      .addCase(
        getMessages.fulfilled,
        (state, action: PayloadAction<Array<MessageDto> | null>) => {
          state.getMessagesLoading = false;
          state.messages = action.payload;
        }
      )
      .addCase(getMessages.rejected, (state) => {
        state.getMessagesLoading = false;
      })
      .addCase(createMatch.pending, (state) => {
        state.isCreatingMatch = true;
      })
      .addCase(createMatch.fulfilled, (state, action) => {
        state.isCreatingMatch = false;
        state.matchFromCreate = action.payload;
      })
      .addCase(createMatch.rejected, (state) => {
        state.isCreatingMatch = false;
      })
      .addCase(deleteMatch.pending, (state) => {
        state.deletingMatch = true;
      })
      .addCase(deleteMatch.fulfilled, (state, action) => {
        state.deletingMatch = false;
        if (state.matches) {
          state.matches = state.matches?.filter(
            (match) => match.id !== action.meta.arg
          );
        }
      })
      .addCase(deleteMatch.rejected, (state) => {
        state.deletingMatch = false;
      });
  },
});

export const { setActiveMatchId, updateMessages, clearMessages } =
  matchSlice.actions;

export default matchSlice.reducer;
