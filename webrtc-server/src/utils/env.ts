import * as env from "env-var";

import "dotenv/config";

export const DEPLOY_ENV = env.get("DEPLOY_ENV").default("local").asString();

export const isLocal = DEPLOY_ENV === "local";

export const NODE_ENV = env.get("NODE_ENV").default("development").asString();

export const isDev = NODE_ENV === "development";
export const isProd = NODE_ENV === "production";

export const apiUrl = env.get("API_URL").required().asUrlString();
