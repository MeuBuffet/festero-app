// src/stores/auth/auth.store.ts
import { defineStore } from "pinia";
import type {
  AuthState,
  LoginPayload,
  RegisterPayload,
  ForgotPasswordPayload,
} from "./types";

export const useAuthStore = defineStore("auth", {
  state: (): AuthState => ({
    current: null,
    isAuthenticated: false,
    loading: false,
    error: null,
  }),

  actions: {
    async login(payload: LoginPayload) {
      this.loading = true;
      this.error = null;
      try {
        // Aqui você faria a chamada real à API:
        // const response = await api.post('/auth/login', payload)
        const response = {
          user: { id: 1, name: "João", email: payload.email },
          token: "fake-token",
          expires: new Date(Date.now() + 3600 * 1000).toISOString(),
        };

        this.current = response;
        this.isAuthenticated = true;
        localStorage.setItem(
          import.meta.env.VITE_APP_AUTH,
          JSON.stringify(response)
        );
      } catch (err: any) {
        this.error = "Falha ao fazer login";
        this.isAuthenticated = false;
      } finally {
        this.loading = false;
      }
    },

    async register(payload: RegisterPayload) {
      this.loading = true;
      this.error = null;
      try {
        // await api.post('/auth/register', payload)
        console.log("Registrando usuário", payload);
      } catch (err: any) {
        this.error = "Erro ao registrar";
      } finally {
        this.loading = false;
      }
    },

    async forgotPassword(payload: ForgotPasswordPayload) {
      this.loading = true;
      this.error = null;
      try {
        // await api.post('/auth/forgot-password', payload)
        console.log("Enviando recuperação de senha para", payload.email);
      } catch (err: any) {
        this.error = "Erro ao enviar e-mail de recuperação";
      } finally {
        this.loading = false;
      }
    },

    logout() {
      this.current = null;
      this.isAuthenticated = false;
      localStorage.removeItem(import.meta.env.VITE_APP_AUTH);
    },

    loadFromStorage() {
      const saved = localStorage.getItem(import.meta.env.VITE_APP_AUTH);
      if (saved) {
        this.current = JSON.parse(saved);
        this.isAuthenticated = true;
      }
    },
  },
});
