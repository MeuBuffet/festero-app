import axios, { AxiosInstance, AxiosResponse, AxiosRequestConfig } from "axios";
import { useAuthStore } from "@/modules/auth/store/auth.store";
import { useAppStore } from "@/stores/app-global";
import { useToast } from "vue-toast-notification";
import type { App } from "vue";

const toast = useToast();

export class HTTP {
  private instance: AxiosInstance;

  constructor(url: string) {
    this.instance = axios.create({
      baseURL: import.meta.env.VITE_APP_API_URL as string,
      headers: {
        "Content-Type": "application/json",
      },
    });
    this.setInterceptors();
    Object.assign(this, this.instance);
  }
  private setInterceptors() {
    const authStore = useAuthStore();
    const appStore = useAppStore();

    this.instance.interceptors.request.use(
      (config: AxiosRequestConfig) => {
        appStore.showLoading();
        if (authStore.isAuthenticated && authStore.current?.token) {
          config.headers = config.headers || {};
          config.headers.Authorization = `Bearer ${authStore.current.token}`;
        }
        return config;
      },
      (error: AxiosError) => {
        appStore.hideLoading();
        return Promise.reject(error);
      }
    );
    this.instance.interceptors.response.use(
      (response: AxiosResponse) => {
        appStore.hideLoading();
        return response;
      },
      (error: AxiosError) => {
        appStore.hideLoading();

        const status = error.response?.status;
        const data = error.response?.data;

        if (status === 401) {
          toast.error("Você não está autenticado, faça o login novamente.", {
            timeout: 7000,
          });
          authStore.signOut();
        } else if ([400, 403, 404, 405, 409, 422].includes(status || 0)) {
          const message =
            (data?.title ?? data) || "Erro ao processar requisição.";
          toast.error(message, { timeout: 7000 });
        } else if (status === 500) {
          toast.error(
            "Ocorreu um erro no sistema. Tente novamente mais tarde.",
            { timeout: 7000 }
          );
        }

        return Promise.reject(error);
      }
    );
  }

  // Expõe os métodos padrão se necessário
  get<T = any>(
    url: string,
    config?: AxiosRequestConfig
  ): Promise<AxiosResponse<T>> {
    return this.instance.get(url, config);
  }

  post<T = any>(
    url: string,
    data?: any,
    config?: AxiosRequestConfig
  ): Promise<AxiosResponse<T>> {
    return this.instance.post(url, data, config);
  }

  put<T = any>(
    url: string,
    data?: any,
    config?: AxiosRequestConfig
  ): Promise<AxiosResponse<T>> {
    return this.instance.put(url, data, config);
  }

  delete<T = any>(
    url: string,
    config?: AxiosRequestConfig
  ): Promise<AxiosResponse<T>> {
    return this.instance.delete(url, config);
  }
}
