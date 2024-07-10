import { drawerAnatomy as parts } from '@chakra-ui/anatomy';
import { createMultiStyleConfigHelpers } from '@chakra-ui/styled-system';

const { definePartsStyle, defineMultiStyleConfig } =
  createMultiStyleConfigHelpers(parts.keys);

const baseStyle = definePartsStyle({
  dialog: {
    borderRadius: 'md',
    transition: 'none',
    transform: 'none!important',
    width: 'var(--chakra-sizes-md)',
    maxWidth: 'unset',
  },
  dialogContainer: {
    width: 'auto',
  },
});

export const Drawer = defineMultiStyleConfig({
  baseStyle,
  defaultProps: {
    size: 'xs',
  },
});
