import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import { LoginDto, RegisterDto, User, UserApiResponse } from '~/lib/openApiGen';
import axiosInstance from '~/lib/utils/api/axiosConfig';
import { TOKEN } from '~/lib/utils/localStorage';

export interface UserState {
  loginResult: UserApiResponse | null;
  registerResult: UserApiResponse | null;
  registerLoading: boolean;
  loginLoading: boolean;
  loginError: string | null;
  registerError: string | null;
  user: User | null;
}

export interface ExtendedUserApiResponse extends Omit<UserApiResponse, 'data'> {
  data: User & { token: string };
}

export const registerUser = createAsyncThunk<
  ExtendedUserApiResponse, // Return type of the payload creator
  RegisterDto, // First argument to the payload creator
  { rejectValue: string } // Type for rejectWithValue
>('user/registerUser', async (userData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<ExtendedUserApiResponse>(
      '/api/Account/register',
      userData
    );
    localStorage.setItem(TOKEN, response.data.data.token);
    return response.data;
  } catch (error) {
    let errorMessage = 'Something went wrong!';
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
>('user/loginUser', async (userData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post<ExtendedUserApiResponse>(
      '/api/Account/login',
      userData
    );
    // const result = response.data as ExtendedUserApiResponse;
    localStorage.setItem(TOKEN, response.data.data.token);
    return response.data;
  } catch (error) {
    let errorMessage = 'Something went wrong!';
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
>('user/fetchUser', async (_, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.get<UserApiResponse>('/me');
    return response.data.data ?? null;
  } catch (error) {
    let errorMessage = 'Something went wrong!';
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
};

const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    logout(state) {
      state.user = null;
      state.registerError = null;
      state.loginError = null;
      state.loginResult = null;
      state.registerResult = null;
      state.registerLoading = false;
      state.loginLoading = false;
      localStorage.removeItem(TOKEN);
    },
  },
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
          localStorage.setItem('token', action.payload.data.token);
        }
      )
      .addCase(
        registerUser.rejected,
        (state, action: PayloadAction<string | undefined>) => {
          state.registerLoading = false;
          state.registerError = action.payload || 'Unknown error';
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
          state.loginError = action.payload || 'Unknown error';
        }
      )
      .addCase(
        fetchUser.fulfilled,
        (state, action: PayloadAction<User | null>) => {
          state.user = action.payload;
        }
      );
  },
});

export default userSlice.reducer;
export const { logout } = userSlice.actions;
