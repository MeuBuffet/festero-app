export interface AuthState {
  current: AuthUser | null
  isAuthenticated: boolean
  loading: boolean
  error: string | null
}

export interface AuthUser {
  id: string;
  name: string;
  email: string;
  roles: any[]; 
  token: string;
  expires: string;
}

export interface LoginPayload {
  email: string
  password: string
}

export interface RegisterPayload {
  firstName: string
  lastName: string
  email: string
  password: string
  company?: {
    name?: string
    cnpj?: string
  }
}

export interface ForgotPasswordPayload {
  email: string
}

export interface Notification {
  title: string;
  desc?: string;
  icon?: string;
  iconMedia?: string;
  img?: string;
  time?: string;
}

export type Events = {
  'user:login': { id: string; name: string };
  'notification:new': { title: string; message: string };
  // adicione outros eventos aqui
};