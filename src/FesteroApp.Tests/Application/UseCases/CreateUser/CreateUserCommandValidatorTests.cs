using FesteroApp.Application.UseCases.CreateUser;
using FluentValidation.TestHelper;

namespace FesteroApp.Tests.Application.UseCases.CreateUser
{
    [TestFixture]
    public class CreateUserCommandValidatorTests
    {
        private CreateUserCommandValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new CreateUserCommandValidator();
        }

        [Test]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var model = new CreateUserCommand { Name = "" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            var model = new CreateUserCommand { Email = "emailsemarroba" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Test]
        public void Should_Have_Error_When_Password_Is_Too_Short()
        {
            var model = new CreateUserCommand { Password = "Ab1@" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Test]
        public void Should_Have_Error_When_Password_Missing_Majuscule()
        {
            var model = new CreateUserCommand { Password = "ab1@senha" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Test]
        public void Should_Have_Error_When_Password_Missing_Number()
        {
            var model = new CreateUserCommand { Password = "Abcdef@!" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Test]
        public void Should_Have_Error_When_Password_Missing_Special()
        {
            var model = new CreateUserCommand { Password = "Abcdef12" };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Password);
        }

        [Test]
        public void Should_Pass_When_All_Fields_Valid()
        {
            var model = new CreateUserCommand
            {
                Name = "João da Silva",
                Email = "joao@teste.com",
                Password = "Senha123!"
            };

            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}