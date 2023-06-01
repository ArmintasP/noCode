import { Box, Button, Center, Flex, Text } from '@chakra-ui/react';
import { User } from '../../../hooks/useUser';
import {
  useDeleteFlowerArrangementsId,
  useDeleteFlowersId,
  useGetFlowerArrangementsAvailable,
  useGetFlowers,
  usePostFlowerArrangements,
  usePostFlowers,
} from '../../../services/flower-shop';
import LoadingPage from '../../Loading/LoadingPage';
import { useCallback, useEffect, useMemo, useState } from 'react';
import ContentList from './contentList';
import { flowerType } from '../../../types/flowerType';
import { flowerArrangementType } from '../../../types/flowerArrangementType';
import FlowerViewer from './ContentViewer/flowerViewer';
import ArrangementViewer from './ContentViewer/arrangementViewer';
import axios, { AxiosRequestConfig } from 'axios';
import CreateFlowerView from './ContentViewer/createFlowerView';
import CreateArrangementView from './ContentViewer/createArrangementView';

type ContentManagementPageProps = {
  adminUser: User;
  logout: () => void;
};

const ContentManagementPage = ({
  adminUser,
  logout,
}: ContentManagementPageProps) => {
  const requestConfig: AxiosRequestConfig = useMemo(() => {
    const config = axios.defaults;

    return {
      ...config,
      headers: {
        Authorization: `Bearer ${adminUser.authToken ?? ''}`,
      },
    };
  }, [adminUser.authToken]);

  const [isFlowerSelected, setIsFlowerSelected] = useState(false);
  const [selected, setSelected] = useState<number | null>(null);

  const { data: flowerData, isLoading: isFlowersLoading } = useGetFlowers();
  const { data: arrangementData, isLoading: isArrangementsLoading } =
    useGetFlowerArrangementsAvailable();

  const { mutateAsync: deleteFlowerAsync, isLoading: isDeletingFlower } =
    useDeleteFlowersId({ axios: requestConfig });
  const {
    mutateAsync: deleteArrangementAsync,
    isLoading: isDeletingArrangement,
  } = useDeleteFlowerArrangementsId({ axios: requestConfig });

  const { mutateAsync: createFlowerAsync, isLoading: isCreatingFlower } =
    usePostFlowers({ axios: requestConfig });
  const {
    mutateAsync: createArrangementAsync,
    isLoading: isCreatingArrangement,
  } = usePostFlowerArrangements({ axios: requestConfig });

  const areButtonsDisabled = useMemo(
    () =>
      isDeletingFlower ||
      isDeletingArrangement ||
      isCreatingFlower ||
      isCreatingArrangement,
    [
      isCreatingArrangement,
      isCreatingFlower,
      isDeletingArrangement,
      isDeletingFlower,
    ]
  );

  const flowers: Array<flowerType> = useMemo(
    // eslint-disable-next-line @typescript-eslint/ban-ts-comment
    // @ts-ignore
    () => flowerData?.data.flowers ?? [],
    [flowerData?.data]
  );

  const flowerTableData = useMemo(
    () => flowers.map((flower) => [flower.name]),
    [flowers]
  );

  const arrangements: Array<flowerArrangementType> = useMemo(
    // eslint-disable-next-line @typescript-eslint/ban-ts-comment
    // @ts-ignore
    () => arrangementData?.data.flowerArrangements ?? [],
    [arrangementData?.data]
  );

  const arrangementTableData = useMemo(
    () => arrangements.map((arr) => [arr.name]),
    [arrangements]
  );

  useEffect(() => console.log(axios.defaults.headers), []);

  const deleteFlowers = useCallback(
    (indexes: Array<number>) => {
      const ids = indexes.map((idx) => flowers[idx].id);

      ids.forEach(async (id) => await deleteFlowerAsync({ id: id }));

      window.location.reload();
    },
    [deleteFlowerAsync, flowers]
  );

  const deleteArrangements = useCallback(
    (indexes: Array<number>) => {
      const ids = indexes.map((idx) => arrangements[idx].id);

      ids.forEach(async (id) => await deleteArrangementAsync({ id: id }));

      window.location.reload();
    },
    [arrangements, deleteArrangementAsync]
  );

  const createFlower = useCallback(
    async (flower: flowerType) => {
      await createFlowerAsync({
        data: { name: flower.name, imageUrl: flower.imageUrl },
      });

      window.location.reload();
    },
    [createFlowerAsync]
  );

  const createArrangement = useCallback(
    async (arrangement: flowerArrangementType) => {
      await createArrangementAsync({
        data: {
          name: arrangement.name,
          imageUrl: arrangement.imageUrl,
          description: arrangement.description,
          price: arrangement.price,
          flowers: arrangement.flowers.map((flower) => ({
            id: flower.id,
            quantity: flower.quantity,
          })),
          storageQuantity: 1,
        },
      });

      window.location.reload();
    },
    [createArrangementAsync]
  );

  const setSelectedFlower = useCallback((index: number | null) => {
    setIsFlowerSelected(true);
    setSelected(index);
  }, []);

  const setSelectedArrangement = useCallback((index: number | null) => {
    setIsFlowerSelected(false);
    setSelected(index);
  }, []);

  const createFlowerButtonCommand = useCallback(() => {
    setSelectedFlower(-1);
  }, [setSelectedFlower]);

  const createArrangementButtonCommand = useCallback(() => {
    setSelectedArrangement(-1);
  }, [setSelectedArrangement]);

  const viewer = useMemo(() => {
    console.log(`Selected: ${selected}`);

    if (selected === null) {
      return null;
    }

    if (isFlowerSelected) {
      if (selected === -1)
        return <CreateFlowerView createFlower={createFlower} />;

      return <FlowerViewer flower={flowers[selected]} isReadonly={true} />;
    } else {
      if (selected === -1)
        return (
          <CreateArrangementView
            createArrangement={createArrangement}
            flowers={flowers}
          />
        );

      return (
        <ArrangementViewer
          arrangement={arrangements[selected]}
          isReadonly={true}
        />
      );
    }
  }, [
    arrangements,
    createArrangement,
    createFlower,
    flowers,
    isFlowerSelected,
    selected,
  ]);

  if (isFlowersLoading || isArrangementsLoading) {
    return <LoadingPage />;
  }

  return (
    <Box>
      <Box height={'100px'}>
        <Text height={'30px'}>{`Signed in as ${adminUser.email}`}</Text>
        <Button onClick={logout}>Sign out</Button>
      </Box>
      <Flex>
        <Box width={'350px'}>
          <ContentList
            tableHeaders={['Name']}
            tableData={flowerTableData}
            deleteSelected={deleteFlowers}
            setSelected={setSelectedFlower}
            selected={selected}
            createCommand={createFlowerButtonCommand}
            disableButtons={areButtonsDisabled}
          />
        </Box>
        <Box width={'20px'} />
        <Box width={'350px'}>
          <ContentList
            tableHeaders={['Name']}
            tableData={arrangementTableData}
            deleteSelected={deleteArrangements}
            setSelected={setSelectedArrangement}
            selected={selected}
            createCommand={createArrangementButtonCommand}
            disableButtons={areButtonsDisabled}
          />
        </Box>
        <Box width={'20px'} />
        <Box minWidth={'500px'}>
          <Center>{viewer}</Center>
        </Box>
      </Flex>
    </Box>
  );
};

export default ContentManagementPage;
