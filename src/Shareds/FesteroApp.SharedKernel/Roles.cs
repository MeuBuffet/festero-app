using System.ComponentModel;

namespace FesteroApp.SharedKernel;

public enum Roles
{
    [Description("Acesso total, não pode ser deletado, gerencia plano")]
    OWNER,
    [Description("Gerencia equipe e eventos, exceto plano e exclusão da empresa")]
    ADMIN,
    [Description("Visualiza ou edita tarefas específicas conforme perfil (porteiro, cozinheiro etc)")]
    COLLABORATOR,
    [Description("Acesso apenas leitura")]
    VIEWER
}