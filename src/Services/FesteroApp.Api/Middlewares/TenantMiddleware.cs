namespace FesteroApp.Api.Middlewares;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context, ITenantContext tenantContext)
    {
        var tenantId = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();
        if (string.IsNullOrEmpty(tenantId))
            throw new UnauthorizedAccessException("TenantId is missing");

        tenantContext.TenantId = tenantId;

        await _next(context);
    }
}