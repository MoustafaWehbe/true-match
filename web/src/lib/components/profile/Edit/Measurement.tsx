import React, { useMemo, useState } from "react";
import { useSelector } from "react-redux";
import { Box, Flex, FormControl, Input, Text } from "@chakra-ui/react";

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
  const [value, setValue] = useState<number>(
    parseFloat(existingDescValue?.singleValue!) || 0
  );

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const value = parseFloat(e.target.value) || 0;

    setValue(value);
    onSelect({
      availableDescriptorId,
      descriptorId: descriptor.id,
      singleValue: e.target.value,
    });
  };

  return (
    <Box maxW="sm" mx="auto" p={4}>
      <FormControl>
        <Text mb={2}>{descriptor.prompt}</Text>
        <Flex gap={4}>
          <Input
            id="height"
            type="text"
            value={value}
            onChange={onChange}
            min={descriptor.measurableDetails?.min!}
            max={descriptor.measurableDetails?.max!}
          />
          <Text mt={2}>{descriptor.measurableDetails?.unitOfMeasure}</Text>
        </Flex>
      </FormControl>
    </Box>
  );
};

export default Measurement;
