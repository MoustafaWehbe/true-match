import { Button, useColorMode } from '@chakra-ui/react';
import { RiMoonFill, RiSunLine } from 'react-icons/ri';

const ThemeToggle = () => {
  const { colorMode, toggleColorMode } = useColorMode();

  return (
    <Button
      aria-label="theme toggle"
      colorScheme="teal"
      variant="link"
      leftIcon={colorMode === 'light' ? <RiMoonFill /> : <RiSunLine />}
      onClick={toggleColorMode}
    >
      {colorMode === 'light' ? 'Dark mode' : 'Light mode'}
    </Button>
  );
};

export default ThemeToggle;
