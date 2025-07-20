using FesteroApp.Users.Application.UseCases.CreateUser;
using FesteroApp.Users.Application.UseCases.DetailUser;
using FesteroApp.Users.Application.UseCases.LoginUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FesteroApp.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ILogger<UserController> logger, ICreateUserHandler createHandler, IGetUserByIdHandler getByIdHandler, ILoginUserHandler loginHandler) : BaseController, IDisposable
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly ICreateUserHandler _createHandler = createHandler;
        private readonly IGetUserByIdHandler _getByIdHandler = getByIdHandler;
        private readonly ILoginUserHandler _loginHandler = loginHandler;

        /// <summary>
        /// Obt�m um usuario por ID.
        /// </summary>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailQueryResult>> GetById(Guid id)
        {
            var user = await _getByIdHandler.HandleAsync(id);

            if (user is null)
                return NotFound(new { Message = $"Usu�rio com ID {id} n�o foi encontrado." });

            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuario.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = await _createHandler.HandleAsync(command);

            return CreatedAtAction(nameof(Create), new { id = userId }, null);
        }

        /// <summary>
        /// Logar usuário.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loginHandler.HandleAsync(command);

            if (string.IsNullOrEmpty(result) || string.IsNullOrWhiteSpace(result))
                return Unauthorized(new { Message = "Usuário e/ou senha inválidos." });

            return Ok(result);
        }
    }
}