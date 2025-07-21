using FesteroApp.Users.Domain.Entities.Users;

namespace FesteroApp.Users.Domain.Security
{
    public interface ITokenGenerator
    {
        string Generate(User company);
    }
}