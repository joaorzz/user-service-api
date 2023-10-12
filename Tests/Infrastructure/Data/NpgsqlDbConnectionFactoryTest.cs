using Infrastructure.Configuration;
using Infrastructure.Data;
using Npgsql;
using System.Data;
using Xunit;

namespace Tests.Infrastructure.Data
{
    public class NpgsqlDbConnectionFactoryTest
    {
        [Fact]
        public void CreateConnection_Should_Return_DbConnection_With_Correct_ConnectionString()
        {
            // Arrange
            const string expectedConnectionString = "Host=myserver;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword;";
            ConnectionStrings connectionStrings = new ConnectionStrings { UserConnection = expectedConnectionString };
            NpgsqlDbConnectionFactory factory = new NpgsqlDbConnectionFactory(connectionStrings);

            // Act
            IDbConnection connection = factory.CreateConnection();

            // Assert
            Assert.IsType<NpgsqlConnection>(connection);
            Assert.Equal(expectedConnectionString, connection.ConnectionString);
        }

        [Fact]
        public void Constructor_Should_Throw_ArgumentNullException_When_ConnectionStrings_Null()
        {
            // Arrange
            ConnectionStrings connectionStrings = null;

            // Act and Assert
            Assert.Throws<NullReferenceException>(() => new NpgsqlDbConnectionFactory(connectionStrings));
        }
    }
}
