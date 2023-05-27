import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import Router from './pages/router.tsx';
import { ChakraProvider } from '@chakra-ui/react';
import { QueryClient, QueryClientProvider } from 'react-query';
import axios from 'axios';
import AuthProvider from './context/AuthProvider.tsx';

const queryClient = new QueryClient();
axios.defaults.baseURL = 'https://localhost:2039/';

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
  <ChakraProvider>
    <AuthProvider>
      <QueryClientProvider client={queryClient}>
        <BrowserRouter>
          <Router />
        </BrowserRouter>
      </QueryClientProvider>
    </AuthProvider>
  </ChakraProvider>
);
