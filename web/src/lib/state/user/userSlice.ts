import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import axios from 'axios';
import { User } from '~/lib/openApiGen';
import axiosInstance from '~/lib/utils/api/axiosConfig';

export interface UserState {
  user: User | null;
  loading: boolean;
  error: string | null;
}

export const registerUser = createAsyncThunk<
  User, // Return type of the payload creator
  { firstName: string; lastName: string; email: string; password: string }, // First argument to the payload creator
  { rejectValue: string } // Type for rejectWithValue
>('user/registerUser', async (userData, { rejectWithValue }) => {
  try {
    const response = await axiosInstance.post(
      '/api/Account/register',
      userData
    );
    return response.data;
  } catch (error) {
    let errorMessage = 'Something went wrong!';
    if (axios.isAxiosError(error) && error.response) {
      errorMessage = error.response.data.message || errorMessage;
    }
    return rejectWithValue(errorMessage);
  }
});

const initialState: UserState = {
  user: null,
  loading: false,
  error: null,
};

const userSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(registerUser.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(registerUser.fulfilled, (state, action: PayloadAction<User>) => {
        state.loading = false;
        state.user = action.payload;
      })
      .addCase(
        registerUser.rejected,
        (state, action: PayloadAction<string | undefined>) => {
          state.loading = false;
          state.error = action.payload || 'Unknown error';
        }
      );
  },
});

export default userSlice.reducer;
