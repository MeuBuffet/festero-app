using FesteroApp.SharedKernel;

namespace FesteroApp.Api.Middlewares;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next) => _next = next;

    public async Task Invoke(HttpContext context, ITenantContext tenantContext)
    {
        var user = context.User;
        var rolesRequiringTenant = new[] { $"{Roles.OWNER}, {Roles.ADMIN}, {Roles.COLLABORATOR}, {Roles.VIEWER}" };
        var isTenantRequired = user.Identity?.IsAuthenticated == true
                               && rolesRequiringTenant.Any(role => user.IsInRole(role));

        if (isTenantRequired)
        {
            var tenantId = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();

            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedAccessException("Tenant não encontrado.");

            tenantContext.TenantId = tenantId;
        }

        await _next(context);
    }
}