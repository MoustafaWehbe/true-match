import axios from 'axios';

import env from '~/lib/consts/env';

const axiosInstance = axios.create({
  baseURL: env.apiUrl,
  headers: {
    'Content-Type': 'application/json',
  },
});

export default axiosInstance;
