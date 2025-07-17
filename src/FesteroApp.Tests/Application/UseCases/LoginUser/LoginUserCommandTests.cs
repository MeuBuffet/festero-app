using FesteroApp.Application.UseCases.LoginUser;
using System.ComponentModel.DataAnnotations;

namespace FesteroApp.Tests.Application.UseCases.LoginUser
{
    [TestFixture]
    public class LoginUserCommandTests
    {
        private List<ValidationResult> _results = null!;

        private bool IsValid(LoginUserCommand command)
        {
            var context = new ValidationContext(command);
            _results = [];

            return Validator.TryValidateObject(command, context, _results, true);
        }

        [Test]
        public void Should_Be_Invalid_When_Email_Is_Empty()
        {
            var command = new LoginUserCommand
            {
                Email = "",
                Password = "Senha123!"
            };

            var isValid = IsValid(command);

            Assert.Multiple(() =>
            {
                Assert.That(isValid, Is.False);
                Assert.That(_results.Exists(r => r.MemberNames.Contains("Email")));
            });
        }

        [Test]
        public void Should_Be_Invalid_When_Email_Is_Malformed()
        {
            var command = new LoginUserCommand
            {
                Email = "invalido-email",
                Password = "Senha123!"
            };

            var isValid = IsValid(command);

            Assert.Multiple(() =>
            {
                Assert.That(isValid, Is.False);
                Assert.That(_results.Exists(r => r.MemberNames.Contains("Email")));
            });
        }

        [Test]
        public void Should_Be_Invalid_When_Password_Is_Empty()
        {
            var command = new LoginUserCommand
            {
                Email = "teste@email.com",
                Password = ""
            };

            var isValid = IsValid(command);

            Assert.Multiple(() =>
            {
                Assert.That(isValid, Is.False);
                Assert.That(_results.Exists(r => r.MemberNames.Contains("Password")));
            });
        }

        [Test]
        public void Should_Be_Valid_When_All_Fields_Are_Correct()
        {
            var command = new LoginUserCommand
            {
                Email = "valido@email.com",
                Password = "Senha123!"
            };

            var isValid = IsValid(command);

            Assert.Multiple(() =>
            {
                Assert.That(isValid, Is.True);
                Assert.That(_results, Is.Empty);
            });
        }
    }
}
