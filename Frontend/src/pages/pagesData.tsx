import AdminPage from './Admin/adminPage';
import ArrangementDetailPage from './ArrangementDetails/ArrangementDetailsPage';
import CustomerSignInPage from './Authentication/customerSignInPage';
import CustomerSignUpPage from './Authentication/customerSignUpPage';
import ErrorPage from './Error/errorPage';
import HomePage from './Home/homePage';

interface routerType {
  title: string;
  path: string;
  element: JSX.Element;
}

const pagesData: routerType[] = [
  {
    path: '/',
    element: <HomePage />,
    title: 'Home',
  },
  {
    path: '/signin',
    element: <CustomerSignInPage />,
    title: 'Sign in',
  },
  {
    path: '/signup',
    element: <CustomerSignUpPage />,
    title: 'Sign up',
  },
  {
    path: '/details/:arrangementId',
    element: <ArrangementDetailPage />,
    title: 'Details',
  },
  {
    path: '/admin',
    element: <AdminPage />,
    title: 'Admin',
  },
  {
    path: '*',
    element: <ErrorPage />,
    title: 'Error',
  },
];

export default pagesData;
