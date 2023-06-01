import { useMemo } from 'react';
import { useAdminAuth } from '../../hooks/useAdminAuth';
import AdminSignInPage from '../Authentication/adminSignInPage';
import ContentManagementPage from './ContentManagement/contentManagementPage';

const AdminPage = () => {
  const { admin, logout } = useAdminAuth();

  const page = useMemo(() => {
    if (admin?.authToken == null) {
      return <AdminSignInPage />;
    }

    return <ContentManagementPage adminUser={admin} logout={logout} />;
  }, [admin, logout]);

  return page;
};

export default AdminPage;
