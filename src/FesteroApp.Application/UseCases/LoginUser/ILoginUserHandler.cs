namespace FesteroApp.Application.UseCases.LoginUser
{
    public interface ILoginUserHandler
    {
        Task<string> HandleAsync(LoginUserCommand command);
    }
}