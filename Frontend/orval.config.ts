import { defineConfig } from 'orval';

export default defineConfig({
  flower_shop: {
    input: {
      target: './swagger.json',
    },
    output: {
      target: './src/services/flower-shop.ts',
      client: 'react-query',
      tslint: true,
      prettier: true,
    },
  },
});
