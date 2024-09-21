import axios from "axios";

import { TOKEN } from "../../consts/localStorage";

import env from "~/lib/consts/env";

export const defaultHeaders = {
  "Content-Type": "application/json",
};

const axiosInstance = axios.create({
  baseURL: env.apiUrl,
});

// Response Interceptor
axiosInstance.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response) {
      const { status } = error.response;

      if (
        status === 401 &&
        window.location.pathname !== "/login" &&
        window.location.pathname !== "/signup"
      ) {
        window.location.href = "/login";
      }
    }
    return Promise.reject(error);
  }
);

// Request Interceptor
axiosInstance.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem(TOKEN);
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default axiosInstance;
