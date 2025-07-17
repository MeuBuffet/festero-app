namespace MeuBuffet.Application.UseCases.CreateUser
{
    public interface ICreateUserHandler
    {
        Task<Guid> HandleAsync(CreateUserCommand command);
    }
}