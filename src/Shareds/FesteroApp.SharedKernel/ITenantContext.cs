namespace FesteroApp.SharedKernel;

public interface ITenantContext
{
    Guid? CurrentTenantId { get; set; }
    
    List<Guid> AccessibleTenantIds { get; set; }
    
    string? RoleInCurrentTenant { get; set; } 
}