import {
  Avatar,
  Box,
  Button,
  Icon,
  Popover,
  PopoverArrow,
  PopoverBody,
  PopoverContent,
  PopoverFooter,
  PopoverTrigger,
} from '@chakra-ui/react';
import { CiUser } from 'react-icons/ci';
import { IoIosLogOut } from 'react-icons/io';
import ThemeToggle from '~/lib/components/theme/ThemeToggle';

const HeaderPopover = () => (
  <Popover trigger="hover" placement="top-end">
    <PopoverTrigger>
      <Avatar
        size={'sm'}
        name="mario"
        backgroundColor="teal"
        color={'white'}
        cursor={'pointer'}
        mr="20px"
      />
    </PopoverTrigger>
    <PopoverContent width={'170px'}>
      <PopoverArrow />
      <PopoverBody maxWidth={'50px'}>
        <Box mt="10px">
          <Button
            aria-label="theme toggle"
            colorScheme="teal"
            variant="link"
            leftIcon={<Icon as={CiUser} />}
          >
            View profile
          </Button>
        </Box>
        <Box mt="10px">
          <ThemeToggle />
        </Box>
      </PopoverBody>
      <PopoverFooter>
        <Box>
          <Button
            aria-label="theme toggle"
            colorScheme="teal"
            variant="link"
            leftIcon={<Icon as={IoIosLogOut} />}
          >
            Logout
          </Button>
        </Box>
      </PopoverFooter>
    </PopoverContent>
  </Popover>
);

export default HeaderPopover;
