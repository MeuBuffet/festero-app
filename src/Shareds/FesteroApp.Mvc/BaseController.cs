using FesteroApp.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FesteroApp.Mvc
{
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is not HttpException httpEx) return;
            
            context.ExceptionHandled = true;
            context.Result = StatusCode((int)httpEx.StatusCode, httpEx.Message);
        }
    }
}
