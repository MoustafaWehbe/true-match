'use client';

import {
  Box,
  Text,
  Button,
  useColorModeValue,
  Stack,
  Flex,
} from '@chakra-ui/react';
import { InfoIcon } from '@chakra-ui/icons';
import { sharedCardContainerStyles } from './SwipeCard';

interface CardStaticProps {
  user: any;
  index: number;
  handleIsExpanded: () => void;
}

const CardStatic = ({ user, handleIsExpanded }: CardStaticProps) => {
  const cardBg = useColorModeValue('white', 'gray.700');
  const cardTextColor = useColorModeValue('gray.800', 'whiteAlpha.900');

  return (
    <Box sx={sharedCardContainerStyles}>
      <Box
        bg={cardBg}
        color={cardTextColor}
        boxShadow="md"
        transition="height 0.3s ease-in-out"
        display="flex"
        flexDirection="column"
        overflowY={'scroll'}
        height="100%"
        borderRadius="20px"
        border="1px solid transparent"
      >
        <Box
          h="80%"
          bgImage={'url(/images/default-user-image-female.jpg)'}
          bgSize="cover"
          bgPosition="center"
          borderTopRadius="20px"
          borderTop="1px solid transparent"
        />

        <Box p={4} h={'30%'} transition="height 0.3s ease-in-out">
          <Flex justify="space-between" align="center" mb={2}>
            <Text fontWeight="bold" fontSize="xl">
              {user.name}
            </Text>
            <Button
              size="sm"
              colorScheme="teal"
              onClick={handleIsExpanded}
              aria-label="More info"
              variant="outline"
            >
              <InfoIcon />
            </Button>
          </Flex>
          <Stack spacing={2} paddingBottom={5}>
            <Text>{'user.description'}</Text>
            <Text>Height: {'user.height'}</Text>
            <Text>Relationship Goals: {'user.relationshipGoals'}</Text>
            <Text>Relationship Goals: {'user.relationshipGoals'}</Text>
            <Text>Relationship Goals: {'user.relationshipGoals'}</Text>
            <Text>Relationship Goals: {'user.relationshipGoals'}</Text>
            <Text>Relationship Goals: {'user.relationshipGoals'}</Text>
            <Text>Relationship Goals: {'user.relationshipGoals'}</Text>
            <Text>Relationship Goals: {'user.relationshipGoals'}</Text>
            <Text>Relationship Goals: {'user.relationshipGoals'}</Text>
          </Stack>
        </Box>
      </Box>
    </Box>
  );
};

export default CardStatic;
