using MeuBuffet.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MeuBuffet.Api.Controllers
{
    /// <summary>
    /// Controller base para centralizar lógica comum, como tratamento de exceções.
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Executado após a ação ser invocada.
        /// Trata exceções como HttpException centralmente.
        /// </summary>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpException httpEx)
            {
                context.ExceptionHandled = true;
                context.Result = StatusCode((int)httpEx.StatusCode, httpEx.Message);
            }
        }
    }
}
