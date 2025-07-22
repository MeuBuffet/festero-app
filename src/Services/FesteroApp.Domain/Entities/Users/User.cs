namespace FesteroApp.Domain.Entities.Users;

public class User
{
    public User()
    {

    }

    public User(Guid id, string? name, string? email, string? password) : this()
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;

        CreatedOn = UpdatedOn = DateTime.Now;
    }

    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public void Delete()
    {
        DeletedOn = DateTime.Now;
    }
}