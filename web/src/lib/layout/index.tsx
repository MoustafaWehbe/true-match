'use client';

import { useEffect, useState, type ReactNode } from 'react';

import { AUTH_ROUTES } from '../consts';
import MainLayout from './MainLayout';
import AuthLayout from './AuthLayout';
import { useDispatch } from 'react-redux';
import { AppDispatch } from '../state/store';
import { fetchUser } from '../state/user/userSlice';

export type LayoutProps = {
  children: ReactNode;
};

const Layout = ({ children }: LayoutProps) => {
  const [isMounted, setIsMounted] = useState(false);
  const dispatch = useDispatch<AppDispatch>();

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

  if (typeof window !== 'undefined') {
    return AUTH_ROUTES.includes(window.location.pathname.slice(1)) ? (
      <AuthLayout children={children} />
    ) : (
      <MainLayout children={children} />
    );
  }
  return <AuthLayout children={children} />;
};

export default Layout;
