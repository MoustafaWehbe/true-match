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
} from '@chakra-ui/react';
import { FormControl, FormErrorMessage, useToast } from '@chakra-ui/react';
import { useFormik } from 'formik';
import * as Yup from 'yup';

function SignupForm() {
  const toast = useToast();

  const formik = useFormik({
    initialValues: {
      email: '',
      password: '',
    },
    onSubmit: (values) => {
      toast({
        title: 'Account created.',
        status: 'success',
        duration: 3000,
        isClosable: true,
      });
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

  return (
    <Container maxW="lg" pb="20px">
      <Stack
        spacing={2}
        mx="auto"
        maxW="lg"
        py={8}
        px={6}
        bg="whiteAlpha.900"
        borderRadius="lg"
        boxShadow="xl"
      >
        <Stack align="center">
          <Heading fontSize="4xl" color="gray.800">
            Sign in to your account
          </Heading>
          <Text fontSize="lg" color="gray.600">
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
                />
                {formik.touched.password && formik.errors.password && (
                  <FormErrorMessage>{formik.errors.password}</FormErrorMessage>
                )}
              </FormControl>

              <Stack spacing={10} mt={10}>
                <Button
                  bg="pink.400"
                  color="white"
                  _hover={{
                    bg: 'pink.500',
                  }}
                  type="submit"
                >
                  Sign in
                </Button>
                <Stack
                  direction={{ base: 'column', sm: 'row' }}
                  align="start"
                  justify="space-between"
                >
                  <Link color="pink.400">Forgot password?</Link>
                  <Link color="pink.400" href="signup">
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
