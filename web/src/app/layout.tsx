import type { Metadata, Viewport } from "next";

import Providers from "~/app/providers";
import Layout from "~/lib/layout";

type RootLayoutProps = {
  children: React.ReactNode;
};

const APP_NAME = "truematch";

export const metadata: Metadata = {
  title: { default: APP_NAME, template: "%s | truematch" },
  description: "Next.js + chakra-ui + TypeScript template",
  applicationName: APP_NAME,
  appleWebApp: {
    capable: true,
    title: APP_NAME,
    statusBarStyle: "default",
  },
  formatDetection: {
    telephone: false,
  },
  openGraph: {
    url: "",
    title: "truematch",
    description: "Next.js + chakra-ui + TypeScript template",
    images: {
      url: "",
      alt: "og-image",
    },
  },
  twitter: {
    creator: "@sozonome",
    card: "summary_large_image",
  },
};

export const viewport: Viewport = {
  width: "device-width",
  initialScale: 1,
  themeColor: "#FFFFFF",
};

const RootLayout = ({ children }: RootLayoutProps) => {
  return (
    <html lang="en">
      <body>
        <Providers>
          <Layout>{children}</Layout>
        </Providers>
      </body>
    </html>
  );
};

export default RootLayout;
