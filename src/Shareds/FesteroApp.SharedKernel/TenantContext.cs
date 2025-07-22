using FesteroApp.Api.Middlewares;

namespace FesteroApp.SharedKernel;

public class TenantContext : ITenantContext
{
    public string TenantId { get; set; }
}