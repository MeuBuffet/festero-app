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
        /// Obt�m um usu�rio por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailQueryResult>> GetById(Guid id)
        {
            var user = await _getByIdHandler.HandleAsync(id);

            if (user is null)
                return NotFound(new { Message = $"Usu�rio com ID {id} n�o foi encontrado." });

            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usu�rio.
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
        /// Cria um novo usu�rio.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _loginHandler.HandleAsync(command);

            if (string.IsNullOrEmpty(result))
                return Unauthorized(new { Message = "Usu�rio e/ou senha inv�lidos." });

            return Ok(result);
        }
    }
}