using Microsoft.AspNetCore.Authorization;

namespace FesteroApp.Api.Authorization.Requirements;

public class RoleInTenantRequirement : IAuthorizationRequirement
{
    public string[] AllowedRoles { get; }

    public RoleInTenantRequirement(params string[] allowedRoles)
    {
        AllowedRoles = allowedRoles;
    }
}