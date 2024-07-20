'use client';

import type { ReactNode } from 'react';

import { AUTH_ROUTES } from '../consts';
import MainLayout from './MainLayout';
import AuthLayout from './AuthLayout';

export type LayoutProps = {
  children: ReactNode;
};

const Layout = ({ children }: LayoutProps) => {
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
