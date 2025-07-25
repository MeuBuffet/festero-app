using FesteroApp.Domain.Entities.Users;

namespace FesteroApp.Domain.Securities;

public interface ITokenGenerator
{
    CurrentUserToken Generate(User user, List<UserCompany> companies);
}