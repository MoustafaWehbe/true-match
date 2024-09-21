import { createAsyncThunk, createSlice, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";

import {
  QuestionCategoryDto,
  QuestionCategoryDtoListApiResponse,
  SystemQuestionDto,
  SystemQuestionDtoListApiResponse,
} from "@dapp/shared/src/types/openApiGen";

import axiosInstance, { defaultHeaders } from "~/lib/utils/api/axiosConfig";

export interface QuestionSate {
  categories: Array<QuestionCategoryDto> | null;
  systemQuestions: Array<SystemQuestionDto> | null;
  categoriesLoading: boolean;
  systemQuestionsLoading: boolean;
}

export const getQuestionCategories = createAsyncThunk<
  Array<QuestionCategoryDto> | null,
  undefined,
  { rejectValue: string }
>("question/get-all-categories", async (_, { rejectWithValue }) => {
  try {
    const response =
      await axiosInstance.get<QuestionCategoryDtoListApiResponse>(
        "/api/question-category",
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

export const getSystemQuestions = createAsyncThunk<
  Array<SystemQuestionDto> | null,
  { categories?: number[] },
  { rejectValue: string }
>("question/system-question", async (params, { rejectWithValue }) => {
  try {
    const searchParams = new URLSearchParams();
    params.categories?.forEach((category) =>
      searchParams.append("categories", category.toString())
    );

    const response = await axiosInstance.get<SystemQuestionDtoListApiResponse>(
      "/api/system-question",
      {
        params: searchParams,
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

const initialState: QuestionSate = {
  categoriesLoading: false,
  systemQuestionsLoading: false,
  categories: null,
  systemQuestions: null,
};

const questionSlice = createSlice({
  name: "question",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getQuestionCategories.pending, (state) => {
        state.categoriesLoading = true;
      })
      .addCase(
        getQuestionCategories.fulfilled,
        (state, action: PayloadAction<Array<QuestionCategoryDto> | null>) => {
          state.categoriesLoading = false;
          state.categories = action.payload;
        }
      )
      .addCase(getQuestionCategories.rejected, (state) => {
        state.categoriesLoading = false;
      })
      .addCase(getSystemQuestions.pending, (state) => {
        state.systemQuestionsLoading = true;
      })
      .addCase(
        getSystemQuestions.fulfilled,
        (state, action: PayloadAction<Array<SystemQuestionDto> | null>) => {
          state.systemQuestionsLoading = false;
          state.systemQuestions = action.payload;
        }
      )
      .addCase(getSystemQuestions.rejected, (state) => {
        state.systemQuestionsLoading = false;
      });
  },
});

export default questionSlice.reducer;
