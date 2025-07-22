using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using FesteroApp.Api.Middlewares;
using FesteroApp.SharedKernel.Exceptions;

namespace FesteroApp.Tests.Api.Middleware;

public class ExceptionMiddlewareTests
{
    [Test]
    public async Task Should_Return_HttpException_Status_And_Message()
    {
        var context = new DefaultHttpContext();
        var middleware = new ExceptionMiddleware(_ => throw new HttpException(HttpStatusCode.Unauthorized, "Unauthorized"),
            Mock.Of<ILogger<ExceptionMiddleware>>());

        var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await middleware.Invoke(context);
        responseBody.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(responseBody);
        var body = await reader.ReadToEndAsync();

        Assert.Multiple(() =>
        {
            Assert.That(context.Response.StatusCode, Is.EqualTo(401));
            Assert.That(body, Is.EqualTo("Unauthorized"));
        });
    }

    [Test]
    public async Task Should_Return_InternalServerError_For_GenericException()
    {
        var context = new DefaultHttpContext();
        var middleware = new ExceptionMiddleware(_ => throw new Exception("Failure"),
            Mock.Of<ILogger<ExceptionMiddleware>>());

        var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await middleware.Invoke(context);
        responseBody.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(responseBody);
        var body = await reader.ReadToEndAsync();

        Assert.Multiple(() =>
        {
            Assert.That(context.Response.StatusCode, Is.EqualTo(500));
            Assert.That(body, Is.EqualTo("Erro interno no servidor."));
        });
    }
}