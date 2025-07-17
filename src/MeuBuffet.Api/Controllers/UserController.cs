using MeuBuffet.Application.UseCases.CreateUser;
using MeuBuffet.Application.UseCases.DetailUser;
using MeuBuffet.Application.UseCases.LoginUser;
using Microsoft.AspNetCore.Mvc;

namespace MeuBuffet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(ILogger<UserController> logger, ICreateUserHandler createHandler, IGetUserByIdHandler getByIdHandler, ILoginUserHandler loginHandler) : BaseController, IDisposable
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly ICreateUserHandler _createHandler = createHandler;
        private readonly IGetUserByIdHandler _getByIdHandler = getByIdHandler;
        private readonly ILoginUserHandler _loginHandler = loginHandler;

        /// <summary>
        /// Obtém um usuário por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailQueryResult>> GetById(Guid id)
        {
            var user = await _getByIdHandler.HandleAsync(id);

            if (user is null)
                return NotFound(new { Message = $"Usuário com ID {id} não foi encontrado." });

            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário.
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
        /// Cria um novo usuário.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loginHandler.HandleAsync(command);

            if (string.IsNullOrEmpty(result))
                return Unauthorized(new { Message = "Usuário e/ou senha inválidos." });

            return Ok(result);
        }
    }
}