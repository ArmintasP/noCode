import { Box, Button, Center, Flex, Spacer, Text } from '@chakra-ui/react';
import { useCallback, useMemo } from 'react';
import useAuth from '../hooks/useAuth';
import { Link } from 'react-router-dom';

const TopBar = () => {
  const { auth } = useAuth();

  const handleHomeClick = useCallback(() => {
    console.log('Home clicked');
  }, []);

  const handleAboutClick = useCallback(() => {
    console.log('About us clicked');
  }, []);

  const isSignedIn = useMemo(() => auth?.token !== undefined, [auth?.token]);

  const rightButtons = useMemo(() => {
    if (isSignedIn) {
      return (
        <Box>
          <Button>Sign out</Button>
        </Box>
      );
    } else {
      return (
        <Box>
          <Link to={'/signin'}>
            <Button>Sign in</Button>
          </Link>
        </Box>
      );
    }
  }, [isSignedIn]);

  return (
    <Box bg={'#32a877'}>
      <Center>
        <Box width={'70%'}>
          <Flex>
            <Box>
              <Button variant={'ghost'} onClick={handleHomeClick}>
                Home
              </Button>
              <Button variant={'ghost'} onClick={handleAboutClick}>
                About us
              </Button>
            </Box>
            <Spacer />
            <Box>
              <Text>TITLE</Text>
            </Box>
            <Spacer />
            {rightButtons}
          </Flex>
        </Box>
      </Center>
    </Box>
  );
};

export default TopBar;
