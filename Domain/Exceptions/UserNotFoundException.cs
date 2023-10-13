using System.Net;

namespace Domain.Exceptions
{
    public class UserNotFoundException : HttpResponseException
    {
        public UserNotFoundException() : base("User not found.", HttpStatusCode.NotFound)
        {
        }
    }
}
