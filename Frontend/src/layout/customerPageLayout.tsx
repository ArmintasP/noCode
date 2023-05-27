import { PropsWithChildren } from 'react';
import TopBar from './topBar';
import { Box, Center } from '@chakra-ui/react';

const CustomerPageLayout = (props: PropsWithChildren) => {
  return (
    <>
      <TopBar />
      <Center>
        <Box
          width={'70%'}
          bgColor={'#e8e8e8'}
          height={'infinite'}
          minHeight={'100vh'}
        >
          {props.children}
        </Box>
      </Center>
    </>
  );
};

export default CustomerPageLayout;
