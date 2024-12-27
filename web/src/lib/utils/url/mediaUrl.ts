import env from "~/lib/consts/env";

export const constructMediaUrl = (url?: string | null) => {
  if (!url) {
    return "";
  }
  return url.startsWith("http") ? url : env.apiUrl + "" + url;
};
