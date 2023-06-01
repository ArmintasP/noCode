import {
  TableContainer,
  Table as ChakraTable,
  Thead,
  Tr,
  Th,
  Tbody,
  Td,
  Checkbox,
} from '@chakra-ui/react';
import { useEffect, useMemo, useState } from 'react';

export type TableProps = {
  columnHeaders: Array<string>;
  rows?: Array<Array<string>>;
  setSelection?: React.Dispatch<React.SetStateAction<number[]>>;
  setSelected?: React.Dispatch<React.SetStateAction<number | null>>;
};

const SelectableTable = ({
  columnHeaders,
  rows,
  setSelection,
  setSelected,
}: TableProps) => {
  const [allChecked, setAllChecked] = useState(false);
  const [checkedItems, setCheckedItems] = useState(
    Array<boolean>((rows ?? []).length).fill(false)
  );

  useEffect(() => {
    if (allChecked) {
      if (!checkedItems.every((checked) => checked)) {
        setAllChecked(false);
      }
    } else {
      if (checkedItems.every((checked) => checked)) {
        setAllChecked(true);
      }
    }
  }, [allChecked, checkedItems]);

  useEffect(() => {
    if (setSelection !== undefined) {
      const selected = checkedItems
        .map((item, idx) => (item === true ? idx : -1))
        .filter((idx) => idx !== -1);

      setSelection(selected);
    }
  }, [checkedItems, setSelection]);

  const headerColumns = useMemo(
    () => columnHeaders.map((columnName) => <Th>{columnName}</Th>),
    [columnHeaders]
  );

  const parentCheckbox = useMemo(() => {
    return (
      <Td>
        <Checkbox
          isChecked={allChecked}
          onChange={(e) => {
            setAllChecked(e.target.checked);
            setCheckedItems(Array((rows ?? []).length).fill(e.target.checked));
          }}
        />
      </Td>
    );
  }, [allChecked, rows]);

  const header = useMemo(
    () => (
      <Thead>
        <Tr>
          {parentCheckbox}
          {headerColumns}
        </Tr>
      </Thead>
    ),
    [headerColumns, parentCheckbox]
  );

  const body = useMemo(() => {
    const tableRows = (rows ?? []).map((row, idx) => {
      const checkbox = () => {
        return (
          <Td width={'0px'}>
            <Checkbox
              isChecked={checkedItems[idx]}
              onChange={(e) =>
                setCheckedItems([
                  ...checkedItems.slice(0, idx),
                  e.target.checked,
                  ...checkedItems.slice(idx + 1),
                ])
              }
            />
          </Td>
        );
      };

      return (
        <Tr
          onClick={(e) => {
            if (setSelected !== undefined) {
              setSelected(idx);
            }
          }}
        >
          {checkbox()}
          {row.map((cell) => (
            <Td>{cell}</Td>
          ))}
        </Tr>
      );
    });

    return <Tbody>{tableRows}</Tbody>;
  }, [checkedItems, rows]);

  return (
    <TableContainer>
      <ChakraTable variant={'striped'}>
        {header}
        {body}
      </ChakraTable>
    </TableContainer>
  );
};

export default SelectableTable;
