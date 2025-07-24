// ESSE É UM FILTRO DE EXEMPLO, SUBSISTITUA-O PELOS FILTROS DO PROJETO

export interface FiltersType {
  formatPhone: (string: string) => string;
  formatDocument: (document: string) => string | undefined;
  formatDate: (date: string) => string | undefined;
  formatDateList: (date: string) => string | undefined;
  formatCurrency: (value: string) => string;
}

const filters: FiltersType = {
  formatPhone(string) {
    if (!string) return "Não informado";
    string = string.replace(/[^\d]/g, "");
    if (string && string.length === 11) {
      return string.replace(/(\d{2})(\d{5})(\d{4})/, "($1) $2-$3");
    } else if (string && string.length === 10) {
      return string.replace(/(\d{2})(\d{4})(\d{4})/, "($1) $2-$3");
    }
    return string;
  },

  // FORMATA O DOCUMENTO PARA MOSTRAR PONTOS, TRAÇOS E BARRAS
  formatDocument(document: string) {
    if (!document || document == "") return "Não informado";
    if (document.length === 11) {
      const documentFormatted = document.replace(
        /^(\d{3})(\d{3})(\d{3})(\d{2})$/,
        "$1.$2.$3-$4",
      );
      return documentFormatted;
    } else if (document.length === 14) {
      const documentFormatted = document.replace(
        /^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$/,
        "$1.$2.$3/$4-$5",
      );
      return documentFormatted;
    }
  },

  //FORMATA A DATA PARA PT-BR SEM HORA E MINUTO
  formatDate(date: string) {
    if (!date || date == "") return "Não informado";
    if (date) {
      const formattedDate = new Date(date + "T00:00:00");
      const options: Intl.DateTimeFormatOptions = {
        year: "numeric",
        month: "2-digit",
        day: "2-digit",
      };
      return formattedDate.toLocaleDateString("pt-BR", options);
    }
  },

  //RETIRA HORA E MINUTO DA DATA
  formatDateList(date: string) {
    if (!date || date == "") return "Não informado";
    const partes = date.split(" ");

    if (partes.length >= 2) {
      return partes[0];
    }
  },

  //FORMATA PARA MOEDA PT-BR
  formatCurrency(value: string) {
    const formattedValue = parseFloat(value).toLocaleString("pt-BR", {
      style: "currency",
      currency: "BRL",
      currencyDisplay: "code",
      minimumFractionDigits: 2,
    });

    const valueWithoutCurrencyCode = formattedValue.replace("BRL", "").trim();

    return valueWithoutCurrencyCode;
  },
};

export default filters;
