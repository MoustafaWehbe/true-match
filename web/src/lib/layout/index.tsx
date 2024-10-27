"use client";

import { type ReactNode, useEffect, useState } from "react";
import { useDispatch } from "react-redux";

import { AUTH_ROUTES, ONBOARDING_ROUTE, ROOM_ROUTE } from "../consts";
import useProfileGuard from "../hooks/useProfileGuard";
import { AppDispatch } from "../state/store";
import { fetchUser } from "../state/user/userSlice";

import AuthLayout from "./AuthLayout";
import MainLayout from "./MainLayout";
import OnboardingLayout from "./OnboardingLayout";
import RoomLayout from "./RoomLayout";

export type LayoutProps = {
  children: ReactNode;
};

const Layout = ({ children }: LayoutProps) => {
  const [isMounted, setIsMounted] = useState(false);
  const dispatch = useDispatch<AppDispatch>();

  useProfileGuard();

  useEffect(() => {
    setIsMounted(true);
  }, []);

  useEffect(() => {
    dispatch(fetchUser());
  }, [dispatch]);

  if (!isMounted) {
    // Render nothing or a loading state while determining the layout
    return null;
  }

  if (typeof window !== "undefined") {
    return AUTH_ROUTES.includes(window.location.pathname.slice(1)) ? (
      <AuthLayout>{children}</AuthLayout>
    ) : window.location.pathname.slice(1).includes(ONBOARDING_ROUTE) ? (
      <OnboardingLayout>{children}</OnboardingLayout>
    ) : /^\/rooms\/\d+$/.test(window.location.pathname) ? (
      <RoomLayout>{children}</RoomLayout>
    ) : (
      <MainLayout>{children}</MainLayout>
    );
  }
  return <AuthLayout>{children}</AuthLayout>;
};

export default Layout;
