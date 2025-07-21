using FesteroApp.Mvc;
using FesteroApp.SharedKernel;
using FesteroApp.Users.Application.UseCases.CreateUser;
using FesteroApp.Users.Application.UseCases.DetailUser;
using FesteroApp.Users.Application.UseCases.LoginUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SrShut.Cqrs.Commands;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ILogger<UserController> logger, ICommandBus commandBus, IRequestBus requestBus)
        : BaseController
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly ICommandBus _commandBus = commandBus;
        private readonly IRequestBus _requestBus = requestBus;

        // /// <summary>
        // /// Obt�m um usuario por ID.
        // /// </summary>
        // [Authorize]
        // [HttpGet("{id}")]
        // public async Task<ActionResult<UserDetailQueryResult>> GetById(Guid id)
        // {
        //     var user = await _getByIdHandler.HandleAsync(id);
        //
        //     if (user is null)
        //         return NotFound(new { Message = $"Usu�rio com ID {id} n�o foi encontrado." });
        //
        //     return Ok(user);
        // }

        /// <summary>
        /// Cria um novo usuario.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateUserCommand command)
        {
            await _commandBus.SendAsync(command);

            return Ok(new { command.Id });
        }

        /// <summary>
        /// Logar usuário.
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUserCommand command)
        {
            await _commandBus.SendAsync(command);

            if (string.IsNullOrEmpty(command.Token) || string.IsNullOrWhiteSpace(command.Token))
                return Unauthorized(new { Message = "Usuário e/ou senha inválidos." });

            return Ok(new { command = command.Token });
        }
    }
}