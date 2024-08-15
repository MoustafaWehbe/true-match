import { extendTheme } from "@chakra-ui/react";

import { colors } from "./colors";
import { components } from "./components";
import { config } from "./config";
import { fonts } from "./fonts";
import { fontSizes } from "./fontSizes";
import { fontWeights } from "./fontWeights";
import { letterSpacings } from "./letterSpacings";
import { lineHeights } from "./lineHeights";
import { styles } from "./styles";

const customTheme = extendTheme({
  fonts,
  fontSizes,
  fontWeights,
  lineHeights,
  letterSpacings,
  colors,
  config,
  components,
  styles,
});

export default customTheme;
