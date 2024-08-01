'use client';

import {
  Box,
  Button,
  FormControl,
  FormLabel,
  Heading,
  Input,
  Stack,
  Textarea,
  useColorModeValue,
  useToast,
  Container,
  Checkbox,
  Link,
} from '@chakra-ui/react';
import { useFormik } from 'formik';
import { useEffect, useState } from 'react';
import * as Yup from 'yup';

import ContentModal from './ContentModal';
import { useDispatch, useSelector } from 'react-redux';
import { AppDispatch, RootState } from '~/lib/state/store';
import { createRoom } from '~/lib/state/room/roomSlice';

function ScheduleRoom() {
  const toast = useToast();
  const [isChecked, setIsChecked] = useState(false);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const bg = useColorModeValue('whiteAlpha.900', 'gray.700');
  const textColor = useColorModeValue('gray.800', 'whiteAlpha.900');

  const dispatch = useDispatch<AppDispatch>();
  const { createRoomLoading, createdRoom } = useSelector(
    (state: RootState) => state.room
  );

  useEffect(() => {
    if (createdRoom?.id && !createRoomLoading && formik.values.title) {
      toast({
        title: 'Room created.',
        description: 'Your room has been created successfully.',
        status: 'success',
        duration: 5000,
        isClosable: true,
      });
      formik.resetForm({});
      setIsChecked(false);
    }
  }, [createdRoom, createRoomLoading]);

  const formik = useFormik({
    initialValues: {
      title: '',
      description: '',
      scheduledAt: '',
    },
    validationSchema: Yup.object({
      title: Yup.string().required('Title is required'),
      description: Yup.string().required('Description is required'),
      scheduledAt: Yup.date()
        .required('Scheduled time is required')
        .min(new Date(), 'Date must be in the future'),
    }),
    onSubmit: async (values) => {
      if (!isChecked) {
        toast({
          title: 'Agreement required',
          description:
            'Please read and check the room content agreement before creating the room.',
          status: 'warning',
          duration: 5000,
          isClosable: true,
        });
        return;
      }
      dispatch(
        createRoom({
          title: values.title,
          description: values.description,
          scheduledAt: new Date(values.scheduledAt),
        })
      );
    },
  });

  return (
    <Container>
      <Box
        bg={bg}
        color={textColor}
        p={8}
        borderRadius="lg"
        boxShadow="xl"
        width="100%"
        maxWidth={800}
        margin="0 auto"
        display="flex"
        flexDirection="column"
        alignItems="center"
      >
        <Stack spacing={4} align="center">
          <Heading fontSize="4xl">Create Room</Heading>
        </Stack>
        <Box mt={8} width="100%">
          <form onSubmit={formik.handleSubmit}>
            <FormControl
              isInvalid={!!formik.touched.title && !!formik.errors.title}
              mb={5}
            >
              <FormLabel>Title</FormLabel>
              <Input
                name="title"
                placeholder="Room Title"
                value={formik.values.title}
                onChange={formik.handleChange}
              />
              {formik.touched.title && formik.errors.title && (
                <Box color="red.500" mt={2}>
                  {formik.errors.title}
                </Box>
              )}
            </FormControl>

            <FormControl
              isInvalid={
                !!formik.touched.description && !!formik.errors.description
              }
              mb={5}
            >
              <FormLabel>Description</FormLabel>
              <Textarea
                name="description"
                placeholder="Room Description"
                value={formik.values.description}
                onChange={formik.handleChange}
              />
              {formik.touched.description && formik.errors.description && (
                <Box color="red.500" mt={2}>
                  {formik.errors.description}
                </Box>
              )}
            </FormControl>

            <FormControl
              isInvalid={
                !!formik.touched.scheduledAt && !!formik.errors.scheduledAt
              }
              mb={5}
            >
              <FormLabel>Scheduled Time</FormLabel>
              <Input
                type="datetime-local"
                name="scheduledAt"
                value={formik.values.scheduledAt}
                onChange={formik.handleChange}
              />
              {formik.touched.scheduledAt && formik.errors.scheduledAt && (
                <Box color="red.500" mt={2}>
                  {formik.errors.scheduledAt}
                </Box>
              )}
            </FormControl>

            <FormControl display="flex" alignItems="center" mb={5}>
              <Checkbox
                isChecked={isChecked}
                onChange={(e) => setIsChecked(e.target.checked)}
                mr={2}
              />
              <FormLabel mb="0">
                I have read and agree to the room content
              </FormLabel>
              <Link
                color="pink.400"
                ml={2}
                onClick={() => setIsModalOpen(true)}
              >
                View Room Content
              </Link>
            </FormControl>

            <Button
              type="submit"
              colorScheme="pink"
              isLoading={createRoomLoading}
              loadingText="Creating..."
              width="full"
              mt={5}
            >
              Create Room
            </Button>
          </form>
        </Box>
        <ContentModal
          isModalOpen={isModalOpen}
          setIsModalOpen={setIsModalOpen}
        />
      </Box>
    </Container>
  );
}

export default ScheduleRoom;
