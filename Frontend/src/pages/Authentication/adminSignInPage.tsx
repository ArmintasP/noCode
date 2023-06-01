import { AbsoluteCenter, Box, Button, Stack } from '@chakra-ui/react';
import { ChangeEvent, useCallback, useState } from 'react';
import { usePostAdministratorsLogin } from '../../services/flower-shop';
import CredentialForm from './credentialForm';
import { useNavigate } from 'react-router-dom';
import { useAdminAuth } from '../../hooks/useAdminAuth';

const AdminSignInPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isValid, setIsValid] = useState(false);
  const { login } = useAdminAuth();
  const navigate = useNavigate();

  const {
    mutateAsync: loginMutateAsync,
    data: loginData,
    isLoading: loginIsLoading,
    isError: loginIsError,
    error: loginError,
  } = usePostAdministratorsLogin();

  const handleSignInAttempt = useCallback(async () => {
    if (!loginIsLoading) {
      try {
        await loginMutateAsync({
          data: { email: email, password: password },
        }).then((response) => {
          const responseToken: string = response.data.token;
          const responseEmail: string = response.data.email;
          const responseId: string = response.data.id;

          login({
            id: responseId,
            email: responseEmail,
            authToken: responseToken,
          });
        });
      } catch (err) {
        console.error(err);
      }
    }
  }, [email, login, loginIsLoading, loginMutateAsync, password]);

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

export default AdminSignInPage;
