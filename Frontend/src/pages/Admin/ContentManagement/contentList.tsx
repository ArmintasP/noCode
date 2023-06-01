import { Box } from '@chakra-ui/react';
import SelectableTable from '../../../components/selectableTable';
import ContentListToolbar from './contentListToolbar';
import { useCallback, useEffect, useMemo, useState } from 'react';

type ContentListProps = {
  tableHeaders: Array<string>;
  tableData: Array<Array<string>>;
  deleteSelected: (indexes: Array<number>) => void;
  setSelected?: (index: number | null) => void;
  selected: number | null;
  createCommand: () => void;
  disableButtons: boolean;
};

const ContentList = ({
  tableHeaders,
  tableData,
  deleteSelected,
  setSelected,
  selected,
  createCommand,
  disableButtons,
}: ContentListProps) => {
  const [selection, setSelection] = useState<Array<number>>([]);
  const [selectedState, setSelectedState] = useState<number | null>(null);

  // eslint-disable-next-line react-hooks/exhaustive-deps
  useEffect(() => setSelectedState(selected), []);

  useEffect(() => {
    if (setSelected !== undefined) {
      setSelected(selectedState);
    }
  }, [selectedState, setSelected]);

  const deleteDisabled = useMemo(
    () => selection.length === 0 || disableButtons,
    [disableButtons, selection.length]
  );

  const deleteCommand = useCallback(() => {
    if (!deleteDisabled) {
      deleteSelected(selection);
    }
  }, [deleteDisabled, deleteSelected, selection]);

  const createDisabled = useMemo(() => disableButtons, [disableButtons]);

  useEffect(() => console.log(selection), [selection]);

  return (
    <Box>
      <ContentListToolbar
        isDeleteDisabled={deleteDisabled}
        deleteCommand={deleteCommand}
        isCreateDisabled={createDisabled}
        createCommand={createCommand}
      />
      <SelectableTable
        columnHeaders={tableHeaders}
        rows={tableData}
        setSelected={setSelectedState}
        setSelection={setSelection}
      />
    </Box>
  );
};

export default ContentList;
