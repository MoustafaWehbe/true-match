import React from "react";
import { Box, useColorModeValue } from "@chakra-ui/react";
import { Geocoder } from "@mapbox/search-js-react";
import { GeocodeFeature } from "@mapbox/search-js-core";
import env from "~/lib/consts/env";
import { BasicInfoType } from "./BasicInfo";
import { UserLocation } from "@dapp/shared/src/types/openApiGen";

const PlaceGeocoder = ({
  basicFormData,
  setBasicFormData,
}: {
  basicFormData: BasicInfoType;
  setBasicFormData: (basicFormData: BasicInfoType) => void;
}) => {
  const onRetrieve = (place: GeocodeFeature) => {
    const locationPayload: UserLocation = {
      longitude: place.geometry.coordinates[0],
      latitude: place.geometry.coordinates[1],
      name: place.properties.name,
      placeFormatted: place.properties.place_formatted,
      fullAddress: place.properties.full_address,
    };
    setBasicFormData({
      ...basicFormData,
      location: locationPayload,
    });
  };

  const textColor = useColorModeValue("#1A202C!important", "#fff!important");
  const bgColor = useColorModeValue("white", "#1A202C");

  const geocoderTheme = {
    variables: {
      colorText: textColor,
      colorBackground: bgColor,
      colorBackgroundHover: "#d1d0cd",
      border: "solid #4A5568;",
      borderRadius: "5px",
      colorPrimary: "white",
      colorSecondary: "white",
      colorBorderActive: useColorModeValue("#ff007a", "#ff007a"),
    },
  };

  // @ts-ignore
  return (
    <Box w="full" className="profile-geocoder">
      {
        // @ts-ignore
        <Geocoder
          options={{
            proximity: {
              lng: -122.431297,
              lat: 37.773972,
            },
          }}
          value={basicFormData?.location?.fullAddress || ""}
          accessToken={env.mapboxAccessToken!}
          theme={geocoderTheme}
          placeholder="Search for a city"
          onRetrieve={onRetrieve}
        />
      }
    </Box>
  );
};

export default PlaceGeocoder;
