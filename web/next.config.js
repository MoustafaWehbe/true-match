const withPWA = require("next-pwa")({
  dest: "public",
  disable: process.env.NODE_ENV === "development",
  // add your own icons to src/app/manifest.ts
  // to re-generate manifest.json, you can visit https://tomitm.github.io/appmanifest/
});

/** @type {import('next').NextConfig} */
module.exports = withPWA({
  swcMinify: true,
  reactStrictMode: false,
  eslint: {
    dirs: ["src"],
  },
  redirects: [
    {
      source: "/",
      destination: "/browse-rooms",
      permanent: true,
    },
  ],
});
