/* eslint-disable */
import axios, {
  type AxiosInstance,
  type AxiosResponse,
  type AxiosRequestConfig,
} from "axios";
import { useToast } from "vue-toast-notification";

const toast = useToast();

class HTTP {
  private instance: AxiosInstance;

  constructor() {
    const baseURL = import.meta.env.VITE_APP_API_URL;
    this.instance = axios.create({ baseURL });

    this.setInterceptors();
  }

  private setInterceptors() {
    this.instance.interceptors.request.use(
      async (config) => {
        const { useAppStore } = await import("@/stores/app-global");
        const { useAuthStore } = await import("@/modules/auth/store");

        const appStore = useAppStore();
        const authStore = useAuthStore();

        appStore.showLoading();

        if (authStore.isAuthenticated && authStore.current.token) {
          config.headers = {
            ...config.headers,
            Authorization: `Bearer ${authStore.current.token}`,
          };
        }

        return config;
      },
      (error) => Promise.reject(error)
    );

    this.instance.interceptors.response.use(
      async (response) => {
        const { useAppStore } = await import("@/stores/app-global");
        const appStore = useAppStore();
        appStore.hideLoading();
        return response;
      },
      async (error) => {
        const { useAppStore } = await import("@/stores/app-global");
        const { useAuthStore } = await import("@/modules/auth/store");

        const appStore = useAppStore();
        const authStore = useAuthStore();

        appStore.hideLoading();

        const response = error.response;
        if (response) {
          const status = response.status;

          if ([400, 401, 403].includes(status)) {
            const errors = response.data.errors;

            if (status === 401) {
              authStore.errorAccount = status;
            }

            if (status === 403) {
              toast.error("Usuário não tem permissão para executar essa ação.", { duration: 7000 });
            }

            const messages = errors ?? response.data.messages?.errors ?? [];

            messages.forEach((err: any) => {
              toast.error(err.message ?? err, { duration: 7000 });
            });
          } else if ([500, 503, 504].includes(status)) {
            toast.error("Ocorreu um erro no sistema, por favor, tente novamente mais tarde.", { duration: 7000 });
          }
        }

        return Promise.reject(error);
      }
    );
  }

  get<T = any, R = AxiosResponse<T>>(url: string, config?: AxiosRequestConfig): Promise<R> {
    return this.instance.get<T, R>(url, config);
  }

  post<T = any, R = AxiosResponse<T>>(url: string, data?: any, config?: AxiosRequestConfig): Promise<R> {
    return this.instance.post<T, R>(url, data, config);
  }

  put<T = any, R = AxiosResponse<T>>(url: string, data?: any, config?: AxiosRequestConfig): Promise<R> {
    return this.instance.put<T, R>(url, data, config);
  }

  delete<T = any, R = AxiosResponse<T>>(url: string, config?: AxiosRequestConfig): Promise<R> {
    return this.instance.delete<T, R>(url, config);
  }
}

export default HTTP;
