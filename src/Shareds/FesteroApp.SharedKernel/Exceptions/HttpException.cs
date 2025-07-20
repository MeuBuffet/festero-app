using System.Net;

namespace FesteroApp.SharedKernel.Exceptions
{
    public class HttpException(HttpStatusCode statusCode, string message = "") : Exception(message)
    {
        public HttpStatusCode StatusCode { get; } = statusCode;
    }
}