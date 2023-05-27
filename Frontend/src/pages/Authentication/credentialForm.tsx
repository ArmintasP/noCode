import {
  Stack,
  Text,
  Input,
  InputGroup,
  InputRightElement,
  Button,
} from '@chakra-ui/react';
import { Dispatch, SetStateAction, useState } from 'react';
import { ChangeEventHandler, useEffect } from 'react';

const PasswordInput = ({
  value,
  handleChange,
}: {
  value: string;
  handleChange: ChangeEventHandler;
}) => {
  const [show, setShow] = useState(false);
  const handleClick = () => setShow(!show);

  return (
    <InputGroup size="md">
      <Input
        pr="4.5rem"
        type={show ? 'text' : 'password'}
        placeholder="Password"
        onChange={handleChange}
        value={value}
      />
      <InputRightElement width="4.5rem">
        <Button h="1.75rem" size="sm" onClick={handleClick}>
          {show ? 'Hide' : 'Show'}
        </Button>
      </InputRightElement>
    </InputGroup>
  );
};

const ValidatePassword = (password: string) => {
  let isValid = true;
  let message = '';

  if (password.length == 0) {
    isValid = false;
  } else if (password.length < 5) {
    isValid = false;
    message = 'Password is too short';
  }

  return { isValid, message };
};

const ValidateEmail = (email: string) => {
  const pattern = /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/;

  let isValid = true;
  let message = '';

  if (email.length == 0) {
    isValid = false;
  } else {
    isValid = pattern.test(email);
    message = isValid ? '' : 'Invalid email';
  }

  return { isValid, message };
};

type CredentialFormProps = {
  emailValue: string;
  handleEmailChange: ChangeEventHandler;
  passwordValue: string;
  handlePasswordChange: ChangeEventHandler;
  setValid: Dispatch<SetStateAction<boolean>>;
};

const CredentialForm = (props: CredentialFormProps) => {
  const [passwordIsValid, setPasswordIsValid] = useState(false);
  const [passwordValidMessage, setPasswordValidMessage] = useState('');
  const [emailIsValid, setEmailIsValid] = useState(false);
  const [emailValidMessage, setEmailValidMessage] = useState('');

  useEffect(() => {
    const { isValid, message } = ValidatePassword(props.passwordValue);

    setPasswordIsValid(isValid);
    setPasswordValidMessage(message);
  }, [props.passwordValue]);

  useEffect(() => {
    const { isValid, message } = ValidateEmail(props.emailValue);

    setEmailIsValid(isValid);
    setEmailValidMessage(message);
  }, [props.emailValue]);

  useEffect(
    () => props.setValid(passwordIsValid && emailIsValid),
    [emailIsValid, passwordIsValid, props]
  );

  return (
    <Stack>
      <Text>Email</Text>
      <Input
        value={props.emailValue}
        onChange={props.handleEmailChange}
        placeholder="name.surname@email.com"
      />
      <Text hidden={emailIsValid}>{emailValidMessage}</Text>
      <Text>Password</Text>
      <PasswordInput
        value={props.passwordValue}
        handleChange={props.handlePasswordChange}
      />
      <Text hidden={passwordIsValid}>{passwordValidMessage}</Text>
    </Stack>
  );
};

export default CredentialForm;
