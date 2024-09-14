import { Box, Text, Stack, RadioGroup, Radio } from "@chakra-ui/react";
import { useState } from "react";
import { Descriptor as DescriptorType } from "shared/src/types/openApiGen";

const SingleSelection = ({ descriptor }: { descriptor: DescriptorType }) => {
  const [value, setValue] = useState("");

  return (
    <Box>
      <Text mb={2}>{descriptor.prompt}</Text>
      <RadioGroup onChange={setValue} value={value}>
        <Stack direction="row">
          {descriptor.choices?.map((choice) => (
            <Radio key={choice.id} value={choice.id!}>
              {choice.name}
            </Radio>
          ))}
        </Stack>
      </RadioGroup>
    </Box>
  );
};

export default SingleSelection;
