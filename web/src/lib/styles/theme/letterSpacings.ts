import type { DeepPartial, Theme } from '@chakra-ui/react';

export const letterSpacings: DeepPartial<Theme['letterSpacings']> = {
  tighter: '-0.05em',
  tight: '-0.025em',
  normal: '0',
  wide: '0.025em',
  wider: '0.05em',
  widest: '0.1em',
};
