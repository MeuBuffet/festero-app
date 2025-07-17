namespace MeuBuffet.Application.UseCases.LoginUser
{
    public interface ILoginUserHandler
    {
        Task<string> HandleAsync(LoginUserCommand command);
    }
}