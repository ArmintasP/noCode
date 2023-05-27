import { AbsoluteCenter, Box, Spinner } from '@chakra-ui/react';

const LoadingPage = () => {
  return (
    <Box height={'500px'}>
      <AbsoluteCenter>
        <Spinner />
      </AbsoluteCenter>
    </Box>
  );
};

export default LoadingPage;
