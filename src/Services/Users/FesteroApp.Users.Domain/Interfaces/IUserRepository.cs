using FesteroApp.Users.Domain.Entities.Users;
using SrShut.Data;

namespace FesteroApp.Users.Domain.Interfaces;

public interface IUserRepository: IRepository<User>
{
    Task<bool> IsCredentialsValid(string email, string? password);
    
    Task<bool> HasUserByEmail(string email);

    Task<User> GetAsyncByEmail(string email);
}