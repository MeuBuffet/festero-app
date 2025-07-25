using System.ComponentModel;

namespace FesteroApp.SharedKernel.Securities;

public enum RoleTypes
{
//Acesso total, não pode ser deletado, gerencia plano
    [Description("Proprietário")] OWNER,

//Gerencia equipe e eventos, exceto plano e exclusão da empresa
    [Description("Administrador")] ADMIN,

// Visualiza ou edita tarefas específicas conforme perfil(porteiro, cozinheiro etc)
    [Description("Colaborador")] COLLABORATOR,

// Acesso apenas leitura
    [Description("Convidado")] VIEWER,
}