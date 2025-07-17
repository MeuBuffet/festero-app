using FesteroApp.Application.UseCases.CreateUser;
using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces;
using Moq;

namespace FesteroApp.Tests.Application.UseCases.CreateUser
{
    [TestFixture]
    public class CreateUserHandlerTests
    {
        private Mock<IRepository<User>> _repositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private CreateUserHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IRepository<User>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new CreateUserHandler(_repositoryMock.Object, _unitOfWorkMock.Object);
        }

        /// <summary>
        /// Deve criar o usuário e retornar o ID gerado.
        /// </summary>
        [Test]
        public async Task HandleAsync_ShouldCreateUserAndReturnId()
        {
            var command = new CreateUserCommand
            {
                Name = "Maria",
                Email = "maria@email.com",
                Password = "Senha123!"
            };

            User? userSaved = null;

            _repositoryMock
                .Setup(repo => repo.AddAndCommitAsync(It.IsAny<User>()))
                .Callback<User>(u => userSaved = u)
                .Returns(Task.CompletedTask);

            var resultId = await _handler.HandleAsync(command);

            Assert.That(userSaved, Is.Not.Null);
            Assert.That(userSaved!.Name, Is.EqualTo(command.Name));
            Assert.That(userSaved.Email, Is.EqualTo(command.Email));
            Assert.That(userSaved.Password, Is.EqualTo(command.Password));
            Assert.That(resultId, Is.EqualTo(userSaved.Id));

            _repositoryMock.Verify(x => x.AddAndCommitAsync(It.IsAny<User>()), Times.Once);
        }
    }
}