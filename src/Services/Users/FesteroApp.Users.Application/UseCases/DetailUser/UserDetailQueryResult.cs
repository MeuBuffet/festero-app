namespace FesteroApp.Users.Application.UseCases.DetailUser
{
    public class UserDetailQueryResult(Guid? id, string? name, string? email)
    {
        public Guid? Id { get; set; } = id;

        public string? Name { get; set; } = name;

        public string? Email { get; set; } = email;
    }
}