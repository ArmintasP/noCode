import { Link, useParams } from 'react-router-dom';
import { useGetFlowerArrangementsId } from '../../services/flower-shop';
import LoadingPage from '../Loading/LoadingPage';
import ErrorPage from '../Error/errorPage';
import {
  Box,
  SimpleGrid,
  Image,
  Center,
  Text,
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbLink,
  Table,
  Thead,
  Tr,
  Th,
} from '@chakra-ui/react';
import CustomerPageLayout from '../../layout/customerPageLayout';

const ArrangementDetailPage = () => {
  const { arrangementId } = useParams();
  const { data, isLoading, isError, error } = useGetFlowerArrangementsId(
    arrangementId ?? ''
  );

  // if (isError) {
  //   console.error(error);

  //   return <ErrorPage />;
  // }

  // if (isLoading || data === undefined) {
  //   return <LoadingPage />;
  // }

  return (
    <CustomerPageLayout>
      <Box height={'20px'} />
      <Center>
        <Box width={'90%'}>
          <SimpleGrid columns={2} spacing={'40px'}>
            <Box>
              <Breadcrumb>
                <BreadcrumbItem>
                  <BreadcrumbLink as={Link} to={'/'}>
                    Home
                  </BreadcrumbLink>
                </BreadcrumbItem>
              </Breadcrumb>
              <Center>
                <Image src="https://bit.ly/dan-abramov" />
              </Center>
            </Box>
            <Box>
              <Text>FLOWER NAME</Text>
              <Text align={'justify'}>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed
                aliquam, dolor convallis condimentum tempus, eros nibh iaculis
                mi, sed hendrerit tortor odio eget velit. Etiam quis quam in
                nisl mollis sollicitudin quis vel tellus. Nam.
              </Text>
              <Table>
                <Thead>
                  <Tr>
                    <Th>Flower name</Th>
                    <Th>Quantity</Th>
                  </Tr>
                </Thead>
              </Table>
            </Box>
          </SimpleGrid>
        </Box>
      </Center>
    </CustomerPageLayout>
  );
};

export default ArrangementDetailPage;
