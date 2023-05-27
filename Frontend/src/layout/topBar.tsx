import {
  Box,
  Button,
  Center,
  Flex,
  Spacer,
  Text,
  Image,
  Stack,
} from '@chakra-ui/react';
import { useCallback, useMemo } from 'react';
import { useAuth } from '../hooks/useAuth';
import { Link, useNavigate } from 'react-router-dom';
import LotusIcon from '../assets/Lotus-Flower.svg';

const TopBar = () => {
  const { user, logout } = useAuth();
  const navigate = useNavigate();

  const handleHomeClick = useCallback(() => {
    navigate('/');
  }, [navigate]);

  const handleAboutClick = useCallback(() => {
    console.log('About us clicked');
  }, []);

  const isSignedIn = useMemo(
    () => user?.authToken !== undefined,
    [user?.authToken]
  );

  const rightButtons = useMemo(() => {
    if (isSignedIn) {
      return (
        <Box onClick={logout}>
          <Button variant={'ghost'}>Sign out</Button>
        </Box>
      );
    } else {
      return (
        <Box>
          <Link to={'/signin'}>
            <Button variant={'ghost'}>Sign in</Button>
          </Link>
        </Box>
      );
    }
  }, [isSignedIn, logout]);

  return (
    <Box bg={'#32a877'}>
      <Center>
        <Box width={'70%'}>
          <Box>
            <Center>
              <Stack>
                <Image src={LotusIcon} height={'50px'} />
                <Center>
                  <Text fontSize={'2xl'}>White lotus</Text>
                </Center>
              </Stack>
            </Center>
          </Box>
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
            {rightButtons}
          </Flex>
        </Box>
      </Center>
    </Box>
  );
};

export default TopBar;
