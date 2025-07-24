export interface AuthState {
  current: AuthUser | null
  isAuthenticated: boolean
  loading: boolean
  error: string | null
}

export interface AuthUser {
  user: {
    id: number
    name: string
    email: string
  }
  token: string
  expires: string
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
