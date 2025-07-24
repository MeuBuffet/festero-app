using System.Text.Json;
using FesteroApp.Api.Authorization.Requirements;
using FesteroApp.Domain.Securities;
using FesteroApp.SharedKernel;
using FesteroApp.SharedKernel.Securities;
using Microsoft.AspNetCore.Authorization;

namespace FesteroApp.Api.Authorization.Handlers;

public class RoleInTenantRequirementHandler : AuthorizationHandler<RoleInTenantRequirement>
{
    private readonly ITenantContext _tenantContext;

    public RoleInTenantRequirementHandler(ITenantContext tenantContext)
    {
        _tenantContext = tenantContext;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleInTenantRequirement requirement)
    {
        var resourcesClaim = context.User.FindFirst("resources")?.Value;
        
        if (string.IsNullOrWhiteSpace(resourcesClaim)) return Task.CompletedTask;

        var resources = JsonSerializer.Deserialize<List<ResourcesAccess>>(resourcesClaim);
        var tenantId = _tenantContext.CurrentTenantId;

        var match = resources?.FirstOrDefault(r => r.TenantId == tenantId);
        
        if (match != null && requirement.AllowedRoles.Contains(match.Role))
        {
            _tenantContext.RoleInCurrentTenant = match.Role;
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}