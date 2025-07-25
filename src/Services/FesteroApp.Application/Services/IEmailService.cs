namespace FesteroApp.Application.Services;

public interface IEmailService
{
    Task Send(string email, string password, string name);
}