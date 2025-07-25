using FesteroApp.Application.UseCases.Users.CreateUser;
using FesteroApp.Application.UseCases.Users.DeleteUser;
using FesteroApp.Application.UseCases.Users.GetDetailUser;
using FesteroApp.Application.UseCases.Users.GetUser;
using FesteroApp.Application.UseCases.Users.LoginUser;
using FesteroApp.Application.UseCases.Users.UpdateUser;
using FesteroApp.SharedKernel.Securities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SrShut.Cqrs.Commands;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(ILogger<UserController> logger, ICommandBus commandBus, IRequestBus requestBus, ITenantContext tenantContext)
    : BaseController
{
    private readonly ILogger<UserController> _logger = logger;
    private readonly ICommandBus _commandBus = commandBus;
    private readonly IRequestBus _requestBus = requestBus;
    private readonly ITenantContext _tenantContext = tenantContext;

    [Authorize(Policy = "TenantViewer")]
    [HttpGet]
    public async Task<GetUserQueryResult> Get([FromQuery] GetUserQuery query)
    {
        query.TenantId = _tenantContext.AccessibleTenantIds;
        return await _requestBus.RequestAsync<GetUserQuery, GetUserQueryResult>(query);
    }
    
    [HttpGet("{id}")]
    public async Task<GetDetailUserQueryResult> Get(Guid id, [FromQuery] GetDetailUserQuery query)
    {
        return await _requestBus.RequestAsync<GetDetailUserQuery, GetDetailUserQueryResult>(new GetDetailUserQuery(id, query.Text));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        await _commandBus.SendAsync(command);

        if (string.IsNullOrEmpty(command.Token) || string.IsNullOrWhiteSpace(command.Token))
            return Unauthorized(new { Message = "Usuário e/ou senha inválidos." });

        return Ok(new { command.Token });
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteUserCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
}