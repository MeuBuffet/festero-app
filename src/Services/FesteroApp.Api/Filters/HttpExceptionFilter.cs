using FesteroApp.SharedKernel.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FesteroApp.Api.Filters;

public class HttpExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not HttpException httpEx) return;
            
        context.ExceptionHandled = true;

        context.Result = new ObjectResult(httpEx.Message)
        {
            StatusCode = (int)httpEx.StatusCode
        };
    }
}