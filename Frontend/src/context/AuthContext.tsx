import { createContext } from 'react';
import { User } from '../hooks/useUser';

interface AuthContext {
  user: User | null;
  admin: User | null;
  setUser: (user: User | null) => void;
  setAdmin: (user: User | null) => void;
}

export const AuthContext = createContext<AuthContext>({
  user: null,
  admin: null,
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  setUser: () => {},
  // eslint-disable-next-line @typescript-eslint/no-empty-function
  setAdmin: () => {},
});
