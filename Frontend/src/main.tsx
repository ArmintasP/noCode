import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import Router from './pages/router.tsx';
import { ChakraProvider } from '@chakra-ui/react';
import { AuthProvider } from './context/authProvider.tsx';
import { QueryClient, QueryClientProvider } from 'react-query';
import axios from 'axios';

const queryClient = new QueryClient();

axios.defaults.baseURL = 'https://localhost:2039/';

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <React.StrictMode>
    <ChakraProvider>
      <AuthProvider>
        <QueryClientProvider client={queryClient}>
          <BrowserRouter>
            <Router />
          </BrowserRouter>
        </QueryClientProvider>
      </AuthProvider>
    </ChakraProvider>
  </React.StrictMode>
);
