using FesteroApp.SharedKernel.Securities;

namespace FesteroApp.SharedKernel;

public static class ToEnum
{
    public static string Role(RoleTypes role) => role switch
    {
        RoleTypes.OWNER => "OWNER",
        RoleTypes.ADMIN => "ADMIN",
        RoleTypes.COLLABORATOR  => "COLLABORATOR",
        RoleTypes.VIEWER or
        _ => "VIEWER"
    }; 
}