import { useContext } from "react";
import { AuthContext } from "../context/AuthContext";
import { useLocalStorage } from "./useLocalStorage";
import { User } from "./useUser";

export const useAdminUser = () => {
  const { admin, setAdmin } = useContext(AuthContext);
  const { setItem } = useLocalStorage();

  const addUser = (user: User) => {
    setAdmin(user);
    setItem("admin", JSON.stringify(user));
  };

  const removeUser = () => {
    setAdmin(null);
    setItem("admin", "");
  };

  return { admin, addUser, removeUser };
};