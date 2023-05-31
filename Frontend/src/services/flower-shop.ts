/**
 * Generated by orval v6.15.0 🍺
 * Do not edit manually.
 * NoCode.FlowerShop.Api
 * OpenAPI spec version: 1.0
 */
import * as axios from 'axios';
import type { AxiosRequestConfig, AxiosResponse, AxiosError } from 'axios';
import { useQuery, useMutation } from 'react-query';
import type {
  UseQueryOptions,
  UseMutationOptions,
  QueryFunction,
  MutationFunction,
  UseQueryResult,
  QueryKey,
} from 'react-query';
export interface UpdateFlowerRequest {
  name?: string | null;
  imageUrl?: string | null;
}

export interface FlowersDto {
  id?: string;
  quantity?: number;
}

export interface CustomerRegisterRequest {
  email?: string | null;
  password?: string | null;
}

export interface CustomerLoginRequest {
  email?: string | null;
  password?: string | null;
}

export interface CreateFlowerRequest {
  name?: string | null;
  imageUrl?: string | null;
}

export interface CreateFlowerArrangementRequest {
  name?: string | null;
  description?: string | null;
  imageUrl?: string | null;
  price?: number;
  storageQuantity?: number;
  flowers?: FlowersDto[] | null;
  categoryId?: string;
}

export interface AdministratorLoginRequest {
  email?: string | null;
  password?: string | null;
}

type AwaitedInput<T> = PromiseLike<T> | T;

type Awaited<O> = O extends AwaitedInput<infer T> ? T : never;

export const postAdministratorsLogin = (
  administratorLoginRequest: AdministratorLoginRequest,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.post(
    `/administrators/login`,
    administratorLoginRequest,
    options
  );
};

export const getPostAdministratorsLoginMutationOptions = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postAdministratorsLogin>>,
    TError,
    { data: AdministratorLoginRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}): UseMutationOptions<
  Awaited<ReturnType<typeof postAdministratorsLogin>>,
  TError,
  { data: AdministratorLoginRequest },
  TContext
> => {
  const { mutation: mutationOptions, axios: axiosOptions } = options ?? {};

  const mutationFn: MutationFunction<
    Awaited<ReturnType<typeof postAdministratorsLogin>>,
    { data: AdministratorLoginRequest }
  > = (props) => {
    const { data } = props ?? {};

    return postAdministratorsLogin(data, axiosOptions);
  };

  return { mutationFn, ...mutationOptions };
};

export type PostAdministratorsLoginMutationResult = NonNullable<
  Awaited<ReturnType<typeof postAdministratorsLogin>>
>;
export type PostAdministratorsLoginMutationBody = AdministratorLoginRequest;
export type PostAdministratorsLoginMutationError = AxiosError<unknown>;

export const usePostAdministratorsLogin = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postAdministratorsLogin>>,
    TError,
    { data: AdministratorLoginRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}) => {
  const mutationOptions = getPostAdministratorsLoginMutationOptions(options);

  return useMutation(mutationOptions);
};

export const postCustomersRegister = (
  customerRegisterRequest: CustomerRegisterRequest,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.post(
    `/customers/register`,
    customerRegisterRequest,
    options
  );
};

export const getPostCustomersRegisterMutationOptions = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postCustomersRegister>>,
    TError,
    { data: CustomerRegisterRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}): UseMutationOptions<
  Awaited<ReturnType<typeof postCustomersRegister>>,
  TError,
  { data: CustomerRegisterRequest },
  TContext
> => {
  const { mutation: mutationOptions, axios: axiosOptions } = options ?? {};

  const mutationFn: MutationFunction<
    Awaited<ReturnType<typeof postCustomersRegister>>,
    { data: CustomerRegisterRequest }
  > = (props) => {
    const { data } = props ?? {};

    return postCustomersRegister(data, axiosOptions);
  };

  return { mutationFn, ...mutationOptions };
};

export type PostCustomersRegisterMutationResult = NonNullable<
  Awaited<ReturnType<typeof postCustomersRegister>>
>;
export type PostCustomersRegisterMutationBody = CustomerRegisterRequest;
export type PostCustomersRegisterMutationError = AxiosError<unknown>;

export const usePostCustomersRegister = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postCustomersRegister>>,
    TError,
    { data: CustomerRegisterRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}) => {
  const mutationOptions = getPostCustomersRegisterMutationOptions(options);

  return useMutation(mutationOptions);
};

export const postCustomersLogin = (
  customerLoginRequest: CustomerLoginRequest,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.post(`/customers/login`, customerLoginRequest, options);
};

export const getPostCustomersLoginMutationOptions = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postCustomersLogin>>,
    TError,
    { data: CustomerLoginRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}): UseMutationOptions<
  Awaited<ReturnType<typeof postCustomersLogin>>,
  TError,
  { data: CustomerLoginRequest },
  TContext
> => {
  const { mutation: mutationOptions, axios: axiosOptions } = options ?? {};

  const mutationFn: MutationFunction<
    Awaited<ReturnType<typeof postCustomersLogin>>,
    { data: CustomerLoginRequest }
  > = (props) => {
    const { data } = props ?? {};

    return postCustomersLogin(data, axiosOptions);
  };

  return { mutationFn, ...mutationOptions };
};

export type PostCustomersLoginMutationResult = NonNullable<
  Awaited<ReturnType<typeof postCustomersLogin>>
>;
export type PostCustomersLoginMutationBody = CustomerLoginRequest;
export type PostCustomersLoginMutationError = AxiosError<unknown>;

export const usePostCustomersLogin = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postCustomersLogin>>,
    TError,
    { data: CustomerLoginRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}) => {
  const mutationOptions = getPostCustomersLoginMutationOptions(options);

  return useMutation(mutationOptions);
};

export const getFlowerArrangementsAvailable = (
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.get(`/flower-arrangements/available`, options);
};

export const getGetFlowerArrangementsAvailableQueryKey = () =>
  [`/flower-arrangements/available`] as const;

export const getGetFlowerArrangementsAvailableQueryOptions = <
  TData = Awaited<ReturnType<typeof getFlowerArrangementsAvailable>>,
  TError = AxiosError<unknown>
>(options?: {
  query?: UseQueryOptions<
    Awaited<ReturnType<typeof getFlowerArrangementsAvailable>>,
    TError,
    TData
  >;
  axios?: AxiosRequestConfig;
}): UseQueryOptions<
  Awaited<ReturnType<typeof getFlowerArrangementsAvailable>>,
  TError,
  TData
> & { queryKey: QueryKey } => {
  const { query: queryOptions, axios: axiosOptions } = options ?? {};

  const queryKey =
    queryOptions?.queryKey ?? getGetFlowerArrangementsAvailableQueryKey();

  const queryFn: QueryFunction<
    Awaited<ReturnType<typeof getFlowerArrangementsAvailable>>
  > = ({ signal }) =>
    getFlowerArrangementsAvailable({ signal, ...axiosOptions });

  return { queryKey, queryFn, ...queryOptions };
};

export type GetFlowerArrangementsAvailableQueryResult = NonNullable<
  Awaited<ReturnType<typeof getFlowerArrangementsAvailable>>
>;
export type GetFlowerArrangementsAvailableQueryError = AxiosError<unknown>;

export const useGetFlowerArrangementsAvailable = <
  TData = Awaited<ReturnType<typeof getFlowerArrangementsAvailable>>,
  TError = AxiosError<unknown>
>(options?: {
  query?: UseQueryOptions<
    Awaited<ReturnType<typeof getFlowerArrangementsAvailable>>,
    TError,
    TData
  >;
  axios?: AxiosRequestConfig;
}): UseQueryResult<TData, TError> & { queryKey: QueryKey } => {
  const queryOptions = getGetFlowerArrangementsAvailableQueryOptions(options);

  const query = useQuery(queryOptions) as UseQueryResult<TData, TError> & {
    queryKey: QueryKey;
  };

  query.queryKey = queryOptions.queryKey;

  return query;
};

export const getFlowerArrangementsId = (
  id: string,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.get(`/flower-arrangements/${id}`, options);
};

export const getGetFlowerArrangementsIdQueryKey = (id: string) =>
  [`/flower-arrangements/${id}`] as const;

export const getGetFlowerArrangementsIdQueryOptions = <
  TData = Awaited<ReturnType<typeof getFlowerArrangementsId>>,
  TError = AxiosError<unknown>
>(
  id: string,
  options?: {
    query?: UseQueryOptions<
      Awaited<ReturnType<typeof getFlowerArrangementsId>>,
      TError,
      TData
    >;
    axios?: AxiosRequestConfig;
  }
): UseQueryOptions<
  Awaited<ReturnType<typeof getFlowerArrangementsId>>,
  TError,
  TData
> & { queryKey: QueryKey } => {
  const { query: queryOptions, axios: axiosOptions } = options ?? {};

  const queryKey =
    queryOptions?.queryKey ?? getGetFlowerArrangementsIdQueryKey(id);

  const queryFn: QueryFunction<
    Awaited<ReturnType<typeof getFlowerArrangementsId>>
  > = ({ signal }) => getFlowerArrangementsId(id, { signal, ...axiosOptions });

  return { queryKey, queryFn, enabled: !!id, ...queryOptions };
};

export type GetFlowerArrangementsIdQueryResult = NonNullable<
  Awaited<ReturnType<typeof getFlowerArrangementsId>>
>;
export type GetFlowerArrangementsIdQueryError = AxiosError<unknown>;

export const useGetFlowerArrangementsId = <
  TData = Awaited<ReturnType<typeof getFlowerArrangementsId>>,
  TError = AxiosError<unknown>
>(
  id: string,
  options?: {
    query?: UseQueryOptions<
      Awaited<ReturnType<typeof getFlowerArrangementsId>>,
      TError,
      TData
    >;
    axios?: AxiosRequestConfig;
  }
): UseQueryResult<TData, TError> & { queryKey: QueryKey } => {
  const queryOptions = getGetFlowerArrangementsIdQueryOptions(id, options);

  const query = useQuery(queryOptions) as UseQueryResult<TData, TError> & {
    queryKey: QueryKey;
  };

  query.queryKey = queryOptions.queryKey;

  return query;
};

export const deleteFlowerArrangementsId = (
  id: string,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.delete(`/flower-arrangements/${id}`, options);
};

export const getDeleteFlowerArrangementsIdMutationOptions = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof deleteFlowerArrangementsId>>,
    TError,
    { id: string },
    TContext
  >;
  axios?: AxiosRequestConfig;
}): UseMutationOptions<
  Awaited<ReturnType<typeof deleteFlowerArrangementsId>>,
  TError,
  { id: string },
  TContext
> => {
  const { mutation: mutationOptions, axios: axiosOptions } = options ?? {};

  const mutationFn: MutationFunction<
    Awaited<ReturnType<typeof deleteFlowerArrangementsId>>,
    { id: string }
  > = (props) => {
    const { id } = props ?? {};

    return deleteFlowerArrangementsId(id, axiosOptions);
  };

  return { mutationFn, ...mutationOptions };
};

export type DeleteFlowerArrangementsIdMutationResult = NonNullable<
  Awaited<ReturnType<typeof deleteFlowerArrangementsId>>
>;

export type DeleteFlowerArrangementsIdMutationError = AxiosError<unknown>;

export const useDeleteFlowerArrangementsId = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof deleteFlowerArrangementsId>>,
    TError,
    { id: string },
    TContext
  >;
  axios?: AxiosRequestConfig;
}) => {
  const mutationOptions = getDeleteFlowerArrangementsIdMutationOptions(options);

  return useMutation(mutationOptions);
};

export const postFlowerArrangements = (
  createFlowerArrangementRequest: CreateFlowerArrangementRequest,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.post(
    `/flower-arrangements`,
    createFlowerArrangementRequest,
    options
  );
};

export const getPostFlowerArrangementsMutationOptions = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postFlowerArrangements>>,
    TError,
    { data: CreateFlowerArrangementRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}): UseMutationOptions<
  Awaited<ReturnType<typeof postFlowerArrangements>>,
  TError,
  { data: CreateFlowerArrangementRequest },
  TContext
> => {
  const { mutation: mutationOptions, axios: axiosOptions } = options ?? {};

  const mutationFn: MutationFunction<
    Awaited<ReturnType<typeof postFlowerArrangements>>,
    { data: CreateFlowerArrangementRequest }
  > = (props) => {
    const { data } = props ?? {};

    return postFlowerArrangements(data, axiosOptions);
  };

  return { mutationFn, ...mutationOptions };
};

export type PostFlowerArrangementsMutationResult = NonNullable<
  Awaited<ReturnType<typeof postFlowerArrangements>>
>;
export type PostFlowerArrangementsMutationBody = CreateFlowerArrangementRequest;
export type PostFlowerArrangementsMutationError = AxiosError<unknown>;

export const usePostFlowerArrangements = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postFlowerArrangements>>,
    TError,
    { data: CreateFlowerArrangementRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}) => {
  const mutationOptions = getPostFlowerArrangementsMutationOptions(options);

  return useMutation(mutationOptions);
};

export const postFlowers = (
  createFlowerRequest: CreateFlowerRequest,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.post(`/flowers`, createFlowerRequest, options);
};

export const getPostFlowersMutationOptions = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postFlowers>>,
    TError,
    { data: CreateFlowerRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}): UseMutationOptions<
  Awaited<ReturnType<typeof postFlowers>>,
  TError,
  { data: CreateFlowerRequest },
  TContext
> => {
  const { mutation: mutationOptions, axios: axiosOptions } = options ?? {};

  const mutationFn: MutationFunction<
    Awaited<ReturnType<typeof postFlowers>>,
    { data: CreateFlowerRequest }
  > = (props) => {
    const { data } = props ?? {};

    return postFlowers(data, axiosOptions);
  };

  return { mutationFn, ...mutationOptions };
};

export type PostFlowersMutationResult = NonNullable<
  Awaited<ReturnType<typeof postFlowers>>
>;
export type PostFlowersMutationBody = CreateFlowerRequest;
export type PostFlowersMutationError = AxiosError<unknown>;

export const usePostFlowers = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof postFlowers>>,
    TError,
    { data: CreateFlowerRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}) => {
  const mutationOptions = getPostFlowersMutationOptions(options);

  return useMutation(mutationOptions);
};

export const getFlowers = (
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.get(`/flowers`, options);
};

export const getGetFlowersQueryKey = () => [`/flowers`] as const;

export const getGetFlowersQueryOptions = <
  TData = Awaited<ReturnType<typeof getFlowers>>,
  TError = AxiosError<unknown>
>(options?: {
  query?: UseQueryOptions<
    Awaited<ReturnType<typeof getFlowers>>,
    TError,
    TData
  >;
  axios?: AxiosRequestConfig;
}): UseQueryOptions<Awaited<ReturnType<typeof getFlowers>>, TError, TData> & {
  queryKey: QueryKey;
} => {
  const { query: queryOptions, axios: axiosOptions } = options ?? {};

  const queryKey = queryOptions?.queryKey ?? getGetFlowersQueryKey();

  const queryFn: QueryFunction<Awaited<ReturnType<typeof getFlowers>>> = ({
    signal,
  }) => getFlowers({ signal, ...axiosOptions });

  return { queryKey, queryFn, ...queryOptions };
};

export type GetFlowersQueryResult = NonNullable<
  Awaited<ReturnType<typeof getFlowers>>
>;
export type GetFlowersQueryError = AxiosError<unknown>;

export const useGetFlowers = <
  TData = Awaited<ReturnType<typeof getFlowers>>,
  TError = AxiosError<unknown>
>(options?: {
  query?: UseQueryOptions<
    Awaited<ReturnType<typeof getFlowers>>,
    TError,
    TData
  >;
  axios?: AxiosRequestConfig;
}): UseQueryResult<TData, TError> & { queryKey: QueryKey } => {
  const queryOptions = getGetFlowersQueryOptions(options);

  const query = useQuery(queryOptions) as UseQueryResult<TData, TError> & {
    queryKey: QueryKey;
  };

  query.queryKey = queryOptions.queryKey;

  return query;
};

export const deleteFlowersId = (
  id: string,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.delete(`/flowers/${id}`, options);
};

export const getDeleteFlowersIdMutationOptions = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof deleteFlowersId>>,
    TError,
    { id: string },
    TContext
  >;
  axios?: AxiosRequestConfig;
}): UseMutationOptions<
  Awaited<ReturnType<typeof deleteFlowersId>>,
  TError,
  { id: string },
  TContext
> => {
  const { mutation: mutationOptions, axios: axiosOptions } = options ?? {};

  const mutationFn: MutationFunction<
    Awaited<ReturnType<typeof deleteFlowersId>>,
    { id: string }
  > = (props) => {
    const { id } = props ?? {};

    return deleteFlowersId(id, axiosOptions);
  };

  return { mutationFn, ...mutationOptions };
};

export type DeleteFlowersIdMutationResult = NonNullable<
  Awaited<ReturnType<typeof deleteFlowersId>>
>;

export type DeleteFlowersIdMutationError = AxiosError<unknown>;

export const useDeleteFlowersId = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof deleteFlowersId>>,
    TError,
    { id: string },
    TContext
  >;
  axios?: AxiosRequestConfig;
}) => {
  const mutationOptions = getDeleteFlowersIdMutationOptions(options);

  return useMutation(mutationOptions);
};

export const putFlowersId = (
  id: string,
  updateFlowerRequest: UpdateFlowerRequest,
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.put(`/flowers/${id}`, updateFlowerRequest, options);
};

export const getPutFlowersIdMutationOptions = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof putFlowersId>>,
    TError,
    { id: string; data: UpdateFlowerRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}): UseMutationOptions<
  Awaited<ReturnType<typeof putFlowersId>>,
  TError,
  { id: string; data: UpdateFlowerRequest },
  TContext
> => {
  const { mutation: mutationOptions, axios: axiosOptions } = options ?? {};

  const mutationFn: MutationFunction<
    Awaited<ReturnType<typeof putFlowersId>>,
    { id: string; data: UpdateFlowerRequest }
  > = (props) => {
    const { id, data } = props ?? {};

    return putFlowersId(id, data, axiosOptions);
  };

  return { mutationFn, ...mutationOptions };
};

export type PutFlowersIdMutationResult = NonNullable<
  Awaited<ReturnType<typeof putFlowersId>>
>;
export type PutFlowersIdMutationBody = UpdateFlowerRequest;
export type PutFlowersIdMutationError = AxiosError<unknown>;

export const usePutFlowersId = <
  TError = AxiosError<unknown>,
  TContext = unknown
>(options?: {
  mutation?: UseMutationOptions<
    Awaited<ReturnType<typeof putFlowersId>>,
    TError,
    { id: string; data: UpdateFlowerRequest },
    TContext
  >;
  axios?: AxiosRequestConfig;
}) => {
  const mutationOptions = getPutFlowersIdMutationOptions(options);

  return useMutation(mutationOptions);
};

export const getTestPopulateData = (
  options?: AxiosRequestConfig
): Promise<AxiosResponse<void>> => {
  return axios.default.get(`/test/populate-data`, options);
};

export const getGetTestPopulateDataQueryKey = () =>
  [`/test/populate-data`] as const;

export const getGetTestPopulateDataQueryOptions = <
  TData = Awaited<ReturnType<typeof getTestPopulateData>>,
  TError = AxiosError<unknown>
>(options?: {
  query?: UseQueryOptions<
    Awaited<ReturnType<typeof getTestPopulateData>>,
    TError,
    TData
  >;
  axios?: AxiosRequestConfig;
}): UseQueryOptions<
  Awaited<ReturnType<typeof getTestPopulateData>>,
  TError,
  TData
> & { queryKey: QueryKey } => {
  const { query: queryOptions, axios: axiosOptions } = options ?? {};

  const queryKey = queryOptions?.queryKey ?? getGetTestPopulateDataQueryKey();

  const queryFn: QueryFunction<
    Awaited<ReturnType<typeof getTestPopulateData>>
  > = ({ signal }) => getTestPopulateData({ signal, ...axiosOptions });

  return { queryKey, queryFn, ...queryOptions };
};

export type GetTestPopulateDataQueryResult = NonNullable<
  Awaited<ReturnType<typeof getTestPopulateData>>
>;
export type GetTestPopulateDataQueryError = AxiosError<unknown>;

export const useGetTestPopulateData = <
  TData = Awaited<ReturnType<typeof getTestPopulateData>>,
  TError = AxiosError<unknown>
>(options?: {
  query?: UseQueryOptions<
    Awaited<ReturnType<typeof getTestPopulateData>>,
    TError,
    TData
  >;
  axios?: AxiosRequestConfig;
}): UseQueryResult<TData, TError> & { queryKey: QueryKey } => {
  const queryOptions = getGetTestPopulateDataQueryOptions(options);

  const query = useQuery(queryOptions) as UseQueryResult<TData, TError> & {
    queryKey: QueryKey;
  };

  query.queryKey = queryOptions.queryKey;

  return query;
};
