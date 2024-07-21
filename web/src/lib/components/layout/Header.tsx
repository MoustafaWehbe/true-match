import {
  Flex,
  Heading,
  Icon,
  Input,
  InputGroup,
  InputRightAddon,
} from '@chakra-ui/react';
import { CiUser } from 'react-icons/ci';

import HeaderPopover from '../header/HeaderPopover';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '~/lib/state/store';
import { logout } from '~/lib/state/user/userSlice';

const Header = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { user } = useSelector((state: RootState) => state.user);

  const onLogout = () => {
    dispatch(logout());
    window.location.href = '/login';
  };

  return (
    <Flex
      as="nav"
      p="5"
      mb="3px"
      alignItems="center"
      width="full"
      align="center"
      height={'60px'}
      justifyContent={'space-between'}
      boxShadow="rgba(0, 0, 0, 0.12) 0px 1px 1px"
    >
      <Heading as="h1" fontSize="1.5em">
        DAPP
      </Heading>
      <InputGroup size="md" flex={1} maxWidth={'40%'}>
        <Input placeholder="mysite" rounded={'25px'} />
        <InputRightAddon
          borderBottomRightRadius={'25px'}
          borderTopRightRadius={'25px'}
        >
          <Icon as={CiUser} />
        </InputRightAddon>
      </InputGroup>
      {user && <HeaderPopover onLogout={onLogout} user={user} />}
    </Flex>
  );
};

export default Header;
