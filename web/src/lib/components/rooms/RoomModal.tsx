"use client";

import { useEffect, useState } from "react";
import {
  Modal,
  ModalOverlay,
  ModalContent,
  ModalFooter,
  ModalBody,
  ModalCloseButton,
  Button,
  useToast,
  useColorModeValue,
  FormControl,
  FormLabel,
  Checkbox,
  SimpleGrid,
  CheckboxGroup,
  FormErrorMessage,
  Link,
  Box,
  Stack,
  Heading,
  Input,
  Textarea,
} from "@chakra-ui/react";
import { useSelector } from "react-redux";
import { RootState } from "~/lib/state/store";
import { RoomDto } from "shared/src/types/openApiGen";
import { useFormik } from "formik";
import * as Yup from "yup";
import ContentModal from "./ContentModal";

interface RoomModalProp {
  isOpen: boolean;
  room?: RoomDto;
  isAgreementChecked: boolean;
  isLoading: boolean;
  onClose: () => void;
  handleSubmit: (values: any, room?: RoomDto) => void;
  setIsAgreementChecked: (arg: boolean) => void;
}

const formatDateTimeLocal = (date: Date) => {
  return date.toISOString().slice(0, 16); // "YYYY-MM-DDTHH:MM"
};

function RoomModal({
  isOpen,
  room,
  isAgreementChecked,
  isLoading,
  setIsAgreementChecked,
  onClose,
  handleSubmit,
}: RoomModalProp) {
  const { categories } = useSelector((state: RootState) => state.question);
  const toast = useToast();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const bg = useColorModeValue("whiteAlpha.900", "gray.700");
  const textColor = useColorModeValue("gray.800", "whiteAlpha.900");

  const title = room ? "Edit Room" : "Create Room";

  const initialValues = room
    ? {
        title: room.title || "",
        description: room.description || "",
        scheduledAt: room.scheduledAt
          ? formatDateTimeLocal(new Date(room.scheduledAt))
          : "",

        selectedQuestionCategories:
          room.questionsCategories?.map((qcat) => qcat.toString()) || [],
      }
    : {
        title: "",
        description: "",
        scheduledAt: "",
        selectedQuestionCategories: [],
      };

  const formik = useFormik({
    initialValues,
    enableReinitialize: true,
    validationSchema: Yup.object({
      title: Yup.string().required("Title is required"),
      description: Yup.string().required("Description is required"),
      scheduledAt: Yup.date()
        .required("Scheduled time is required")
        .min(new Date(), "Date must be in the future"),
      selectedQuestionCategories: Yup.array().min(
        1,
        "Select at least one question category"
      ),
    }),
    onSubmit: (values) => {
      if (!isAgreementChecked && !room) {
        toast({
          title: "Agreement required",
          description:
            "Please read and check the room content agreement before creating the room.",
          status: "warning",
          duration: 5000,
          isClosable: true,
        });
        return;
      }
      handleSubmit(values, room);
    },
  });

  useEffect(() => {
    if (categories?.length) {
      formik.setFieldValue(
        "selectedQuestionCategories",
        categories?.map((cat) => cat.id!.toString())
      );
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [categories]);

  return (
    <Modal isOpen={isOpen} onClose={onClose} size="2xl">
      <ModalOverlay />
      <ModalContent>
        <ModalCloseButton />
        <ModalBody>
          <Box
            bg={bg}
            color={textColor}
            p={8}
            borderRadius="lg"
            width="100%"
            maxWidth={800}
            margin="0 auto"
            display="flex"
            flexDirection="column"
            alignItems="center"
          >
            <Stack spacing={4} align="center">
              <Heading fontSize="4xl">{title}</Heading>
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
                      {formik.errors.title as any}
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
                      {formik.errors.description as any}
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
                    value={formik.values.scheduledAt as any}
                    onChange={formik.handleChange}
                  />
                  {formik.touched.scheduledAt && formik.errors.scheduledAt && (
                    <Box color="red.500" mt={2}>
                      {formik.errors.scheduledAt as any}
                    </Box>
                  )}
                </FormControl>

                <FormControl
                  isInvalid={
                    !!formik.errors.selectedQuestionCategories &&
                    !!formik.touched.selectedQuestionCategories
                  }
                  mb={10}
                >
                  <FormLabel htmlFor="selectedQuestionCategories">
                    Choose Question Types
                  </FormLabel>
                  <CheckboxGroup
                    colorScheme="pink"
                    onChange={(values) => {
                      formik.setFieldValue(
                        "selectedQuestionCategories",
                        values
                      );
                    }}
                    value={formik.values.selectedQuestionCategories}
                  >
                    <SimpleGrid columns={[1, 2]} spacing={4}>
                      {categories?.map((categ) => (
                        <Checkbox key={categ.id!} value={categ.id!.toString()}>
                          {categ.name}
                        </Checkbox>
                      ))}
                    </SimpleGrid>
                  </CheckboxGroup>
                  <FormErrorMessage>
                    {formik.errors.selectedQuestionCategories as any}
                  </FormErrorMessage>
                </FormControl>

                <FormControl display="flex" alignItems="center" mb={5}>
                  <Checkbox
                    isChecked={isAgreementChecked || room !== undefined}
                    onChange={(e) => setIsAgreementChecked(e.target.checked)}
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
              </form>
            </Box>
            <ContentModal
              isModalOpen={isModalOpen}
              setIsModalOpen={setIsModalOpen}
            />
          </Box>
        </ModalBody>
        <ModalFooter>
          <Button colorScheme="blue" mr={3} onClick={onClose}>
            Close
          </Button>
          <Button
            colorScheme="pink"
            onClick={() => {
              document
                .querySelector("form")
                ?.dispatchEvent(
                  new Event("submit", { cancelable: true, bubbles: true })
                );
            }}
            isLoading={isLoading}
            loadingText="Submitting..."
          >
            Save Changes
          </Button>
        </ModalFooter>
      </ModalContent>
    </Modal>
  );
}

export default RoomModal;
