import CustomerPageLayout from '../../layout/customerPageLayout';
import {
  AbsoluteCenter,
  Card,
  CardHeader,
  SimpleGrid,
  Spinner,
  Text,
  Image,
  Center,
  Box,
  Flex,
  Spacer,
} from '@chakra-ui/react';
import { useGetFlowerArrangementsAvailable } from '../../services/flower-shop';
import { useMemo } from 'react';
import { Link } from 'react-router-dom';
import { flowerArrangementType } from '../../types/flowerArrangementType';

const HomePage = () => {
  const { data, isLoading } = useGetFlowerArrangementsAvailable();

  const arrangements: Array<flowerArrangementType> = useMemo(
    () => data?.data.flowerArrangements,
    [data?.data.flowerArrangements]
  );

  const panels = useMemo(
    () =>
      (arrangements ?? []).map((arrangement) => (
        <Link to={'/details/' + arrangement.id}>
          <Card>
            <Image src={arrangement.imageUrl} maxHeight={'250px'} />
            <CardHeader>
              <Flex>
                <Text>{arrangement.name}</Text>
                <Spacer />
                <Text align={'right'}>{`${arrangement.price} €`}</Text>
              </Flex>
            </CardHeader>
          </Card>
        </Link>
      )),
    [arrangements]
  );

  return (
    <CustomerPageLayout>
      {isLoading ? (
        <AbsoluteCenter>
          <Spinner />
        </AbsoluteCenter>
      ) : (
        <>
          <Box height={'10px'} />
          <Center>
            <SimpleGrid columns={3} spacing={'10px'} width={'90%'}>
              {panels}
            </SimpleGrid>
          </Center>
        </>
      )}
    </CustomerPageLayout>
  );
};

export default HomePage;
