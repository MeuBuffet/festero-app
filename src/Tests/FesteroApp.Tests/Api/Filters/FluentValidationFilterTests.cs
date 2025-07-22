using FesteroApp.Api.Filters;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Moq;

namespace FesteroApp.Tests.Api.Filters;

public class DummyRequest
{
    public string? Name { get; set; }
}

public class DummyRequestValidator : AbstractValidator<DummyRequest>
{
    public DummyRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}

public class FluentValidationFilterTests
{
    [Test]
    public async Task Should_Return_BadRequest_When_Model_Is_Invalid()
    {
        var serviceProvider = new Mock<IServiceProvider>();
        serviceProvider.Setup(x => x.GetService(typeof(IValidator<DummyRequest>)))
            .Returns(new DummyRequestValidator());

        var filter = new FluentValidationFilter(serviceProvider.Object);

        var context = new ActionExecutingContext(
            new ActionContext(new DefaultHttpContext(), new(), new(), new()),
            [],
            new Dictionary<string, object?> { { "model", new DummyRequest() } },
            controller: null!
        );

        var executed = false;
        var executionDelegate = new ActionExecutionDelegate(() =>
        {
            executed = true;
            var ctx = new ActionExecutedContext(context, [], null!);
            return Task.FromResult(ctx);
        });

        await filter.OnActionExecutionAsync(context, executionDelegate);

        Assert.That(context.Result, Is.Not.Null);
        Assert.That(context.Result, Is.TypeOf<JsonResult>());
        Assert.That(executed, Is.False);
    }
}