"use client";

import { Box, Flex, useMediaQuery } from "@chakra-ui/react";

import DrawerMobile from "../components/drawer/DrawerMobile";
import Sidebar from "../components/drawer/Sidebar";
import Footer from "../components/layout/Footer";
import Header from "../components/layout/Header";
import { size } from "../consts";

import { LayoutProps } from ".";

const MainLayout = ({ children }: LayoutProps) => {
  const [isTabletOrMobile] = useMediaQuery(`(max-width: ${size.laptop})`);

  return (
    <Box>
      <Header />
      <Flex>
        {isTabletOrMobile ? <DrawerMobile /> : <Sidebar />}
        <Box
          margin="0 auto"
          width={"100%"}
          maxWidth={{ base: "100vw", md: "65%", lg: "75%" }}
          transition="0.5s ease-out"
          minHeight={"90vh"}
          as="main"
          marginY={22}
          display={"flex"}
          flexDirection={"column"}
          justifyContent={"space-between"}
        >
          <Box marginBottom={5}>{children}</Box>
          <Box>
            <Footer />
          </Box>
        </Box>
      </Flex>
    </Box>
  );
};

export default MainLayout;
