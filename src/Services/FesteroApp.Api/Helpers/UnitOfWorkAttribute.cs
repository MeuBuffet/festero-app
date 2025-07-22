using Microsoft.AspNetCore.Mvc.Filters;
using SrShut.Data;

namespace FesteroApp.Api.Helpers;

public class UnitOfWorkAttribute(IUnitOfWorkFactory uofwFactory) : ActionFilterAttribute
{
    private readonly IUnitOfWorkFactory _uofwFactory = uofwFactory;

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.HttpContext.Items.Add("SessionKey", _uofwFactory.Get());
        base.OnActionExecuting(filterContext);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        try
        {
            var unitOfWork = (IUnitOfWork)context.HttpContext.Items["SessionKey"]!;
            unitOfWork?.Dispose();
        }
        catch
        {
            // Silencia qualquer exceção ao descartar o UnitOfWork.
        }
    }
}
