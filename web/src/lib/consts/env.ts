import * as Yup from "yup";

const envSchema = Yup.object().shape({
  NEXT_PUBLIC_API_URL: Yup.string().required(),
  NODE_ENV: Yup.string(),
  NEXT_PUBLIC_SOCKET_SERVER_URL: Yup.string().required(),
  NEXT_PUBLIC_MAPBOX_TOKEN: Yup.string().required(),
});

// Validate and extract the environment variables
const envVars = {
  NEXT_PUBLIC_API_URL: process.env.NEXT_PUBLIC_API_URL,
  NODE_ENV: process.env.NODE_ENV,
  NEXT_PUBLIC_SOCKET_SERVER_URL: process.env.NEXT_PUBLIC_SOCKET_SERVER_URL,
  NEXT_PUBLIC_MAPBOX_TOKEN: process.env.NEXT_PUBLIC_MAPBOX_TOKEN,
};

envSchema.validateSync(envVars);

export default {
  apiUrl: envVars.NEXT_PUBLIC_API_URL,
  isProd: envVars.NODE_ENV === "production",
  socketServerUrl: envVars.NEXT_PUBLIC_SOCKET_SERVER_URL,
  mapboxAccessToken: envVars.NEXT_PUBLIC_MAPBOX_TOKEN,
};
