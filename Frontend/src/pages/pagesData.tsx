import CustomerSignInPage from './Authentication/customerSignInPage';
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
    path: '*',
    element: <ErrorPage />,
    title: 'Error',
  },
];

export default pagesData;
