import { AbsoluteCenter, Box, Stack, Button } from '@chakra-ui/react';
import { ChangeEvent, useCallback, useEffect, useState } from 'react';
import { usePostCustomersRegister } from '../../services/flower-shop';
import CredentialForm from './credentialForm';
import { useNavigate } from 'react-router-dom';

const CustomerSignUpPage = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isValid, setIsValid] = useState(false);
  const navigate = useNavigate();

  const {
    mutateAsync: registerMutateAsync,
    isLoading: registerIsLoading,
    isError: registerIsError,
    error: registerError,
  } = usePostCustomersRegister();

  const handleSignUpAttempt = useCallback(() => {
    if (!registerIsLoading) {
      registerMutateAsync({ data: { email: email, password: password } }).then(
        (response) => {
          navigate('/signin');
        }
      );
    }
  }, [registerIsLoading, registerMutateAsync, email, password, navigate]);

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
    console.log(registerError);
  }, [registerError]);

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
            isLoading={registerIsLoading}
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
