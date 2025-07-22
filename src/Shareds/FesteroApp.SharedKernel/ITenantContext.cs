namespace FesteroApp.Api.Middlewares;

public interface ITenantContext
{
    string TenantId { get; set; }
}