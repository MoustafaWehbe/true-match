import React, { memo, useEffect, useState } from "react";
import {
  Box,
  Button,
  Input,
  Image,
  Grid,
  Heading,
  IconButton,
  Spinner,
} from "@chakra-ui/react";
import { CloseIcon } from "@chakra-ui/icons";
import { RootState } from "~/lib/state/store";
import { useSelector } from "react-redux";
import { Media } from "shared/src/types/openApiGen";
import { urlToFile } from "~/lib/utils/file/file";
import env from "~/lib/consts/env";

interface ImageSelectorProps {
  media?: Array<Media> | null;
}

const ImageSelector = ({ media }: ImageSelectorProps) => {
  const [images, setImages] = useState<(File | null)[]>(Array(6).fill(null));
  const loadingImages = useSelector(
    (state: RootState) => state.user.loadingImages
  );

  useEffect(() => {
    const fetchImages = async () => {
      const mediaImages: File[] = [];
      await new Promise<void>((res, reject) =>
        media!.forEach((item, index) => {
          urlToFile(env.apiUrl + item.url, "profile " + index, "image/jpeg")
            .then((file) => {
              mediaImages.push(file);
              if (index === media?.length! - 1) {
                res();
              }
            })
            .catch((error) => {
              console.error("Error creating File:", error);
              reject(error);
            });
        })
      );
      setImages(mediaImages);
    };
    if (media && media.length) {
      fetchImages();
    }
  }, [media]);

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (!e.target.files) return;
    const uploadedImages = Array.from(e.target.files);

    setImages((prevImages) => {
      const newImages = [...prevImages];
      let imageIndex = 0;

      // Fill the empty slots with the new images
      for (
        let i = 0;
        i < newImages.length && imageIndex < uploadedImages.length;
        i++
      ) {
        if (!newImages[i]) {
          newImages[i] = uploadedImages[imageIndex];
          imageIndex++;
        }
      }
      return newImages;
    });
  };

  const handleRemoveImage = (index: number) => {
    setImages((prevImages) => {
      const newImages = [...prevImages];
      newImages[index] = null;
      return newImages;
    });
  };

  return (
    <Box>
      <Input
        type="file"
        multiple
        accept="image/*"
        onChange={handleFileChange}
        mb={4}
        display="none"
        id="upload-images"
      />
      <Grid
        templateColumns={{
          base: "repeat(1, 1fr)",
          sm: "repeat(2, 1fr)",
          md: "repeat(3, 1fr)",
        }}
        gap={4}
      >
        {images.map((image, index) => (
          <Box
            key={index}
            position="relative"
            height={{ base: "120px", md: "150px" }}
            border="1px solid #ddd"
            borderRadius="md"
            overflow="hidden"
          >
            {image ? (
              <>
                <Image
                  src={URL.createObjectURL(image)}
                  alt={`Uploaded ${index}`}
                  boxSize="100%"
                  objectFit="cover"
                />
                <IconButton
                  icon={<CloseIcon />}
                  size="xs"
                  colorScheme="red"
                  position="absolute"
                  top="5px"
                  aria-label=""
                  right="5px"
                  onClick={() => handleRemoveImage(index)}
                />
                {loadingImages.includes(image.name) && (
                  <Box
                    position="absolute"
                    top="0"
                    left="0"
                    right="0"
                    bottom="0"
                    background="rgba(0, 0, 0, 0.5)"
                    display="flex"
                    alignItems="center"
                    justifyContent="center"
                  >
                    <Spinner color="white" />
                  </Box>
                )}
              </>
            ) : (
              <Box
                display="flex"
                alignItems="center"
                justifyContent="center"
                height="100%"
                bg="gray.100"
              >
                <Heading size="sm" color="gray.500">
                  Image {index + 1}
                </Heading>
              </Box>
            )}
          </Box>
        ))}
      </Grid>
      <label htmlFor="upload-images">
        <Button as="span" colorScheme="pink" mt={4}>
          Choose Images
        </Button>
      </label>
    </Box>
  );
};

export default memo(ImageSelector);
