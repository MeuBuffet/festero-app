using FesteroApp.Application.UseCases.Companies.CreateCompany;
using FesteroApp.Application.UseCases.Companies.DeleteCompany;
using FesteroApp.Application.UseCases.Companies.GetCompany;
using FesteroApp.Application.UseCases.Companies.UpdateCompany;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SrShut.Cqrs.Commands;
using SrShut.Cqrs.Requests;

namespace FesteroApp.Api.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController(ILogger<CompanyController> logger, ICommandBus commandBus, IRequestBus requestBus)
    : BaseController
{
    private readonly ILogger<CompanyController> _logger = logger;
    private readonly ICommandBus _commandBus = commandBus;
    private readonly IRequestBus _requestBus = requestBus;

    [Authorize(Policy = "CollaboratorOrAbove")]
    [HttpGet]
    public async Task<GetCompanyQueryResult> Get([FromQuery] GetCompanyQuery query)
    {
        return await _requestBus.RequestAsync<GetCompanyQuery, GetCompanyQueryResult>(query);
    }
    
    [Authorize(Policy = "OwnerOnly")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
    {
        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }

    [Authorize(Policy = "ManagerOrAbove")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompanyCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
    
    [Authorize(Policy = "OwnerOnly")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteCompanyCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
}