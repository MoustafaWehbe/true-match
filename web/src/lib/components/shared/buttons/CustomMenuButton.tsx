import { ChevronDownIcon } from "@chakra-ui/icons";
import {
  Button,
  Menu,
  MenuButton,
  MenuItem,
  MenuList,
  useColorModeValue,
} from "@chakra-ui/react";

export type Option = { label: string; value: string | number };

interface Props {
  options: Option[];
  placeholder: string;
  selectedOption?: Option;
  handleSelect: (option: Option) => void;
}

function CustomMenuButton({
  options,
  placeholder,
  selectedOption,
  handleSelect,
}: Props) {
  const bg = useColorModeValue("pink.100", "pink.800");
  const hoverBg = useColorModeValue("pink.200", "pink.700");
  const activeBg = useColorModeValue("pink.300", "pink.600");
  const borderColor = useColorModeValue("pink.500", "pink.300");
  const textColor = useColorModeValue("pink.700", "pink.200");

  return (
    <Menu>
      <MenuButton
        as={Button}
        rightIcon={<ChevronDownIcon />}
        bg={bg}
        _hover={{ bg: hoverBg }}
        _active={{ bg: hoverBg }}
        color={textColor}
        size={"sm"}
      >
        {selectedOption?.label || placeholder}
      </MenuButton>
      <MenuList bg={bg} borderColor={borderColor}>
        {options.map((option, index) => (
          <MenuItem
            key={index}
            bg={bg}
            _hover={{ bg: hoverBg }}
            _focus={{ bg: activeBg }}
            _active={{ bg: activeBg }}
            onClick={() => handleSelect(option)}
          >
            {option.label}
          </MenuItem>
        ))}
      </MenuList>
    </Menu>
  );
}

export default CustomMenuButton;
