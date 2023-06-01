import { useCallback, useContext } from "react";
import { AuthContext } from "../context/AuthContext";
import { useLocalStorage } from "./useLocalStorage";
import { User } from "./useUser";

export const useAdminUser = () => {
  const { admin, setAdmin } = useContext(AuthContext);
  const { setItem } = useLocalStorage();

  const addUser = useCallback((user: User) => {
    setAdmin(user);
    setItem("admin", JSON.stringify(user));
  }, [setAdmin, setItem]);

  const removeUser = useCallback(() => {
    setAdmin(null);
    setItem("admin", "");
  }, [setAdmin, setItem]);

  return { admin, addUser, removeUser };
};