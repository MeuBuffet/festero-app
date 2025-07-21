using FesteroApp.Mvc;
using FesteroApp.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FesteroApp.Companies.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController(ILogger<CompanyController> logger) : BaseController, IDisposable
    {
        private readonly ILogger<CompanyController> _logger = logger;

        
    }
}