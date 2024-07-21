'use client';

import {
  Box,
  Button,
  Container,
  FormLabel,
  Heading,
  Input,
  Link,
  Stack,
  Text,
  useColorModeValue,
} from '@chakra-ui/react';
import { FormControl, FormErrorMessage, useToast } from '@chakra-ui/react';
import { useFormik } from 'formik';
import { useRouter } from 'next/navigation';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import * as Yup from 'yup';
import { AppDispatch, RootState } from '~/lib/state/store';
import { loginUser } from '~/lib/state/user/userSlice';

function SignupForm() {
  const toast = useToast();
  const dispatch = useDispatch<AppDispatch>();
  const { loginLoading, loginError, loginResult } = useSelector(
    (state: RootState) => state.user
  );
  const router = useRouter();

  useEffect(() => {
    if (loginResult?.statusCode === 200) {
      toast({
        title: 'Registration Succeeded!',
        status: 'success',
        duration: 5000,
        isClosable: true,
      });
      if (window) {
        window.location.href = '/';
      } else {
        router.push('/');
      }
    }
  }, [loginResult]);

  useEffect(() => {
    if (loginError) {
      toast({
        title: 'Login Error',
        description: loginError,
        status: 'error',
        duration: 5000,
        isClosable: true,
      });
    }
  }, [loginError, toast]);

  const formik = useFormik({
    initialValues: {
      email: '',
      password: '',
    },
    onSubmit: (values) => {
      dispatch(
        loginUser({
          ...values,
        })
      );
      formik.handleReset({});
    },
    validationSchema: Yup.object({
      email: Yup.string()
        .required('Email Address cannot be empty')
        .email('Looks like this is not an email'),
      password: Yup.string().required('Password cannot be empty'),
    }),
    validateOnChange: true,
  });

  const containerBg = useColorModeValue('whiteAlpha.900', 'gray.800');
  const headingColor = useColorModeValue('gray.800', 'white');
  const textColor = useColorModeValue('gray.600', 'gray.400');
  const linkColor = useColorModeValue('pink.400', 'pink.300');
  const buttonBg = useColorModeValue('pink.400', 'pink.500');
  const buttonHoverBg = useColorModeValue('pink.500', 'pink.400');

  return (
    <Container maxW="lg" pb="20px">
      <Stack
        spacing={2}
        mx="auto"
        maxW="lg"
        py={8}
        px={6}
        bg={containerBg}
        borderRadius="lg"
        boxShadow="xl"
      >
        <Stack align="center">
          <Heading fontSize="4xl" color={headingColor}>
            Sign in to your account
          </Heading>
          <Text fontSize="lg" color={textColor}>
            to find your perfect match ❤️
          </Text>
        </Stack>
        <Box rounded="lg" p={8}>
          <Stack spacing={4}>
            <form autoComplete="off" onSubmit={formik.handleSubmit}>
              <FormControl
                mb={5}
                id="email"
                isInvalid={!!(formik.touched.email && formik.errors.email)}
              >
                <FormLabel>Email</FormLabel>
                <Input
                  size="lg"
                  type="email"
                  name="email"
                  placeholder="Email Address"
                  value={formik.values.email}
                  onChange={formik.handleChange}
                  bg={useColorModeValue('white', 'gray.700')}
                  color={useColorModeValue('gray.800', 'white')}
                  borderColor={useColorModeValue('gray.300', 'gray.600')}
                  _placeholder={{
                    color: useColorModeValue('gray.500', 'gray.400'),
                  }}
                />
                {formik.touched.email && formik.errors.email && (
                  <FormErrorMessage>{formik.errors.email}</FormErrorMessage>
                )}
              </FormControl>
              <FormControl
                mb={5}
                id="password"
                isInvalid={
                  !!(formik.touched.password && formik.errors.password)
                }
              >
                <FormLabel>Password</FormLabel>
                <Input
                  size="lg"
                  type="password"
                  name="password"
                  placeholder="Password"
                  value={formik.values.password}
                  onChange={formik.handleChange}
                  bg={useColorModeValue('white', 'gray.700')}
                  color={useColorModeValue('gray.800', 'white')}
                  borderColor={useColorModeValue('gray.300', 'gray.600')}
                  _placeholder={{
                    color: useColorModeValue('gray.500', 'gray.400'),
                  }}
                />
                {formik.touched.password && formik.errors.password && (
                  <FormErrorMessage>{formik.errors.password}</FormErrorMessage>
                )}
              </FormControl>

              <Stack spacing={10} mt={10}>
                <Button
                  bg={buttonBg}
                  color="white"
                  _hover={{ bg: buttonHoverBg }}
                  type="submit"
                  isLoading={loginLoading}
                  loadingText="Logging in..."
                >
                  Sign in
                </Button>
                <Stack
                  direction={{ base: 'column', sm: 'row' }}
                  align="start"
                  justify="space-between"
                >
                  <Link color={linkColor}>Forgot password?</Link>
                  <Link color={linkColor} href="signup">
                    Create an account
                  </Link>
                </Stack>
              </Stack>
            </form>
          </Stack>
        </Box>
      </Stack>
    </Container>
  );
}

export default SignupForm;
