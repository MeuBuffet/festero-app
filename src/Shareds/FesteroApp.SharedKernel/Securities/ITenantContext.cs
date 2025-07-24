namespace FesteroApp.SharedKernel.Securities;

public interface ITenantContext
{
    Guid? CurrentTenantId { get; set; }
    
    List<Guid> AccessibleTenantIds { get; set; }
    
    string? RoleInCurrentTenant { get; set; } 
}