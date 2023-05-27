import { AbsoluteCenter, Box, Stack, Button } from '@chakra-ui/react';
import { ChangeEvent, useCallback, useEffect, useState } from 'react';
import { usePostCustomersRegister } from '../../services/flower-shop';
import CredentialForm from './credentialForm';

const CustomerSignUpPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isValid, setIsValid] = useState(false);

  const {
    mutate: loginMutate,
    isLoading: loginIsLoading,
    isError: loginIsError,
    error: loginError,
  } = usePostCustomersRegister();

  const handleSignUpAttempt = useCallback(() => {
    if (!loginIsLoading) {
      loginMutate({ data: { email: email, password: password } });
    }
  }, [email, loginIsLoading, loginMutate, password]);

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

  useEffect(() => {
    console.log(loginError);
  }, [loginError]);

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
            onClick={handleSignUpAttempt}
          >
            Sign up
          </Button>
        </Stack>
      </AbsoluteCenter>
    </Box>
  );
};

export default CustomerSignUpPage;
