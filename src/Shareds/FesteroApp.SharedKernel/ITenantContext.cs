namespace FesteroApp.SharedKernel;

public interface ITenantContext
{
    string TenantId { get; set; }
}