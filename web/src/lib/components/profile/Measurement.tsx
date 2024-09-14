import {
  Box,
  Text,
  Slider,
  SliderTrack,
  SliderFilledTrack,
  SliderThumb,
} from "@chakra-ui/react";
import { useState } from "react";
import { Descriptor as DescriptorType } from "shared/src/types/openApiGen";

const Measurement = ({ descriptor }: { descriptor: DescriptorType }) => {
  const [value, setValue] = useState(descriptor.measurableDetails?.min || 0);

  console.log(descriptor);
  return (
    <Box>
      <Text mb={2}>{descriptor.prompt}</Text>
      <Slider
        aria-label="slider"
        min={descriptor.measurableDetails?.min!}
        max={descriptor.measurableDetails?.max!}
        value={value}
        onChange={setValue}
      >
        <SliderTrack>
          <SliderFilledTrack />
        </SliderTrack>
        <SliderThumb />
      </Slider>
      <Text mt={2}>
        {value} {descriptor.measurableDetails?.unitOfMeasure}
      </Text>
    </Box>
  );
};

export default Measurement;
