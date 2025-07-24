namespace FesteroApp.Domain.Securities;

public class ResourcesAccess
{
    public Guid TenantId { get; set; }
    
    public string Role { get; set; } = string.Empty;
}