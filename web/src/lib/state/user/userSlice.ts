import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";
import {
  BlockUserDto,
  CreateUserProfileDto,
  LoginDto,
  RegisterDto,
  SimpleApiResponseApiResponse,
  User,
  UserApiResponse,
  UserProfileDto,
  UserProfileDtoApiResponse,
} from "shared/src/types/openApiGen";
import axiosInstance, { defaultHeaders } from "~/lib/utils/api/axiosConfig";
import { TOKEN } from "~/lib/consts/localStorage";

export interface UserState {
  loginResult: UserApiResponse | null;
  registerResult: UserApiResponse | null;
  registerLoading: boolean;
  loginLoading: boolean;
  loginError: string | null;
  registerError: string | null;
  user: User | null;
  logoutResponseMessage: string;
  userProfileCreated: boolean;
  loadingImages: string[];
  isBlockingUser: boolean;
  isUnBlockingUser: boolean;
}

export interface ExtendedUserApiResponse extends Omit<UserApiResponse, "data"> {
  data: User & { token: string };
}

export const registerUser = createAsyncThunk<
  ExtendedUserApiResponse, // Return type of the payload creator
  RegisterDto, // First argument to the payload creator
  { rejectValue: string } // Type for rejectWithValue
>("user/registerUser", async (userData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<ExtendedUserApiResponse>(
      "/api/account/register",
      userData,
      { headers: defaultHeaders }
    );
    localStorage.setItem(TOKEN, response.data.data.token);
    return response.data;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const loginUser = createAsyncThunk<
  ExtendedUserApiResponse,
  LoginDto,
  { rejectValue: string }
>("user/loginUser", async (userData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<ExtendedUserApiResponse>(
      "/api/account/login",
      userData,
      { headers: defaultHeaders }
    );
    localStorage.setItem(TOKEN, response.data.data.token);
    return response.data;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const logoutUser = createAsyncThunk<
  SimpleApiResponseApiResponse,
  undefined,
  { rejectValue: string }
>("user/logoutUser", async (_, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<SimpleApiResponseApiResponse>(
      "/api/account/logout",
      { headers: defaultHeaders }
    );
    localStorage.removeItem(TOKEN);
    return response.data;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const fetchUser = createAsyncThunk<
  User | null, // Return type
  void, // Argument type
  { rejectValue: string } // Error type
>("user/fetchUser", async (_, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.get<UserApiResponse>("/me", {
      headers: defaultHeaders,
    });
    return response.data.data ?? null;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const createUserProfile = createAsyncThunk<
  UserProfileDto | undefined, // Return type of the payload creator
  CreateUserProfileDto, // First argument to the payload creator
  { rejectValue: string } // Type for rejectWithValue
>("userProfile/create", async (userProfileData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<UserProfileDtoApiResponse>(
      "/api/user-profile",
      userProfileData,
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

export const createUserMedia = createAsyncThunk<
  string, // Return type of the payload creator
  File, // First argument to the payload creator
  { rejectValue: string } // Type for rejectWithValue
>("media/create", async (file, { rejectWithValue }) => {
  try {
    const formData = new FormData();
    formData.append("file", file);

    const response = await axiosInstance.post<string>("/api/media", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
    return response.data;
  } catch (error) {
    let errorMessage = "Something went wrong!";
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

export const blockUser = createAsyncThunk<
  SimpleApiResponseApiResponse,
  BlockUserDto,
  { rejectValue: string }
>("room/blockUser", async (blockUserDto, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<SimpleApiResponseApiResponse>(
      "/api/user/block-user/",
      blockUserDto,
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

export const unBlockUser = createAsyncThunk<
  SimpleApiResponseApiResponse,
  BlockUserDto,
  { rejectValue: string }
>("room/unblockUser", async (unblockUserDto, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<SimpleApiResponseApiResponse>(
      "/api/user/unblock-user/",
      unblockUserDto,
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

const initialState: UserState = {
  loginResult: null,
  registerResult: null,
  registerLoading: false,
  loginLoading: false,
  loginError: null,
  registerError: null,
  user: null,
  logoutResponseMessage: "",
  userProfileCreated: false,
  loadingImages: [],
  isBlockingUser: false,
  isUnBlockingUser: false,
};

const userSlice = createSlice({
  name: "user",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(registerUser.pending, (state) => {
        state.registerLoading = true;
        state.registerError = null;
      })
      .addCase(
        registerUser.fulfilled,
        (state, action: PayloadAction<ExtendedUserApiResponse>) => {
          state.registerLoading = false;
          state.registerResult = action.payload;
          localStorage.setItem("token", action.payload.data.token);
        }
      )
      .addCase(
        registerUser.rejected,
        (state, action: PayloadAction<string | undefined>) => {
          state.registerLoading = false;
          state.registerError = action.payload || "Unknown error";
        }
      )
      .addCase(loginUser.pending, (state) => {
        state.loginLoading = true;
        state.loginError = null;
      })
      .addCase(
        loginUser.fulfilled,
        (state, action: PayloadAction<ExtendedUserApiResponse>) => {
          state.loginLoading = false;
          state.loginResult = action.payload;
        }
      )
      .addCase(
        loginUser.rejected,
        (state, action: PayloadAction<string | undefined>) => {
          state.loginLoading = false;
          state.loginError = action.payload || "Unknown error";
        }
      )
      .addCase(
        fetchUser.fulfilled,
        (state, action: PayloadAction<User | null>) => {
          state.user = action.payload;
        }
      )
      .addCase(
        logoutUser.fulfilled,
        (state, action: PayloadAction<SimpleApiResponseApiResponse>) => {
          state.user = null;
          state.registerError = null;
          state.loginError = null;
          state.loginResult = null;
          state.registerResult = null;
          state.registerLoading = false;
          state.loginLoading = false;
          state.logoutResponseMessage = action.payload.data?.message ?? "";
        }
      )
      .addCase(createUserProfile.pending, (state) => {
        state.userProfileCreated = false;
      })
      .addCase(
        createUserProfile.fulfilled,
        (state, _action: PayloadAction<UserProfileDto | undefined>) => {
          state.userProfileCreated = true;
        }
      )
      .addCase(createUserProfile.rejected, (state) => {
        state.userProfileCreated = false;
      })
      .addCase(createUserMedia.pending, (state, action) => {
        state.loadingImages.push(action.meta.arg.name);
      })
      .addCase(createUserMedia.fulfilled, (state, action) => {
        state.loadingImages = state.loadingImages.filter(
          (name) => name !== action.meta.arg.name
        );
      })
      .addCase(createUserMedia.rejected, (state, action) => {
        state.loadingImages = state.loadingImages.filter(
          (name) => name !== action.meta.arg.name
        );
      })
      .addCase(blockUser.pending, (state) => {
        state.isBlockingUser = true;
      })
      .addCase(blockUser.fulfilled, (state) => {
        state.isBlockingUser = false;
      })
      .addCase(blockUser.rejected, (state) => {
        state.isBlockingUser = false;
      })
      .addCase(unBlockUser.pending, (state) => {
        state.isUnBlockingUser = true;
      })
      .addCase(unBlockUser.fulfilled, (state) => {
        state.isUnBlockingUser = false;
      })
      .addCase(unBlockUser.rejected, (state) => {
        state.isUnBlockingUser = false;
      });
  },
});

export default userSlice.reducer;
