import axios from "axios";

import * as env from "../utils/env";

const axiosInstance = axios.create({
  baseURL: env.apiUrl,
  timeout: 10000,
  headers: { "Content-Type": "application/json" },
});

export default axiosInstance;
