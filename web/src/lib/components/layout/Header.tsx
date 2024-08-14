import {
  Avatar,
  Box,
  Button,
  Flex,
  Heading,
  Icon,
  Input,
  InputGroup,
  InputRightAddon,
  keyframes,
  Link,
  Stack,
  Text,
  useColorModeValue,
} from '@chakra-ui/react';
import { CiUser } from 'react-icons/ci';

import HeaderPopover from '../header/HeaderPopover';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '~/lib/state/store';
import { logoutUser } from '~/lib/state/user/userSlice';
import { useEffect } from 'react';

const Header = () => {
  const dispatch = useDispatch<AppDispatch>();
  const { user, logoutResponseMessage } = useSelector(
    (state: RootState) => state.user
  );

  useEffect(() => {
    if (logoutResponseMessage) {
      window.location.href = '/login';
    }
  });

  const onLogout = () => {
    dispatch(logoutUser());
  };
  const bgColor = useColorModeValue('whiteAlpha.900', 'gray.700');
  const textColor = useColorModeValue('gray.800', 'whiteAlpha.900');
  const hoverColor = useColorModeValue('pink.500', 'pink.300');
  const borderColor = useColorModeValue('gray.200', 'gray.600');

  const bounceAnimation = keyframes`
    0%, 100% {
      transform: translateY(0);
    }
    50% {
      transform: translateY(-5px);
    }
  `;

  return (
    <Flex
      as="nav"
      p="5"
      mb="3px"
      alignItems="center"
      width="full"
      height="60px"
      justifyContent="space-between"
      bg={bgColor}
      boxShadow="rgba(0, 0, 0, 0.12) 0px 1px 1px"
      borderRadius="lg"
      border={`1px solid ${borderColor}`}
      // bgImage={useColorModeValue(
      //   'url(/images/pink-hearts.jpg)',
      //   'url(/images/pink-hearts.jpg)'
      // )}
      // bgSize="cover"
      // bgRepeat="repeat"
      // bgPosition="center"
    >
      <Box animation={`${bounceAnimation} 2s infinite`}>
        <Heading
          as={Link}
          href="/"
          fontSize="1.5em"
          color={textColor}
          _hover={{ textDecoration: 'none', color: hoverColor }}
        >
          DAPP
        </Heading>
      </Box>

      {user && <HeaderPopover onLogout={onLogout} user={user} />}
    </Flex>
  );
};

export default Header;
