using Moq;
using System.Linq.Expressions;
using FesteroApp.Users.Application.UseCases.LoginUser;
using FesteroApp.Users.Domain.Entities.Users;
using FesteroApp.Users.Domain.Interfaces;
using FesteroApp.Users.Domain.Security;

namespace FesteroApp.Tests.Application.UseCases.LoginUser
{
    [TestFixture]
    public class LoginUserHandlerTests
    {
        private Mock<IRepository<User>> _repositoryMock = null!;
        private Mock<IUnitOfWork> _unitOfWorkMock = null!;
        private Mock<ITokenGenerator> _tokenGeneratorMock = null!;
        private LoginUserHandler _handler = null!;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<User>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _tokenGeneratorMock = new Mock<ITokenGenerator>();

            _handler = new LoginUserHandler(
                _repositoryMock.Object,
                _unitOfWorkMock.Object,
                _tokenGeneratorMock.Object
            );
        }

        [Test]
        public async Task HandleAsync_InvalidCredentials_ReturnsEmptyString()
        {
            var command = new LoginUserCommand { Email = "fail@test.com", Password = "wrongpass" };

            _repositoryMock
                .Setup(r => r.GetByAsync<User>(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync((User?)null);

            var result = await _handler.HandleAsync(command);

            Assert.That(result, Is.EqualTo(string.Empty));

            _tokenGeneratorMock.Verify(t => t.Generate(It.IsAny<User>()), Times.Never);
        }

        [Test]
        public async Task HandleAsync_ValidCredentials_ReturnsToken()
        {
            var command = new LoginUserCommand { Email = "user@test.com", Password = "Senha123!" };
            var user = new User(Guid.NewGuid(), command.Email, command.Email, command.Password);
            var expectedToken = "jwt-token-gerado";

            _repositoryMock
                .Setup(r => r.GetByAsync<User>(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(user);

            _tokenGeneratorMock
                .Setup(t => t.Generate(user))
                .Returns(expectedToken);

            var result = await _handler.HandleAsync(command);

            Assert.That(result, Is.EqualTo(expectedToken));

            _tokenGeneratorMock.Verify(t => t.Generate(user), Times.Once);
        }
    }
}
