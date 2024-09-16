import {
  Box,
  Text,
  Wrap,
  WrapItem,
  Button,
  useColorMode,
} from "@chakra-ui/react";
import { useEffect, useMemo, useState } from "react";
import { useSelector } from "react-redux";
import {
  Descriptor as DescriptorType,
  SelectedDescriptor,
} from "shared/src/types/openApiGen";
import { RootState } from "~/lib/state/store";

const SingleSelection = ({
  descriptor,
  onSelect,
  availableDescriptorId,
}: {
  descriptor: DescriptorType;
  availableDescriptorId: number;
  onSelect: (desc: SelectedDescriptor) => void;
}) => {
  const [selectedChoice, setSelectedChoice] = useState<string>();
  const { user } = useSelector((state: RootState) => state.user);
  const { colorMode } = useColorMode();

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
    if (existingDescValue?.choicesIds?.length) {
      setSelectedChoice(existingDescValue?.choicesIds[0]);
    }
  }, [existingDescValue]);

  const handleSelect = (id: string) => {
    if (selectedChoice === id) {
      setSelectedChoice(undefined);
    } else {
      setSelectedChoice(id);
      onSelect({
        availableDescriptorId,
        descriptorId: descriptor.id,
        choicesIds: [id],
      });
    }
  };

  return (
    <Box>
      <Text mb={2}>{descriptor.prompt}</Text>
      <Wrap spacing={4} justify={"center"}>
        {descriptor.choices?.map((choice) => (
          <WrapItem key={choice.id} width="auto" justifyContent={"center"}>
            <Button
              key={choice.id}
              variant={selectedChoice === choice.id ? "solid" : "outline"}
              colorScheme={"pink"}
              display="flex"
              flexDirection="column"
              alignItems="center"
              height="40px"
              width="auto"
              onClick={() => handleSelect(choice.id!)}
              _hover={{
                bg:
                  colorMode === "light"
                    ? `${choice.style}.100`
                    : `${choice.style}.900`,
              }}
            >
              <Text
                fontSize="sm"
                fontWeight="bold"
                whiteSpace={"normal"}
                overflow="hidden"
                textOverflow="ellipsis"
              >
                {choice.name}
              </Text>
            </Button>
          </WrapItem>
        ))}
      </Wrap>
    </Box>
  );
};

export default SingleSelection;
