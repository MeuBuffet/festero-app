using FesteroApp.Domain.Entities.Users;
using SrShut.Data;

namespace FesteroApp.Domain.Interfaces.Users;

public interface IUserRepository: IRepository<User>
{
    Task<bool> IsCredentialsValid(string email, string? password);
    
    Task<bool> HasUserByEmail(string email);

    Task<User> GetAsyncByEmail(string email);
    Task<bool> HasUserByDocument(string document);
}