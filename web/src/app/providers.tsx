'use client';

import { CacheProvider } from '@chakra-ui/next-js';
import { Provider } from 'react-redux';

import { Chakra as ChakraProvider } from '~/lib/components/Chakra';
import { store } from '~/lib/state/store';

const Providers = ({ children }: { children: React.ReactNode }) => {
  return (
    <CacheProvider>
      <Provider store={store}>
        <ChakraProvider>{children}</ChakraProvider>
      </Provider>
    </CacheProvider>
  );
};

export default Providers;
