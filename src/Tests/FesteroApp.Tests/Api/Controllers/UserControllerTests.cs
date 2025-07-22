// using FesteroApp.Api.Controllers;
// using FesteroApp.Application.UseCases.CreateUser;
// using FesteroApp.Application.UseCases.DetailUser;
// using FesteroApp.Application.UseCases.LoginUser;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using Moq;
//
// namespace FesteroApp.Tests.Api.Controllers
// {
//     [TestFixture]
//     public class UserControllerTests
//     {
//         private Mock<ILogger<UserController>> _loggerMock;
//         private Mock<ICreateUserHandler> _createHandlerMock;
//         private Mock<IGetUserByIdHandler> _getByIdHandlerMock;
//         private Mock<ILoginUserHandler> _loginHandlerMock;
//         private UserController _controller;
//
//         [SetUp]
//         public void SetUp()
//         {
//             _loggerMock = new Mock<ILogger<UserController>>();
//             _createHandlerMock = new Mock<ICreateUserHandler>();
//             _getByIdHandlerMock = new Mock<IGetUserByIdHandler>();
//             _loginHandlerMock = new Mock<ILoginUserHandler>();
//
//             _controller = new UserController(_loggerMock.Object, _createHandlerMock.Object, _getByIdHandlerMock.Object, _loginHandlerMock.Object);
//         }
//
//         [TearDown]
//         public void TearDown()
//         {
//             _controller?.Dispose();
//         }
//
//         /// <summary>
//         /// Deve retornar NotFound quando o usuário não for encontrado.
//         /// </summary>
//         [Test]
//         public async Task GetById_UserNotFound_ReturnsNotFound()
//         {
//             var userId = Guid.NewGuid();
//
//             _getByIdHandlerMock.Setup(x => x.HandleAsync(userId)).ReturnsAsync((UserDetailQueryResult)null!);
//
//             var result = await _controller.GetById(userId);
//
//             Assert.That(result.Result, Is.InstanceOf<NotFoundObjectResult>());
//         }
//
//         /// <summary>
//         /// Deve retornar OK quando o usuário for encontrado.
//         /// </summary>
//         [Test]
//         public async Task GetById_UserFound_ReturnsOk()
//         {
//             var userId = Guid.NewGuid();
//             var expectedUser = new UserDetailQueryResult(userId, "João", "joao@festeroapp.com");
//
//             _getByIdHandlerMock.Setup(x => x.HandleAsync(userId)).ReturnsAsync(expectedUser);
//
//             var result = await _controller.GetById(userId);
//             var okResult = result.Result as OkObjectResult;
//
//             Assert.That(okResult, Is.Not.Null);
//             Assert.That(okResult.Value, Is.EqualTo(expectedUser));
//         }
//
//         /// <summary>
//         /// Deve retornar BadRequest quando o ModelState for inválido.
//         /// </summary>
//         [Test]
//         public async Task Create_InvalidModelState_ReturnsBadRequest()
//         {
//             _controller.ModelState.AddModelError("Name", "Nome é obrigatório.");
//
//             var command = new CreateUserCommand();
//             var result = await _controller.Create(command);
//
//             Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
//         }
//
//         /// <summary>
//         /// Deve criar um novo usuário com sucesso.
//         /// </summary>
//         [Test]
//         public async Task Create_ValidModel_ReturnsCreatedAtAction()
//         {
//             var userId = Guid.NewGuid();
//             var command = new CreateUserCommand { Name = "Maria" };
//
//             _createHandlerMock
//                 .Setup(x => x.HandleAsync(command))
//                 .ReturnsAsync(userId);
//
//             var result = await _controller.Create(command);
//             var createdResult = result as CreatedAtActionResult;
//
//             Assert.That(createdResult, Is.Not.Null);
//             Assert.Multiple(() =>
//             {
//                 Assert.That(createdResult.ActionName, Is.EqualTo(nameof(UserController.Create)));
//                 Assert.That(createdResult.RouteValues!["id"], Is.EqualTo(userId));
//             });
//         }
//
//         /// <summary>
//         /// Deve retornar BadRequest se o modelo for inválido.
//         /// </summary>
//         [Test]
//         public async Task Login_InvalidModel_ReturnsBadRequest()
//         {
//             _controller.ModelState.AddModelError("Email", "Campo obrigatório");
//
//             var command = new LoginUserCommand { Email = "", Password = "" };
//             var result = await _controller.Login(command);
//
//             Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
//         }
//
//         /// <summary>
//         /// Deve retornar Unauthorized se as credenciais forem inválidas.
//         /// </summary>
//         [TestCase(null)]
//         [TestCase("")]
//         [TestCase(" ")]
//         public async Task Login_InvalidCredentials_ReturnsUnauthorized(string? resultFromHandler)
//         {
//             var command = new LoginUserCommand { Email = "x@x.com", Password = "12345deD" };
//
//             _loginHandlerMock
//                 .Setup(x => x.HandleAsync(command))
//                 .ReturnsAsync(resultFromHandler!);
//
//             var result = await _controller.Login(command);
//             var unauthorized = result as UnauthorizedObjectResult;
//
//             Assert.That(unauthorized, Is.Not.Null);
//             Assert.That(unauthorized.StatusCode, Is.EqualTo(401));
//         }
//
//         /// <summary>
//         /// Deve retornar Ok com token válido se o login for bem-sucedido.
//         /// </summary>
//         [Test]
//         public async Task Login_ValidCredentials_ReturnsOkWithToken()
//         {
//             var token = "jwt-token-valido";
//             var command = new LoginUserCommand { Email = "admin@admin.com", Password = "1234AFaas56" };
//
//             _loginHandlerMock
//                 .Setup(x => x.HandleAsync(command))
//                 .ReturnsAsync(token);
//
//             var result = await _controller.Login(command);
//
//             var ok = result as OkObjectResult;
//
//             Assert.That(ok, Is.Not.Null);
//             dynamic body = ok!.Value!;
//             Assert.AreEqual(token, body);
//         }
//     }
// }