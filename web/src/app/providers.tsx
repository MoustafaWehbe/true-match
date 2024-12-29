"use client";

import { Provider } from "react-redux";
import { CacheProvider } from "@chakra-ui/next-js";
import { AppProgressBar as ProgressBar } from "next-nprogress-bar";

import { Chakra as ChakraProvider } from "~/lib/components/Chakra";
import { store } from "~/lib/state/store";

const Providers = ({ children }: { children: React.ReactNode }) => {
  return (
    <CacheProvider>
      <Provider store={store}>
        <ChakraProvider>{children}</ChakraProvider>
        <ProgressBar
          height="4px"
          color="pink"
          options={{ showSpinner: false }}
          shallowRouting
        />
      </Provider>
    </CacheProvider>
  );
};

export default Providers;
