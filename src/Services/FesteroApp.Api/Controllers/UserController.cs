using FesteroApp.Application.UseCases.Users.CreateUser;
using FesteroApp.Application.UseCases.Users.DeleteUser;
using FesteroApp.Application.UseCases.Users.GetUser;
using FesteroApp.Application.UseCases.Users.LoginUser;
using FesteroApp.Application.UseCases.Users.UpdateUser;
using FesteroApp.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SrShut.Cqrs.Commands;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(ILogger<UserController> logger, ICommandBus commandBus, IRequestBus requestBus)
    : BaseController
{
    private readonly ILogger<UserController> _logger = logger;
    private readonly ICommandBus _commandBus = commandBus;
    private readonly IRequestBus _requestBus = requestBus;

    [Authorize(Policy = "All")]
    [HttpGet]
    public async Task<GetUserQueryResult> Get([FromQuery] GetUserQuery query)
    {
        return await _requestBus.RequestAsync<GetUserQuery, GetUserQueryResult>(query);
    }

    [Authorize(Policy = "All")]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromForm] LoginUserCommand command)
    {
        await _commandBus.SendAsync(command);

        if (string.IsNullOrEmpty(command.Token) || string.IsNullOrWhiteSpace(command.Token))
            return Unauthorized(new { Message = "Usuário e/ou senha inválidos." });

        return Ok(new { command = command.Token });
    }

    [Authorize(Policy = "ManagerOrAbove")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }

    [Authorize(Policy = "CollaboratorOrAbove")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
    
    [Authorize(Policy = "ManagerOrAbove")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteUserCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
}