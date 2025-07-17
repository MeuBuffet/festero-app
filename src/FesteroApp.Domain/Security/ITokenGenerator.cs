using FesteroApp.Domain.Entities.Users;

namespace FesteroApp.Domain.Security
{
    public interface ITokenGenerator
    {
        string Generate(User user);
    }
}