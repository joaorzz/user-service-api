using Domain.Exceptions;
using System.Net;
using Xunit;

namespace Tests.Domain.Exceptions
{
    public class BadRequestExceptionTest
    {
        [Fact]
        public void BadRequestException_Should_Have_Default_Constructor()
        {
            // Arrange and Act
            BadRequestException exception = new BadRequestException();

            // Assert
            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.BadRequest, exception.StatusCode);
        }
    }
}
