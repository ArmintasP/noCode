import { AbsoluteCenter, Box } from '@chakra-ui/react';
import CustomerSingUpWindow from './customerSignUpWindow';

const CustomerSignUnPage = () => {
  return (
    <Box width={'400px'} height={'600px'}>
      <AbsoluteCenter>
        <CustomerSingUpWindow />
      </AbsoluteCenter>
    </Box>
  );
};

export default CustomerSignUnPage;
