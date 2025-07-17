using System.Net;

namespace FesteroApp.Shared.Exceptions
{
    public class HttpException(HttpStatusCode statusCode, string message = "") : Exception(message)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
    }
}