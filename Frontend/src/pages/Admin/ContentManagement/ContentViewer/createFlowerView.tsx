import { useState } from 'react';
import { flowerType } from '../../../../types/flowerType';
import FlowerViewer from './flowerViewer';
import { Button } from '@chakra-ui/react';

type CreateFlowerViewProps = {
  createFlower: (flower: flowerType) => void;
};

const CreateFlowerView = ({ createFlower }: CreateFlowerViewProps) => {
  const [flower, setFlower] = useState<flowerType>({
    id: '',
    name: '',
    imageUrl: '',
    quantity: 0,
  });

  return (
    <>
      <FlowerViewer flower={flower} setFlower={setFlower} isReadonly={false} />
      <Button onClick={() => createFlower(flower)}>Create</Button>
    </>
  );
};

export default CreateFlowerView;
