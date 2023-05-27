import { PropsWithChildren } from 'react';
import TopBar from './topBar';
import { Box, Center } from '@chakra-ui/react';

const CustomerPageLayout = (props: PropsWithChildren) => {
  return (
    <>
      <TopBar />
      <Center>
        <Box width={'70%'} bgColor={'#aaaaaa'}>
          {props.children}
        </Box>
      </Center>
    </>
  );
};

export default CustomerPageLayout;
