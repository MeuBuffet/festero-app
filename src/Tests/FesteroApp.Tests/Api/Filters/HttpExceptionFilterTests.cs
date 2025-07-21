using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using FesteroApp.Mvc;
using FesteroApp.SharedKernel.Exceptions;

namespace FesteroApp.Tests.Api.Filters
{
    public class HttpExceptionFilterTests
    {
        [Test]
        public void HttpExceptionFilter_ShouldHandleHttpException()
        {
            var context = new ExceptionContext(new ActionContext(new DefaultHttpContext(), new(), new(), new()), [])
            {
                Exception = new HttpException(HttpStatusCode.Forbidden, "Forbidden")
            };

            var filter = new HttpExceptionFilter();
            filter.OnException(context);

            Assert.Multiple(() =>
            {
                Assert.That(context.ExceptionHandled, Is.True);
                Assert.That(context.Result, Is.TypeOf<ObjectResult>());
            });

            var result = (ObjectResult)context.Result!;

            Assert.Multiple(() =>
            {
                Assert.That(result.StatusCode, Is.EqualTo(403));
                Assert.That(result.Value, Is.EqualTo("Forbidden"));
            });
        }
    }
}
