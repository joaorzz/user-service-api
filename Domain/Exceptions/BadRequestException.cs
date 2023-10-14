using System.Net;

namespace Domain.Exceptions
{
    public class BadRequestException : HttpResponseException
    {
        public BadRequestException() : base("Invalid Request.", HttpStatusCode.BadRequest)
        {
        }
    }
}
