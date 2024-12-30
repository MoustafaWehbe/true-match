"use client";

import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
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
} from "@chakra-ui/react";
import { FormControl, FormErrorMessage, useToast } from "@chakra-ui/react";
import { useFormik } from "formik";
import { useRouter } from "next/navigation";
import * as Yup from "yup";

import { AppDispatch, RootState } from "~/lib/state/store";
import { registerUser } from "~/lib/state/user/userSlice";

function SignupForm() {
  const toast = useToast();
  const dispatch = useDispatch<AppDispatch>();
  const { registerLoading, registerError, registerResult } = useSelector(
    (state: RootState) => state.user
  );
  const router = useRouter();

  useEffect(() => {
    if (registerResult?.statusCode === 200) {
      toast({
        title: "Registration Succeeded!",
        status: "success",
        duration: 5000,
        isClosable: true,
      });
      if (window) {
        window.location.href = "/onboarding";
      } else {
        router.push("/onboarding");
      }
    }
  }, [registerResult, router, toast]);

  useEffect(() => {
    if (registerError && typeof registerError === "string") {
      toast({
        title: "Registration Error",
        description: registerError,
        status: "error",
        duration: 5000,
        isClosable: true,
      });
    }
  }, [registerError, toast]);

  const formik = useFormik({
    initialValues: {
      firstName: "",
      lastName: "",
      email: "",
      password: "",
    },
    onSubmit: async (values, { setErrors }) => {
      const res = await dispatch(
        registerUser({
          ...values,
        })
      );
      // Check if API returns validation errors
      if (res.meta.requestStatus === "rejected" && res.payload?.data) {
        const apiErrors = res.payload?.data.reduce((acc, err) => {
          if (err.code.startsWith("Password")) {
            acc.password = acc.password
              ? `${acc.password}\n${err.description}`
              : err.description;
          }
          return acc;
        }, {});

        setErrors(apiErrors);
      } else {
        formik.handleReset({});
      }
    },
    validationSchema: Yup.object({
      firstName: Yup.string().required("First Name cannot be empty"),
      lastName: Yup.string().required("Last Name cannot be empty"),
      email: Yup.string()
        .required("Email Address cannot be empty")
        .email("Looks like this is not an email"),
      password: Yup.string().required("Password cannot be empty"),
    }),
    validateOnChange: true,
  });

  const containerBg = useColorModeValue("whiteAlpha.900", "gray.800");
  const headingColor = useColorModeValue("gray.800", "white");
  const textColor = useColorModeValue("gray.600", "gray.400");
  const linkColor = useColorModeValue("pink.400", "pink.300");
  const buttonBg = useColorModeValue("pink.400", "pink.500");
  const buttonHoverBg = useColorModeValue("pink.500", "pink.400");

  return (
    <Container minW="lg" pb="20px">
      <Stack
        spacing={2}
        mx="auto"
        maxW="lg"
        py={8}
        px={6}
        bg={containerBg}
        borderRadius="lg"
        boxShadow="xl"
        transition="all 0.3s ease-in-out"
      >
        <Stack align="center">
          <Heading fontSize="4xl" color={headingColor}>
            Create Account
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
                id="firstName"
                isInvalid={
                  !!(formik.touched.firstName && formik.errors.firstName)
                }
              >
                <FormLabel>First Name</FormLabel>
                <Input
                  size="lg"
                  type="text"
                  name="firstName"
                  placeholder="First Name"
                  value={formik.values.firstName}
                  onChange={formik.handleChange}
                  bg={useColorModeValue("white", "gray.700")}
                  color={useColorModeValue("gray.800", "white")}
                  borderColor={useColorModeValue("gray.300", "gray.600")}
                  _placeholder={{
                    color: useColorModeValue("gray.500", "gray.400"),
                  }}
                  transition="border-color 0.2s ease-in-out"
                  _focus={{
                    borderColor: useColorModeValue("pink.400", "pink.300"),
                  }}
                />
                {formik.touched.firstName && formik.errors.firstName && (
                  <FormErrorMessage>{formik.errors.firstName}</FormErrorMessage>
                )}
              </FormControl>
              <FormControl
                mb={5}
                id="lastName"
                isInvalid={
                  !!(formik.touched.lastName && formik.errors.lastName)
                }
              >
                <FormLabel>Last Name</FormLabel>
                <Input
                  size="lg"
                  type="text"
                  name="lastName"
                  placeholder="Last Name"
                  value={formik.values.lastName}
                  onChange={formik.handleChange}
                  bg={useColorModeValue("white", "gray.700")}
                  color={useColorModeValue("gray.800", "white")}
                  borderColor={useColorModeValue("gray.300", "gray.600")}
                  _placeholder={{
                    color: useColorModeValue("gray.500", "gray.400"),
                  }}
                  transition="border-color 0.2s ease-in-out"
                  _focus={{
                    borderColor: useColorModeValue("pink.400", "pink.300"),
                  }}
                />
                {formik.touched.lastName && formik.errors.lastName && (
                  <FormErrorMessage>{formik.errors.lastName}</FormErrorMessage>
                )}
              </FormControl>
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
                  bg={useColorModeValue("white", "gray.700")}
                  color={useColorModeValue("gray.800", "white")}
                  borderColor={useColorModeValue("gray.300", "gray.600")}
                  _placeholder={{
                    color: useColorModeValue("gray.500", "gray.400"),
                  }}
                  transition="border-color 0.2s ease-in-out"
                  _focus={{
                    borderColor: useColorModeValue("pink.400", "pink.300"),
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
                  bg={useColorModeValue("white", "gray.700")}
                  color={useColorModeValue("gray.800", "white")}
                  borderColor={useColorModeValue("gray.300", "gray.600")}
                  _placeholder={{
                    color: useColorModeValue("gray.500", "gray.400"),
                  }}
                  transition="border-color 0.2s ease-in-out"
                  _focus={{
                    borderColor: useColorModeValue("pink.400", "pink.300"),
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
                  isLoading={registerLoading}
                  loadingText="Registering..."
                >
                  Register
                </Button>
                <Stack
                  direction={{ base: "column", sm: "row" }}
                  align="start"
                  justify="space-between"
                >
                  <Link color={linkColor}>Forgot password?</Link>
                  <Link color={linkColor} href="/login">
                    Login instead
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
