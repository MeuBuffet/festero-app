using System.ComponentModel;

namespace FesteroApp.Domain.Enums;

public enum OrganizationTypes
{
    [Description("Casas de Festas")] CASAS_DE_FESTAS,
    [Description("Buffet")] BUFFET,
    [Description("Decoração")] DECORACAO,
    [Description("Fotografia e Filmagem")] FOTOGRAFIA_FILMAGEM,
    [Description("Aluguel de Materiais")] ALUGUEL_MATERIAIS,
    [Description("Eventos Corporativos")] EVENTOS_CORPORATIVOS,
    [Description("Eventos Sociais")] EVENTOS_SOCIAIS,
    [Description("Eventos Religiosos")] EVENTOS_RELIGIOSOS,
    [Description("Eventos Esportivos")] EVENTOS_ESPORTIVOS,
    [Description("Eventos Culturais")] EVENTOS_CULTURAIS,
    [Description("Eventos Públicos/Governamentais")] EVENTOS_PUBLICOS,
    [Description("Animação e Recreação")] ANIMACAO_RECREACAO,
    [Description("Som, Luz e Palco")] SOM_LUZ_PALCO,
    [Description("Serviços de Segurança")] SERVICO_SEGURANCA,
    [Description("Marketing e Promoções")] MARKETING_PROMOCOES,
    [Description("Locação de Espaço")] LOCACAO_ESPACO,
    [Description("Cerimonial e Assessoria")] CERIMONIAL_ASSESSORIA,
    [Description("Alimentação / Food Truck")] ALIMENTACAO_FOODTRUCK,
    [Description("Autônomo")] AUTONOMO,
    [Description("Cooperativa")] COOPERATIVA,
    [Description("Franquia")] FRANQUIA,
    [Description("Startup")] STARTUP,
    [Description("Transporte e Logística")] TRANSPORTE_LOGISTICA,
    [Description("Outros")] OUTRAS
}