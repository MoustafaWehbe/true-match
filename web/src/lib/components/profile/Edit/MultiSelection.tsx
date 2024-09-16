import {
  Box,
  Text,
  Wrap,
  WrapItem,
  Button,
  useColorMode,
  Input,
} from "@chakra-ui/react";
import { useEffect, useMemo, useState } from "react";
import { useSelector } from "react-redux";
import {
  Descriptor as DescriptorType,
  SelectedDescriptor,
} from "shared/src/types/openApiGen";
import { RootState } from "~/lib/state/store";

const MultiSelection = ({
  descriptor,
  onSelect,
  availableDescriptorId,
}: {
  descriptor: DescriptorType;
  availableDescriptorId: number;
  onSelect: (desc: SelectedDescriptor) => void;
}) => {
  const [selectedChoices, setSelectedChoices] = useState<string[]>([]);
  const { colorMode } = useColorMode();
  const [searchTerm, setSearchTerm] = useState("");
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
    if (existingDescValue?.choicesIds?.length) {
      setSelectedChoices(existingDescValue?.choicesIds);
    }
  }, [existingDescValue]);

  const handleSelect = (id: string) => {
    const alreadySelected = selectedChoices.includes(id);
    const updatedSelections = alreadySelected
      ? selectedChoices.filter((opt) => opt !== id)
      : [...selectedChoices, id];
    setSelectedChoices(updatedSelections);
    onSelect({
      availableDescriptorId,
      descriptorId: descriptor.id,
      choicesIds: [...updatedSelections],
    });
  };

  const filteredChoices = descriptor.choices?.filter((choice) =>
    choice.name?.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  return (
    <Box>
      <Text mb={2}>{descriptor.prompt}</Text>
      <Input
        placeholder="Search choices"
        value={searchTerm}
        onChange={handleSearch}
        mb={4}
        variant={"flushed"}
      />
      <Wrap spacing={4} justify={"center"}>
        {filteredChoices?.map((choice) => (
          <WrapItem key={choice.id} width="auto" justifyContent={"center"}>
            <Button
              key={choice.id}
              variant={
                selectedChoices.includes(choice.id!) ? "solid" : "outline"
              }
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

export default MultiSelection;
