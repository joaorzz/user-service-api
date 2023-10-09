using Infrastructure.Configuration;
using Xunit;

namespace Tests.Infrastructure.Configuration
{
    public class ConnectionStringsTest
    {
        [Fact]
        public void UserConnection_Setter_Getter_Test()
        {
            // Arrange
            ConnectionStrings connectionStrings = new ConnectionStrings();
            const string expectedConnectionString = "Host=myserver;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword;";

            // Act
            connectionStrings.UserConnection = expectedConnectionString;
            string actualConnectionString = connectionStrings.UserConnection;

            // Assert
            Assert.Equal(expectedConnectionString, actualConnectionString);
        }
    }
}
