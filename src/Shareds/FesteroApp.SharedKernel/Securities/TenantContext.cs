namespace FesteroApp.SharedKernel.Securities;

public class TenantContext : ITenantContext
{
    public Guid? CurrentTenantId { get; set; }

    public List<Guid> AccessibleTenantIds { get; set; } = [];
    
    public string? RoleInCurrentTenant { get; set; }
}