import { useEffect } from "react";
import { User } from "./useUser";
import { useLocalStorage } from "./useLocalStorage";
import { useAdminUser } from "./useAdminUser";

export const useAdminAuth = () => {
  const { admin, addUser: addAdmin, removeUser: removeAdmin } = useAdminUser();
  const { getItem } = useLocalStorage();

  useEffect(() => {
    const user = getItem("admin");
    if (user) {
      addAdmin(JSON.parse(user));
    }
  }, [addAdmin, getItem]);

  const login = (user: User) => {
    addAdmin(user);
  };

  const logout = () => {
    removeAdmin();
  };

  return { admin, login, logout };
};