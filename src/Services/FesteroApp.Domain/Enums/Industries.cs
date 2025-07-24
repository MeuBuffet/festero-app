using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FesteroApp.Domain.Enums;

public enum Industries
{
    [Description("Microempreendedor Individual (MEI)")] MEI,
    [Description("Empresa de Pequeno Porte (EPP)")] EPP,
    [Description("Microempresa (ME)")] ME,
    [Description("Sociedade Limitada (LTDA)")] LTDA,
    [Description("Sociedade Anônima (S/A)")] SA,
    [Description("Empresário Individual")] EMPRESARIO_INDIVIDUAL,
    [Description("Associação ou Organização sem fins lucrativos")] ASSOCIACAO,
    [Description("Órgão Público")] ORGAO_PUBLICO,
    [Description("Outro")] OUTRO,
}