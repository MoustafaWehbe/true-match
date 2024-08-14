'use client';

import { Box, Flex, useMediaQuery } from '@chakra-ui/react';

import Footer from '../components/layout/Footer';
import Header from '../components/layout/Header';
import Sidebar from '../components/drawer/Sidebar';
import DrawerMobile from '../components/drawer/DrawerMobile';
import { size } from '../consts';
import { LayoutProps } from '.';

const MainLayout = ({ children }: LayoutProps) => {
  const [isTabletOrMobile] = useMediaQuery(`(max-width: ${size.laptop})`);

  return (
    <Box>
      <Header />
      <Flex>
        {isTabletOrMobile ? <DrawerMobile /> : <Sidebar />}
        <Box
          margin="0 auto"
          width={'100%'}
          maxWidth={{ base: '100vw', md: '80vw' }} // 100vw for base (screens < 768px), 80vw for md (screens >= 768px)
          transition="0.5s ease-out"
          height={'90vh'}
          display={'flex'}
          flexDirection={'column'}
          justifyContent={'space-between'}
        >
          <Box>
            <Box as="main" marginY={22}>
              {children}
            </Box>
          </Box>
          <Footer />
        </Box>
      </Flex>
    </Box>
  );
};

export default MainLayout;
