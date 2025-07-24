import { useToast } from "vue-toastification";

export interface ToastOptions {
  text: string;
  time?: number;
  type: "success" | "error" | "warning" | "info";
}

export interface Params {
  field?: string;
  mask?: string;
  min?: number;
}

export interface HelpersType {
  validateDocument: (document: string) => boolean;
  validateEmail: (document: string) => boolean;
  validateCPF: (document: string) => boolean;
  validateCNPJ: (document: string) => boolean;
  validateNotText: (document: string) => boolean;
  maxDate: (document: string) => boolean;
}

const toastMessage = ({
  text,
  time = 3000,
  type = "success",
}: ToastOptions) => {
  const toastTypes = {
    error: useToast().error,
    warning: useToast().warning,
    info: useToast().info,
    success: useToast().success,
  };

  const toastFunction = toastTypes[type];
  toastFunction(text, { timeout: time });
};

const statusMessages = {
  linkSuccess: "OK - Conta vinculada com sucesso.",
  approval: "OK - Eventos aprovados com sucesso.",
  rejection: "OK - Eventos rejeitados com sucesso.",
  400: "Bad Request - A requisição possui sintaxe inválida ou não pode ser processada pelo servidor.",
  401: "Unauthorized - A requisição requer autenticação do usuário ou a autenticação falhou.",
  403: "Você não tem permissão para acessar esta página.",
  404: "Not Found - O recurso solicitado não foi encontrado no servidor.",
  500: "Internal Server Error - Ocorreu um erro no sistema, por favor, tente novamente mais tarde.",
  502: "Bad Gateway - O servidor, agindo como um gateway ou proxy, recebeu uma resposta inválida do servidor upstream.",
  503: "Service Unavailable - O servidor não está disponível no momento devido a sobrecarga ou manutenção.",
  default: "Erro desconhecido",
};

const statusCodeMessage = (status: keyof typeof statusMessages) => {
  return statusMessages[status] || statusMessages.default;
};

const vldMessage = (validation = "required", params: Params | null = null) => {
  const messages = {
    required: "Campo obrigatório",
    email: "Email inválido",
    document: "Documento inválido",
    sameAs: `Campo difere de '${params?.field}'`,
    format: `Formato inválido — ex: ${params?.mask}`,
    length: `Tamanho inválido — Mínimo: ${params?.min} caracteres`,
  };

  return messages[validation as keyof typeof messages] || messages.required;
};

const helpers: HelpersType = {
  // VALIDADOR DE DOCUMENTO
  validateDocument(document) {
    // Remove caracteres não numéricos do documento
    const cleanedDocument = document.replace(/\D/g, "");

    // Verifica se é CNPF (CPF) ou CNPJ
    if (cleanedDocument.length === 11) {
      return this.validateCPF(cleanedDocument);
    } else if (cleanedDocument.length === 14) {
      return this.validateCNPJ(cleanedDocument);
    }

    return false;
  },

  // VALIDA CPF
  validateCPF(cpf) {
    // Verifica se todos os dígitos são iguais
    if (/^(\d)\1+$/.test(cpf)) {
      return false;
    }

    let sum = 0;
    let remainder;

    for (let i = 1; i <= 9; i++) {
      sum = sum + parseInt(cpf.substring(i - 1, i)) * (11 - i);
    }

    remainder = (sum * 10) % 11;

    if (remainder === 10 || remainder === 11) {
      remainder = 0;
    }

    if (remainder !== parseInt(cpf.substring(9, 10))) {
      return false;
    }

    sum = 0;

    for (let i = 1; i <= 10; i++) {
      sum = sum + parseInt(cpf.substring(i - 1, i)) * (12 - i);
    }

    remainder = (sum * 10) % 11;

    if (remainder === 10 || remainder === 11) {
      remainder = 0;
    }

    if (remainder !== parseInt(cpf.substring(10, 11))) {
      return false;
    }

    return true;
  },

  // VALIDA CNPJ
  validateCNPJ(cnpj) {
    // Verifica se todos os dígitos são iguais
    if (/^(\d)\1+$/.test(cnpj)) {
      return false;
    }

    let size = cnpj.length - 2;
    let numbers = cnpj.substring(0, size);
    const digits = cnpj.substring(size);
    let sum = 0;
    let pos = size - 7;

    for (let i = size; i >= 1; i--) {
      sum += parseInt(numbers.charAt(size - i)) * pos--;
      if (pos < 2) {
        pos = 9;
      }
    }

    let result = sum % 11 < 2 ? 0 : 11 - (sum % 11);

    if (result !== parseInt(digits.charAt(0))) {
      return false;
    }

    size += 1;
    numbers = cnpj.substring(0, size);
    sum = 0;
    pos = size - 7;

    for (let i = size; i >= 1; i--) {
      sum += parseInt(numbers.charAt(size - i)) * pos--;
      if (pos < 2) {
        pos = 9;
      }
    }

    result = sum % 11 < 2 ? 0 : 11 - (sum % 11);

    if (result !== parseInt(digits.charAt(1))) {
      return false;
    }

    return true;
  },

  // VALIDADOR EMAIL
  validateEmail(email) {
    const emailRegex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    return emailRegex.test(email);
  },

  // VALIDADOR DE INPUT SE NAO CONTEM TEXTO
  validateNotText(inputString: string) {
    const regex = /^[0-9./-]*$/;

    if (inputString && regex.test(inputString)) {
      return true;
    } else {
      return false;
    }
  },

  maxDate(date: string): boolean {
    const today = new Date().toISOString().split("T")[0];
    return date <= today;
  },
};

export default {
  toastMessage,
  statusCodeMessage,
  vldMessage,
  helpers,
};
