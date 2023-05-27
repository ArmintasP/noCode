import { PropsWithChildren, useState } from 'react';
import { AuthContext } from './AuthContext';
import { User } from '../hooks/useUser';

const AuthProvider = (props: PropsWithChildren) => {
  const [user, setUser] = useState<User | null>(null);

  return (
    <AuthContext.Provider value={{ user, setUser }}>
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;
