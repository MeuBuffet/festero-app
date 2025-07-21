using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;
using System.Net;
using FesteroApp.Mvc;
using FesteroApp.SharedKernel;
using FesteroApp.SharedKernel.Exceptions;
using FesteroApp.Users.Api.Controllers;

namespace FesteroApp.Tests.Api.Controllers
{
    public class FakeController : BaseController
    {
        public IActionResult TestAction() => Ok("Success");
    }

    [TestFixture]
    public class BaseControllerTests
    {
        [Test]
        public void OnActionExecuted_WithHttpException_ReturnsCorrectStatusCode()
        {
            var controller = new FakeController();
            var httpContext = new DefaultHttpContext();
            var actionContext = new ActionContext(
                httpContext,
                new RouteData(),
                new ActionDescriptor(),
                new ModelStateDictionary()
            );

            var context = new ActionExecutedContext(
                actionContext,
                [],
                controller)
            {
                Exception = new HttpException(HttpStatusCode.BadRequest, "Erro de validação")
            };

            controller.OnActionExecuted(context);

            Assert.Multiple(() =>
            {
                Assert.That(context.ExceptionHandled, Is.True);
                Assert.That(context.Result, Is.InstanceOf<ObjectResult>());
            });

            var result = context.Result as ObjectResult;

            Assert.Multiple(() =>
            {
                Assert.That(result!.StatusCode, Is.EqualTo(400));
                Assert.That(result?.Value, Is.EqualTo("Erro de validação"));
            });
        }

        [Test]
        public void OnActionExecuted_WithoutHttpException_DoesNothing()
        {
            var controller = new FakeController();
            var httpContext = new DefaultHttpContext();
            var actionContext = new ActionContext(
                httpContext,
                new RouteData(),
                new ActionDescriptor(),
                new ModelStateDictionary()
            );

            var context = new ActionExecutedContext(
                actionContext,
                [],
                controller)
            {
                Exception = new Exception("Erro genérico")
            };

            controller.OnActionExecuted(context);

            Assert.Multiple(() =>
            {
                Assert.That(context.ExceptionHandled, Is.False);
                Assert.That(context.Result, Is.Null);
            });
        }
    }
}
