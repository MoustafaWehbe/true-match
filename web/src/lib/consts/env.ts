import * as Yup from 'yup';

const envSchema = Yup.object().shape({
  NEXT_PUBLIC_API_URL: Yup.string().required(),
  NODE_ENV: Yup.string(),
});

// Validate and extract the environment variables
const envVars = {
  NEXT_PUBLIC_API_URL: process.env.NEXT_PUBLIC_API_URL,
  NODE_ENV: process.env.NODE_ENV,
};

envSchema.validateSync(envVars);

export default {
  apiUrl: envVars.NEXT_PUBLIC_API_URL,
  isProd: envVars.NODE_ENV === 'production',
};
