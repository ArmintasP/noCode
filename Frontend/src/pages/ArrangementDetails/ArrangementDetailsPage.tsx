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
  Td,
  Tbody,
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

  const flowers = useMemo(
    () =>
      arrangement?.flowers.map((flower) => (
        <Tr>
          <Td width={'90px'}>
            <Image
              src={flower.imageUrl}
              borderRadius={'full'}
              boxSize={'40px'}
            />
          </Td>
          <Td>
            <Text>{flower.name}</Text>
          </Td>
          <Td>
            <Text align={'right'}>{flower.quantity}</Text>
          </Td>
        </Tr>
      )),
    [arrangement?.flowers]
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
                <BreadcrumbItem>
                  <Text>{arrangement.name}</Text>
                </BreadcrumbItem>
              </Breadcrumb>
              <Box height={'20px'} />
              <Center>
                <Image src={arrangement.imageUrl} />
              </Center>
            </Box>
            <Box>
              <Text fontSize={'4xl'}>{arrangement.name}</Text>
              <Text align={'justify'} minHeight={'100px'}>
                {arrangement.description}
              </Text>
              <Table>
                <Thead>
                  <Tr>
                    <Th></Th>
                    <Th>Flower name</Th>
                    <Th>
                      <Text align={'right'}>Quantity</Text>
                    </Th>
                  </Tr>
                </Thead>
                <Tbody>{flowers}</Tbody>
              </Table>
            </Box>
          </SimpleGrid>
        </Box>
      </Center>
    </CustomerPageLayout>
  );
};

export default ArrangementDetailPage;
