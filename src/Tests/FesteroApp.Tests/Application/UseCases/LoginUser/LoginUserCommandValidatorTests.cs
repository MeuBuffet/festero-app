using FesteroApp.Application.UseCases.Users.LoginUser;
using FluentValidation.TestHelper;

namespace FesteroApp.Tests.Application.UseCases.LoginUser;

[TestFixture]
public class LoginUserCommandValidatorTests
{
    private LoginUserCommandValidator _validator = null!;

    [SetUp]
    public void Setup()
    {
        _validator = new LoginUserCommandValidator();
    }

    [Test]
    public void Should_Have_Error_When_Email_Is_Empty()
    {
        var model = new LoginUserCommand { Email = "", Password = "Senha123!" };
        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        var model = new LoginUserCommand { Email = "semarroba", Password = "Senha123!" };
        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Test]
    public void Should_Have_Error_When_Password_Is_Empty()
    {
        var model = new LoginUserCommand { Email = "valido@email.com", Password = "" };
        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Password);
    }

    [Test]
    public void Should_Not_Have_Errors_When_Valid()
    {
        var model = new LoginUserCommand
        {
            Email = "valido@email.com",
            Password = "Senha123!"
        };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}