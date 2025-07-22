using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SrShut.Common.Exceptions;
using HttpException = FesteroApp.SharedKernel.Exceptions.HttpException;

namespace FesteroApp.Api.Controllers;

public abstract class BaseController : Controller
{
    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception == null)
            return;

        var ex = context.Exception;
        context.ExceptionHandled = true;

        var (statusCode, message) = ex switch
        {
            HttpException httpEx => ((int)httpEx.StatusCode, httpEx.Message),
            BusinessException business => (422, business.Message),
            ArgumentNullException argNull => (400, argNull.Message),
            ArgumentException arg => (400, arg.Message),
            UnauthorizedAccessException => (401, "Acesso não autorizado."),
            KeyNotFoundException => (404, "Recurso não encontrado."),
            NotImplementedException => (501, "Funcionalidade não implementada."),
            _ => (500, "Ocorreu um erro inesperado. Tente novamente.")
        };

        context.Result = new ObjectResult(new
        {
            Error = message,
            Exception = ex.GetType().Name
        })
        {
            StatusCode = statusCode
        };
    }
}