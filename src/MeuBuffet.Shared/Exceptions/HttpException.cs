using System.Net;

namespace MeuBuffet.Shared.Exceptions
{
    public class HttpException(HttpStatusCode statusCode, string message = "") : Exception(message)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
    }
}