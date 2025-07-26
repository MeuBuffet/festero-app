using FesteroApp.Domain.Entities.Users;

namespace FesteroApp.Domain.Securities;

public interface ITokenGenerator
{
    string Generate(User user, List<UserOrganization> companies);
}