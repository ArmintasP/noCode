import { AddIcon, DeleteIcon } from '@chakra-ui/icons';
import { Box, Button } from '@chakra-ui/react';

type ContentListToolbarProps = {
  isDeleteDisabled: boolean;
  isCreateDisabled: boolean;
  deleteCommand: () => void;
  createCommand: () => void;
};

const ContentListToolbar = ({
  isCreateDisabled,
  isDeleteDisabled,
  deleteCommand,
  createCommand,
}: ContentListToolbarProps) => {
  return (
    <Box>
      <Button
        isDisabled={isDeleteDisabled}
        onClick={deleteCommand}
        leftIcon={<DeleteIcon />}
      >
        Delete
      </Button>
      <Button
        isDisabled={isCreateDisabled}
        onClick={createCommand}
        leftIcon={<AddIcon />}
      >
        Create
      </Button>
    </Box>
  );
};

export default ContentListToolbar;
