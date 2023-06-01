import { FormControl, FormLabel, Input } from '@chakra-ui/react';
import { flowerType } from '../../../../types/flowerType';
import { useEffect, useState } from 'react';

type FlowerViewerProps = {
  flower: flowerType;
  setFlower?: (flower: flowerType) => void;
  isReadonly: boolean;
};

const FlowerViewer = ({ flower, setFlower, isReadonly }: FlowerViewerProps) => {
  const [name, setName] = useState('');
  const [imageUrl, setImageUrl] = useState('');

  useEffect(() => {
    setName(flower.name);
    setImageUrl(flower.imageUrl);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  useEffect(() => {
    if (setFlower !== undefined) {
      setFlower({
        id: flower.id,
        name: name,
        imageUrl: imageUrl,
        quantity: flower.quantity,
      });
    }
  }, [flower.id, flower.quantity, imageUrl, name, setFlower]);

  return (
    <FormControl>
      <FormLabel>Id</FormLabel>
      <Input isDisabled value={flower.id} />
      <FormLabel>Name</FormLabel>
      <Input
        isDisabled={isReadonly}
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <FormLabel>ImageUrl</FormLabel>
      <Input
        isDisabled={isReadonly}
        value={imageUrl}
        onChange={(e) => setImageUrl(e.target.value)}
      />
    </FormControl>
  );
};

export default FlowerViewer;
