import { AbsoluteCenter, Box, Button, Stack } from '@chakra-ui/react';
import { ChangeEvent, useCallback, useState } from 'react';
import { usePostCustomersLogin } from '../../services/flower-shop';
import useAuth from '../../hooks/useAuth';
import CredentialForm from './credentialForm';
import { useNavigate } from 'react-router-dom';

const CustomerSignInPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isValid, setIsValid] = useState(false);
  const { auth, setAuth, persist, setPersist } = useAuth();
  const navigate = useNavigate();

  const {
    mutateAsync: loginMutateAsync,
    data: loginData,
    isLoading: loginIsLoading,
    isError: loginIsError,
    error: loginError,
  } = usePostCustomersLogin();

  const handleSignInAttempt = useCallback(async () => {
    if (!loginIsLoading) {
      try {
        await loginMutateAsync({
          data: { email: email, password: password },
        }).then((response) => {
          const responseToken: string = response.data.token;
          const responseEmail: string = response.data.email;

          console.log(response);

          console.log(responseToken);

          setAuth({ token: responseToken, email: responseEmail });

          navigate('/');
        });
      } catch (err) {
        console.error(err);
      }
    }
  }, [email, loginIsLoading, loginMutateAsync, navigate, password, setAuth]);

  const handleEmailChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      setEmail(event.target.value);
    },
    []
  );

  const handlePasswordChange = useCallback(
    (event: ChangeEvent<HTMLInputElement>) => {
      setPassword(event.target.value);
    },
    []
  );

  return (
    <Box width={'400px'} height={'600px'}>
      <AbsoluteCenter>
        <Stack>
          <CredentialForm
            emailValue={email}
            handleEmailChange={handleEmailChange}
            passwordValue={password}
            handlePasswordChange={handlePasswordChange}
            setValid={setIsValid}
          />
          <Button
            isLoading={loginIsLoading}
            isDisabled={!isValid}
            onClick={handleSignInAttempt}
          >
            Sign in
          </Button>
        </Stack>
      </AbsoluteCenter>
    </Box>
  );
};

export default CustomerSignInPage;
