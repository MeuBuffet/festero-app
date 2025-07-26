import { jwtDecode } from "jwt-decode";

export interface JwtPayload {
  id?: string;
  email?: string;
  name?: string;
  roles?: { TenantId: string; Company: string; Role: string }[];
  expiresIn?: string;
  nbf?: number;
  exp?: number;
  iat?: number;
  [key: string]: any;
}

export function decodeJwt(token: string): JwtPayload | null {
  try {
    return jwtDecode<JwtPayload>(token);
  } catch (error) {
    console.error("Erro ao decodificar o JWT:", error);
    return null;
  }
}
