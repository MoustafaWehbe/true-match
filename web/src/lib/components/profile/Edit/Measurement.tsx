import {
  Box,
  Text,
  Slider,
  SliderTrack,
  SliderFilledTrack,
  SliderThumb,
} from "@chakra-ui/react";
import { useEffect, useMemo, useState } from "react";
import { useSelector } from "react-redux";
import {
  Descriptor as DescriptorType,
  SelectedDescriptor,
} from "@dapp/shared/src/types/openApiGen";
import { RootState } from "~/lib/state/store";

const Measurement = ({
  descriptor,
  onSelect,
  availableDescriptorId,
}: {
  descriptor: DescriptorType;
  availableDescriptorId: number;
  onSelect: (desc: SelectedDescriptor) => void;
}) => {
  const [value, setValue] = useState<number>();
  const { user } = useSelector((state: RootState) => state.user);

  const existingDescValue = useMemo(
    () =>
      user?.userProfile?.selectedDescriptors?.find(
        (desc) =>
          desc.availableDescriptorId === availableDescriptorId &&
          desc.descriptorId === descriptor.id
      ),
    [
      availableDescriptorId,
      descriptor.id,
      user?.userProfile?.selectedDescriptors,
    ]
  );

  useEffect(() => {
    setValue(
      existingDescValue?.singleValue ||
        Math.round(
          (descriptor.measurableDetails?.min! +
            descriptor.measurableDetails?.max!) /
            2
        )
    );
  }, [descriptor.measurableDetails, existingDescValue?.singleValue]);

  const onChange = (value: number) => {
    setValue(value);
    onSelect({
      availableDescriptorId,
      descriptorId: descriptor.id,
      singleValue: value,
    });
  };

  return (
    <Box>
      <Text mb={2}>{descriptor.prompt}</Text>
      <Slider
        aria-label="slider"
        min={descriptor.measurableDetails?.min!}
        max={descriptor.measurableDetails?.max!}
        value={value}
        onChangeEnd={onChange}
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
