
using FesteroApp.Application.UseCases.DetailUser;
using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces;
using Moq;

namespace FesteroApp.Tests.Application.UseCases.DetailUser
{
    [TestFixture]
    public class GetUserByIdHandlerTests
    {
        private Mock<IRepository<User>> _repositoryMock = null!;
        private GetUserByIdHandler _handler = null!;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IRepository<User>>();
            _handler = new GetUserByIdHandler(_repositoryMock.Object);
        }

        /// <summary>
        /// Deve retornar null se o usuário não for encontrado.
        /// </summary>
        [Test]
        public async Task HandleAsync_UserNotFound_ReturnsNull()
        {
            var userId = Guid.NewGuid();
            _repositoryMock.Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync((User?)null);

            var result = await _handler.HandleAsync(userId);

            Assert.That(result, Is.Null);
        }

        /// <summary>
        /// Deve retornar os dados do usuário se encontrado.
        /// </summary>
        [Test]
        public async Task HandleAsync_UserFound_ReturnsUserDetailQueryResult()
        {
            var userId = Guid.NewGuid();
            var user = new User(userId, "João", "joao@email.com", "Senha123!");

            _repositoryMock.Setup(repo => repo.GetByIdAsync(userId))
                .ReturnsAsync(user);

            var result = await _handler.HandleAsync(userId);

            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result!.Id, Is.EqualTo(userId));
                Assert.That(result.Name, Is.EqualTo(user.Name));
                Assert.That(result.Email, Is.EqualTo(user.Email));
            });
        }

        /// <summary>
        /// Deve chamar o repositório corretamente.
        /// </summary>
        [Test]
        public async Task HandleAsync_CallsRepositoryWithCorrectId()
        {
            var userId = Guid.NewGuid();
            _repositoryMock.Setup(r => r.GetByIdAsync(userId)).ReturnsAsync((User?)null);

            await _handler.HandleAsync(userId);

            _repositoryMock.Verify(r => r.GetByIdAsync(userId), Times.Once);
        }
    }
}
