import {
  FormControl,
  FormLabel,
  Input,
  NumberInput,
  NumberInputField,
  Table,
  TableContainer,
  Tbody,
  Td,
  Thead,
  Tr,
} from '@chakra-ui/react';
import { useEffect, useMemo, useState } from 'react';
import { flowerArrangementType } from '../../../../types/flowerArrangementType';

type ArrangementViewerProps = {
  arrangement: flowerArrangementType;
  setArrangement?: (arrangement: flowerArrangementType) => void;
  isReadonly: boolean;
};

const ArrangementViewer = ({
  arrangement,
  setArrangement,
  isReadonly,
}: ArrangementViewerProps) => {
  const [name, setName] = useState('');
  const [imageUrl, setImageUrl] = useState('');
  const [description, setDescription] = useState('');
  const [price, setPrice] = useState(0);

  useEffect(() => {
    setName(arrangement.name);
    setImageUrl(arrangement.imageUrl);
    setDescription(arrangement.description);
    setPrice(arrangement.price);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  useEffect(() => {
    if (setArrangement !== undefined) {
      setArrangement({
        id: arrangement.id,
        name: name,
        imageUrl: imageUrl,
        categoryName: arrangement.categoryName,
        description: description,
        price: price,
        flowers: [],
      });
    }
  }, [
    arrangement.categoryName,
    arrangement.id,
    description,
    imageUrl,
    name,
    price,
    setArrangement,
  ]);

  const flowerRows = useMemo(
    () =>
      arrangement.flowers.map((flower) => (
        <Tr>
          <Td>{flower.name}</Td>
          <Td>{flower.quantity}</Td>
        </Tr>
      )),
    [arrangement.flowers]
  );

  return (
    <FormControl>
      <FormLabel>Id</FormLabel>
      <Input isDisabled value={arrangement.id} />
      <FormLabel>Name</FormLabel>
      <Input
        isDisabled={isReadonly}
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <FormLabel>Description</FormLabel>
      <Input
        isDisabled={isReadonly}
        value={description}
        onChange={(e) => setDescription(e.target.value)}
      />
      <FormLabel>ImageUrl</FormLabel>
      <Input
        isDisabled={isReadonly}
        value={imageUrl}
        onChange={(e) => setImageUrl(e.target.value)}
      />
      <FormLabel>Category</FormLabel>
      <Input isDisabled={true} value={arrangement.categoryName} />
      <FormLabel>Price</FormLabel>
      <NumberInput
        min={0}
        isDisabled={isReadonly}
        value={price}
        onChange={(valueString) => setPrice(parseFloat(valueString))}
      >
        <NumberInputField />
      </NumberInput>
      <TableContainer>
        <Table>
          <Thead>
            <Tr>
              <Td>Flower</Td>
              <Td>Quantity</Td>
            </Tr>
          </Thead>
          <Tbody>{flowerRows}</Tbody>
        </Table>
      </TableContainer>
    </FormControl>
  );
};

export default ArrangementViewer;
