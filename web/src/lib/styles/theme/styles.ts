import type { DeepPartial, Theme } from "@chakra-ui/react";

export const styles: DeepPartial<Theme["styles"]> = {
  global: (props: any) => {
    return {
      ".profile-geocoder input": {
        color: props.colorMode === "dark" ? "white" : "black",
        // "div[role='option']": {
        //   color: "black!important",
        //   // ":hover": {
        //   // },
        // },
      },
      "::placeholder": {
        color: "#A0AEBF!important",
      },

      /* Chrome, Safari and Edge */
      // "::-webkit-scrollbar": {
      //   width: "4px!important",
      //   height: "4px!important",
      // },
      // "::-webkit-scrollbar-track": {
      //   background: "#f1f1f1!important",
      // },
      // "::-webkit-scrollbar-thumb": {
      //   background: "#a892a8!important",
      //   borderRadius: "10px!important",
      // },
      // "::-webkit-scrollbar-thumb:hover": {
      //   background: "#555!important",
      // },
      // styles for the `body`
      // body: {
      //   bg: 'gray.400',
      //   color: 'white',
      // },
      // styles for the `a`
      // a: {
      //   color: 'teal.500',
      //   _hover: {
      //     textDecoration: 'underline',
      //   },
      // },
    };
  },
};
