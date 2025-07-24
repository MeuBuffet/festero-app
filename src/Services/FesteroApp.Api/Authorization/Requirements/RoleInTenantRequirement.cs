using Microsoft.AspNetCore.Authorization;

namespace FesteroApp.Api.Authorization.Requirements;

public class RoleInTenantRequirement(params string[] allowedRoles) : IAuthorizationRequirement
{
    public string[] AllowedRoles { get; } = allowedRoles;
}