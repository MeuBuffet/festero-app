using System.ComponentModel.DataAnnotations;
using FesteroApp.Users.Application.UseCases.CreateUser;

namespace FesteroApp.Tests.Application.UseCases.CreateUser
{
    [TestFixture]
    public class CreateUserCommandTests
    {
        private List<ValidationResult>? _validationResults;

        private bool IsValid(CreateUserCommand command)
        {
            var context = new ValidationContext(command, null, null);

            _validationResults = [];

            return Validator.TryValidateObject(command, context, _validationResults, true);
        }

        /// <summary>
        /// Deve ser inválido quando todos os campos estiverem vazios.
        /// </summary>
        [Test]
        public void CreateUserCommand_Invalid_AllFieldsEmpty()
        {
            var command = new CreateUserCommand();
            var result = IsValid(command);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False);
                Assert.That(_validationResults?.Count, Is.EqualTo(3));
            });
        }

        /// <summary>
        /// Deve ser inválido quando o e-mail estiver em formato incorreto.
        /// </summary>
        [Test]
        public void CreateUserCommand_Invalid_EmailFormat()
        {
            var command = new CreateUserCommand
            {
                Name = "João",
                Email = "joao-email-sem-arroba",
                Password = "123456"
            };

            var result = IsValid(command);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False);
                Assert.That(_validationResults!.Exists(x => x.MemberNames.Contains("Email")));
            });
        }

        /// <summary>
        /// Deve ser válido com todos os campos corretos.
        /// </summary>
        [Test]
        public void CreateUserCommand_Valid()
        {
            var command = new CreateUserCommand
            {
                Name = "Maria",
                Email = "maria@email.com",
                Password = "123456"
            };

            var result = IsValid(command);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(_validationResults, Is.Empty);
            });
        }
    }
}