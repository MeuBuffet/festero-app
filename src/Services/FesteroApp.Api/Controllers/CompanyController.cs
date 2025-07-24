using FesteroApp.Application.UseCases.Companies.CreateCompany;
using FesteroApp.Application.UseCases.Companies.DeleteCompany;
using FesteroApp.Application.UseCases.Companies.GetCompany;
using FesteroApp.Application.UseCases.Companies.GetUserByCompany;
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

    [HttpGet]
    public async Task<GetCompanyQueryResult> Get([FromQuery] GetCompanyQuery query)
    {
        return await _requestBus.RequestAsync<GetCompanyQuery, GetCompanyQueryResult>(query);
    }
    
    [HttpGet("{id}/users")]
    public async Task<GetUserByCompanyQueryResult> GetUsers(Guid id, [FromQuery] GetUserByCompanyQuery query)
    {
        return await _requestBus.RequestAsync<GetUserByCompanyQuery, GetUserByCompanyQueryResult>(new  GetUserByCompanyQuery(id, query.Text));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command)
    {
        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCompanyCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteCompanyCommand command)
    {
        command.Id = id;

        await _commandBus.SendAsync(command);

        return Ok(new { command.Id });
    }
}