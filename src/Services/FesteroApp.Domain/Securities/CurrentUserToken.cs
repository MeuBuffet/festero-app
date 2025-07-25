namespace FesteroApp.Domain.Securities;

public class CurrentUserToken
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    
    public string Email { get; set; } = default!;
    
    public string Token { get; set; } = default!;
    
    public DateTime ExpireIn { get; set; }
    
    public List<string> Roles { get; set; } = new();
}