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
import { useMemo } from 'react';
import { flowerArrangementType } from '../../types/flowerArrangementType';

const ArrangementDetailPage = () => {
  const { arrangementId } = useParams();
  const { data, isLoading, isError, error } = useGetFlowerArrangementsId(
    arrangementId ?? ''
  );

  const arrangement: flowerArrangementType = useMemo(
    () => data?.data.flowerArrangement,
    [data?.data]
  );

  if (isError) {
    console.error(error);

    return <ErrorPage />;
  }

  if (isLoading || data === undefined) {
    return <LoadingPage />;
  }

  console.log(arrangement);

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
                <Image src={arrangement.imageUrl} />
              </Center>
            </Box>
            <Box>
              <Text>{arrangement.name}</Text>
              <Text align={'justify'} minHeight={'100px'}>
                {arrangement.description}
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
