using System.Text.Json;
using FesteroApp.Domain.Securities;
using FesteroApp.SharedKernel.Securities;

namespace FesteroApp.Api.Middlewares;

public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, ITenantContext tenantContext)
    {
        var user = context.User;

        if (user.Identity?.IsAuthenticated != true)
        {
            await _next(context);
            return;
        }

        var resourcesClaim = user.FindFirst("resources")?.Value;
        
        if (string.IsNullOrWhiteSpace(resourcesClaim))
            throw new UnauthorizedAccessException("Permissões do usuário não encontradas.");

        List<ResourcesAccess>? resources;
        try
        {
            resources = JsonSerializer.Deserialize<List<ResourcesAccess>>(resourcesClaim);
        }
        catch
        {
            throw new UnauthorizedAccessException("Não foi possível interpretar as permissões do usuário.");
        }

        if (resources is null || !resources.Any())
            throw new UnauthorizedAccessException("Nenhum tenant disponível para este usuário.");

        var tenantIds = resources.Select(r => r.TenantId).Distinct().ToList();
        tenantContext.AccessibleTenantIds = tenantIds;

        var tenantIdFromHeader = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();

        if (string.IsNullOrWhiteSpace(tenantIdFromHeader))
        {
            tenantContext.CurrentTenantId = tenantIds.First();
        }
        else if (Guid.TryParse(tenantIdFromHeader, out var currentTenantId))
        {
            if (!tenantIds.Contains(currentTenantId))
                throw new UnauthorizedAccessException("Usuário não tem acesso ao tenant especificado.");

            tenantContext.CurrentTenantId = currentTenantId;
        }
        else
        {
            throw new UnauthorizedAccessException("Header X-Tenant-Id inválido.");
        }

        await _next(context);
    }
}