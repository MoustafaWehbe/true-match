import { drawerAnatomy as parts } from "@chakra-ui/anatomy";
import { createMultiStyleConfigHelpers } from "@chakra-ui/styled-system";

const { definePartsStyle, defineMultiStyleConfig } =
  createMultiStyleConfigHelpers(parts.keys);

const baseStyle = definePartsStyle({
  dialog: {
    borderRadius: "md",
    width: "var(--chakra-sizes-md)",
  },
  dialogContainer: {
    width: "auto",
  },
});

export const Drawer = defineMultiStyleConfig({
  baseStyle,
  defaultProps: {
    size: "xs",
  },
});
