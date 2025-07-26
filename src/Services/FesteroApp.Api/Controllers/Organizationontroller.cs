using FesteroApp.Application.UseCases.Organizations.CreateOrganization;
using FesteroApp.Application.UseCases.Organizations.DeleteOrganization;
using FesteroApp.Application.UseCases.Organizations.GetOrganization;
using FesteroApp.Application.UseCases.Organizations.GetUserByOrganization;
using FesteroApp.Application.UseCases.Organizations.InviteUserOrganization;
using FesteroApp.Application.UseCases.Organizations.UpdateOrganization;
using FesteroApp.Application.UseCases.Organizations.UpdateOrganizationConfiguration;
using Microsoft.AspNetCore.Mvc;
using SrShut.Cqrs.Commands;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Api.Controllers;

[ApiController]
[Route("api/organizations")]
public class Organizationontroller(ILogger<Organizationontroller> logger, ICommandBus commandBus, IRequestBus requestBus)
    : BaseController
{
    private readonly ILogger<Organizationontroller> _logger = logger;
    private readonly ICommandBus _commandBus = commandBus;
    private readonly IRequestBus _requestBus = requestBus;

    [HttpGet]
    public async Task<GetOrganizationQueryResult> Get([FromQuery] GetOrganizationQuery query)
    {
        return await _requestBus.RequestAsync<GetOrganizationQuery, GetOrganizationQueryResult>(query);
    }
    
    [HttpGet("{id}/users")]
    public async Task<GetUserByOrganizationQueryResult> GetUsers(Guid id, [FromQuery] GetUserByOrganizationQuery query)
    {
        return await _requestBus.RequestAsync<GetUserByOrganizationQuery, GetUserByOrganizationQueryResult>(new  GetUserByOrganizationQuery(id, query.Text));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrganizationCommand command)
    {
        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
    
    [HttpPost("{id}/invite")]
    public async Task<IActionResult> Invite(Guid id, [FromBody] InviteUserOrganizationCommand command)
    {
        command.Id = id;
        
        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrganizationCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
    
    [HttpPatch("{id}/configurations")]
    public async Task<IActionResult> UpdateConfiguration(Guid id, [FromBody] UpdateOrganizationConfigurationCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteOrganizationCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
}