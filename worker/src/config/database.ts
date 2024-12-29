import dotenv from "dotenv";
import { Pool } from "pg";

dotenv.config();

export const pool = new Pool({
  connectionString: process.env.DATABASE_URL,
});

// Utility to get a database client
export const getClient = async () => {
  return await pool.connect();
};
