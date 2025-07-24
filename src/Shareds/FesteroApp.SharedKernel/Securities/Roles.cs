namespace FesteroApp.SharedKernel.Securities;

public static class Roles
{
    //Acesso total, não pode ser deletado, gerencia plano
    public const string OWNER = "OWNER";

    //Gerencia equipe e eventos, exceto plano e exclusão da empresa
    public const string ADMIN = "ADMIN";

    // Visualiza ou edita tarefas específicas conforme perfil(porteiro, cozinheiro etc)
    public const string COLLABORATOR = "COLLABORATOR";

    // Acesso apenas leitura
    public const string VIEWER = "VIEWER";
}