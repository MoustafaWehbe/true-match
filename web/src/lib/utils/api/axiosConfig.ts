// import { createStandaloneToast } from "@chakra-ui/react";
import axios, { AxiosError } from "axios";

import { TOKEN } from "../../consts/localStorage";

import env from "~/lib/consts/env";

export const defaultHeaders = {
  "Content-Type": "application/json",
};

// const toast = createStandaloneToast();

const axiosInstance = axios.create({
  baseURL: env.apiUrl,
});

// Response Interceptor
axiosInstance.interceptors.response.use(
  (response) => {
    return response;
  },
  (error: AxiosError) => {
    if (error.response) {
      const { status } = error.response;

      if (
        status === 401 ||
        (status === 404 &&
          error.config?.url === "/me" &&
          window.location.pathname !== "/login" &&
          window.location.pathname !== "/signup")
      ) {
        window.location.href = "/login";
      }

      // if (error.response.status < 200 || error.response.status >= 300) {
      //   const data = error.response.data as any | undefined;
      //   const message = data?.message || data?.title;
      //   toast.toast({
      //     title: "Error Occurred",
      //     description: message || "An error occurred!",
      //     status: "error",
      //     duration: 5000,
      //     isClosable: true,
      //   });
      // }
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
