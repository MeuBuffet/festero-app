using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FesteroApp.Api.Filters
{
    public class FluentValidationFilter(IServiceProvider serviceProvider) : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument == null) continue;

                var validatorType = typeof(IValidator<>).MakeGenericType(argument.GetType());
                var validator = _serviceProvider.GetService(validatorType);

                if (validator is IValidator val)
                {
                    var validationContext = new ValidationContext<object>(argument);
                    var result = await val.ValidateAsync(validationContext);

                    if (!result.IsValid)
                    {
                        var errorDictionary = result.Errors
                            .GroupBy(e => e.PropertyName)
                            .ToDictionary(
                                g => g.Key,
                                g => g.Select(e => e.ErrorMessage).ToArray()
                            );

                        context.Result = new JsonResult(new
                        {
                            errors = errorDictionary
                        })
                        {
                            StatusCode = 400
                        };

                        return;
                    }
                }
            }

            await next();
        }
    }
}