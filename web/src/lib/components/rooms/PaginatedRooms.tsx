import { useState } from "react";
import { ChevronLeftIcon, ChevronRightIcon } from "@chakra-ui/icons";
import { Button, Flex, IconButton } from "@chakra-ui/react";

import { openApiTypes } from "@truematch/shared";

interface Props {
  rooms: openApiTypes.RoomDtoPagedResponse | null;
  handlePageChange: (page: number) => void;
}

const PaginatedRooms = ({ rooms, handlePageChange }: Props) => {
  const [currentPage, setCurrentPage] = useState(rooms?.currentPage || 1);

  const totalPages = rooms?.totalPages || 0;

  const handleNext = () => {
    if (currentPage < totalPages) {
      const nextPage = currentPage + 1;
      setCurrentPage(nextPage);
      handlePageChange(nextPage);
    }
  };

  const handlePrevious = () => {
    if (currentPage > 1) {
      const prevPage = currentPage - 1;
      setCurrentPage(prevPage);
      handlePageChange(prevPage);
    }
  };

  const handlePageClick = (page: number) => {
    setCurrentPage(page);
    handlePageChange(page);
  };

  return (
    <Flex justify="center" align="center" mt={8}>
      <Flex>
        <IconButton
          icon={<ChevronLeftIcon />}
          onClick={handlePrevious}
          isDisabled={currentPage === 1}
          aria-label="Previous page"
        />
        <Flex mx={4} alignItems={"center"}>
          {Array.from({ length: totalPages }, (_, index) => index + 1).map(
            (page) => (
              <Button
                key={page}
                onClick={() => handlePageClick(page)}
                isDisabled={currentPage === page}
                variant={currentPage === page ? "solid" : "outline"}
                colorScheme="teal"
                size="sm"
                mx={1}
              >
                {page}
              </Button>
            )
          )}
        </Flex>
        <IconButton
          icon={<ChevronRightIcon />}
          onClick={handleNext}
          isDisabled={currentPage === totalPages}
          aria-label="Next page"
        />
      </Flex>
    </Flex>
  );
};

export default PaginatedRooms;
