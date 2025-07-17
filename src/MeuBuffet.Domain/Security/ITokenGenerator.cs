using MeuBuffet.Domain.Entities.Users;

namespace MeuBuffet.Domain.Security
{
    public interface ITokenGenerator
    {
        string Generate(User user);
    }
}