import { Table, TableContainer, Tbody, Td, Thead, Tr } from '@chakra-ui/react';
import { flowerType } from '../../../../types/flowerType';
import { useMemo } from 'react';

type SelectFlowerTableProps = {
  flowers: Array<flowerType>;
  selected: number;
  setSelected: (index: number) => void;
};

const SelectFlowerTable = ({
  flowers,
  selected,
  setSelected,
}: SelectFlowerTableProps) => {
  const flowerRows = useMemo(
    () =>
      flowers.map((flower, idx) => (
        <Tr
          bgColor={idx === selected ? '#849fe3' : 'null'}
          onClick={() => setSelected(idx)}
        >
          <Td>{flower.name}</Td>
          <Td>{flower.id}</Td>
        </Tr>
      )),
    [flowers, selected, setSelected]
  );

  return (
    <TableContainer>
      <Table>
        <Thead>
          <Tr>
            <Td>Name</Td>
            <Td>Id</Td>
          </Tr>
        </Thead>
        <Tbody>{flowerRows}</Tbody>
      </Table>
    </TableContainer>
  );
};

export default SelectFlowerTable;
