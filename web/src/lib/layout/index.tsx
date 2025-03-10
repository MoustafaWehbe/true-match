"use client";

import { type ReactNode, useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { usePathname } from "next/navigation";

import { AUTH_ROUTES, ONBOARDING_ROUTE } from "../consts";
import useProfileGuard from "../hooks/useProfileGuard";
import { AppDispatch } from "../state/store";
import { fetchMe } from "../state/user/userSlice";

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
  const pathname = usePathname();

  useProfileGuard();

  useEffect(() => {
    setIsMounted(true);
  }, []);

  useEffect(() => {
    dispatch(fetchMe());
  }, [dispatch]);

  if (!isMounted) {
    // Render nothing or a loading state while determining the layout
    return null;
  }

  if (typeof window !== "undefined") {
    return AUTH_ROUTES.includes(pathname.slice(1)) ? (
      <AuthLayout>{children}</AuthLayout>
    ) : pathname.slice(1).includes(ONBOARDING_ROUTE) ? (
      <OnboardingLayout>{children}</OnboardingLayout>
    ) : /^\/rooms\/[0-9a-fA-F\-]{36}$/.test(pathname) ? (
      <RoomLayout>{children}</RoomLayout>
    ) : (
      <MainLayout>{children}</MainLayout>
    );
  }
  return <AuthLayout>{children}</AuthLayout>;
};

export default Layout;
