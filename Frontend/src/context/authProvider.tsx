import { createContext, useState } from 'react';
import { PropsWithChildren } from 'react';

type AuthType = {
  token?: string;
  email?: string;
};

type AuthContextType = {
  auth?: AuthType;
  setAuth: React.Dispatch<React.SetStateAction<AuthType>>;
  persist?: boolean;
  setPersist: React.Dispatch<React.SetStateAction<boolean>>;
};

const AuthContext = createContext<AuthContextType>({
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  setAuth: function (): void {
    throw new Error('Function not implemented.');
  },
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  setPersist: function (): void {
    throw new Error('Function not implemented.');
  },
});

export const AuthProvider = (props: PropsWithChildren) => {
  const [auth, setAuth] = useState<AuthType>({});
  const [persist, setPersist] = useState<boolean>(
    JSON.parse(localStorage.getItem('persist') ?? 'false') || false
  );

  return (
    <AuthContext.Provider value={{ auth, setAuth, persist, setPersist }}>
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
