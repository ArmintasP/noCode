import { useCallback, useMemo, useState } from 'react';
import {
  Box,
  Button,
  Flex,
  FormControl,
  FormLabel,
  NumberInput,
  NumberInputField,
  Stack,
} from '@chakra-ui/react';
import { flowerArrangementType } from '../../../../types/flowerArrangementType';
import ArrangementViewer from './arrangementViewer';
import { flowerType } from '../../../../types/flowerType';
import SelectFlowerTable from './selectFlowerTable';

type CreateArrangementViewProps = {
  createArrangement: (flower: flowerArrangementType) => void;
  flowers: Array<flowerType>;
};

const CreateArrangementView = ({
  createArrangement,
  flowers,
}: CreateArrangementViewProps) => {
  const [arrangement, setArrangement] = useState<flowerArrangementType>({
    id: '',
    name: '',
    description: '',
    imageUrl: '',
    price: 0,
    categoryName: '',
    flowers: [],
  });
  const [selected, setSelected] = useState(-1);
  const [flowerQuantity, setFlowerQuantity] = useState(1);

  const isAddFlowerButtonDisabled = useMemo(
    () => selected === -1 && flowerQuantity > 0,
    [flowerQuantity, selected]
  );

  const addFlower = useCallback(() => {
    const selectedFlower = flowers[selected];

    setArrangement({
      ...arrangement,
      flowers: [
        ...arrangement.flowers,
        { ...selectedFlower, quantity: flowerQuantity },
      ],
    });
  }, [flowers, selected, arrangement, flowerQuantity]);

  return (
    <Stack>
      <Flex>
        <Box width={'400px'}>
          <ArrangementViewer
            arrangement={arrangement}
            setArrangement={setArrangement}
            isReadonly={false}
          />
        </Box>
        <Box width={'20px'} />
        <Box>
          <Stack>
            <SelectFlowerTable
              flowers={flowers}
              selected={selected}
              setSelected={setSelected}
            />
            <FormControl>
              <FormLabel>Quantity</FormLabel>
              <NumberInput
                min={1}
                value={flowerQuantity}
                onChange={(valueString) =>
                  setFlowerQuantity(parseInt(valueString))
                }
              >
                <NumberInputField />
              </NumberInput>
            </FormControl>
            <Box height={'50px'} />
            <Button isDisabled={isAddFlowerButtonDisabled} onClick={addFlower}>
              Add flower
            </Button>
          </Stack>
        </Box>
      </Flex>
      <Box height={'40px'} />
      <Box>
        <Button onClick={() => createArrangement(arrangement)}>Create</Button>
      </Box>
    </Stack>
  );
};

export default CreateArrangementView;
