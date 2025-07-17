using MeuBuffet.Api.Controllers;
using MeuBuffet.Application.UseCases.CreateUser;
using MeuBuffet.Application.UseCases.DetailUser;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace MeuBuffet.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTests
    {
        private Mock<ILogger<UserController>> _loggerMock;
        private Mock<ICreateUserHandler> _createUserHandlerMock;
        private Mock<IGetUserByIdHandler> _getUserByIdHandlerMock;
        private UserController _controller;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<UserController>>();
            _createUserHandlerMock = new Mock<ICreateUserHandler>();
            _getUserByIdHandlerMock = new Mock<IGetUserByIdHandler>();

            _controller = new UserController(_loggerMock.Object, _createUserHandlerMock.Object, _getUserByIdHandlerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _controller?.Dispose();
        }

        /// <summary>
        /// Deve retornar NotFound quando o usuário não for encontrado.
        /// </summary>
        [Test]
        public async Task GetById_UserNotFound_ReturnsNotFound()
        {
            var userId = Guid.NewGuid();

            _getUserByIdHandlerMock.Setup(x => x.HandleAsync(userId)).ReturnsAsync((UserDetailQueryResult)null!);

            var result = await _controller.GetById(userId);

            Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
        }

        /// <summary>
        /// Deve retornar OK quando o usuário for encontrado.
        /// </summary>
        [Test]
        public async Task GetById_UserFound_ReturnsOk()
        {
            var userId = Guid.NewGuid();
            var expectedUser = new UserDetailQueryResult(userId, "João", "joao@meubuffet.com");

            _getUserByIdHandlerMock.Setup(x => x.HandleAsync(userId)).ReturnsAsync(expectedUser);

            var result = await _controller.GetById(userId);
            var okResult = result.Result as OkObjectResult;

            Assert.That(okResult, Is.Not.Null);
            Assert.That(okResult.Value, Is.EqualTo(expectedUser));
        }

        /// <summary>
        /// Deve retornar BadRequest quando o ModelState for inválido.
        /// </summary>
        [Test]
        public async Task Create_InvalidModelState_ReturnsBadRequest()
        {
            _controller.ModelState.AddModelError("Name", "Nome é obrigatório.");

            var command = new CreateUserCommand();
            var result = await _controller.Create(command);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        }

        /// <summary>
        /// Deve criar um novo usuário com sucesso.
        /// </summary>
        [Test]
        public async Task Create_ValidModel_ReturnsCreatedAtAction()
        {
            var userId = Guid.NewGuid();
            var command = new CreateUserCommand { Name = "Maria" };

            _createUserHandlerMock
                .Setup(x => x.HandleAsync(command))
                .ReturnsAsync(userId);

            var result = await _controller.Create(command);
            var createdResult = result as CreatedAtActionResult;

            Assert.That(createdResult, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createdResult.ActionName, Is.EqualTo(nameof(UserController.GetById)));
                Assert.That(createdResult.RouteValues!["id"], Is.EqualTo(userId));
            });
        }
    }
}