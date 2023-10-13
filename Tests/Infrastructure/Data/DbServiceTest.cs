
using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Moq;
using Moq.Dapper;
using System.Data.Common;
using Xunit;

namespace Tests.Infrastructure.Data
{
    public class DbServiceTest
    {
        private readonly Mock<IDbConnectionFactory> _dbConnectionFactoryMock;
        private readonly User _exceptedUser;

        public DbServiceTest() {
            _dbConnectionFactoryMock = new Mock<IDbConnectionFactory>();
            _exceptedUser = new User("User Name Fake", "Rua 123", "01234567", "userfake.test@mailtest.com", "01234567898", "00954454455", "Fake City", "FC");
        }

        [Fact]
        public async Task QueryAsync_ReturnsData()
        {
            // Arrange
            Mock<DbConnection> connection = new Mock<DbConnection>();
            connection.SetupDapperAsync(c => c.QueryAsync<User>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<DbTransaction>(), null, null))
                .ReturnsAsync(new List<User>() { _exceptedUser });
            _dbConnectionFactoryMock.Setup(factory => factory.CreateConnection()).Returns(connection.Object);
            DbService dbService = new DbService(_dbConnectionFactoryMock.Object);

            // Act
            IEnumerable<User> users = await dbService.QueryAsync<User>("query", new { });

            // Assert
            Assert.NotEmpty(users);
            Assert.True(users.Count() == 1);
        }

        [Fact]
        public async Task QueryFirstOrDefaultAsync_ReturnsData()
        {
            // Arrange
            Mock<DbConnection> connection = new Mock<DbConnection>();
            connection.SetupDapperAsync(c => c.QueryFirstOrDefaultAsync<User>(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<DbTransaction>(), null, null))
                .ReturnsAsync(_exceptedUser);
            _dbConnectionFactoryMock.Setup(factory => factory.CreateConnection()).Returns(connection.Object);
            DbService dbService = new DbService(_dbConnectionFactoryMock.Object);

            // Act
            User user = await dbService.QueryFirstOrDefaultAsync<User>("query");

            // Assert
            Assert.Equal(_exceptedUser.Name, user.Name);
            Assert.Equal(_exceptedUser.Address, user.Address);
            Assert.Equal(_exceptedUser.CEP, user.CEP);
            Assert.Equal(_exceptedUser.Email, user.Email);
            Assert.Equal(_exceptedUser.Cpf, user.Cpf);
            Assert.Equal(_exceptedUser.Phone, user.Phone);
            Assert.Equal(_exceptedUser.City, user.City);
            Assert.Equal(_exceptedUser.State, user.State);
        }

        [Fact]
        public async Task ExecuteAsync_ReturnsResult()
        {
            // Arrange
            Mock<DbConnection> connection = new Mock<DbConnection>();
            connection.SetupDapperAsync(c => c.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<DbTransaction>(), null, null)).ReturnsAsync(1);
            _dbConnectionFactoryMock.Setup(factory => factory.CreateConnection()).Returns(connection.Object);
            DbService dbService = new DbService(_dbConnectionFactoryMock.Object);

            // Act
            int result = await dbService.ExecuteAsync("query", new { });

            // Assert
            Assert.Equal(1, result);
        }
    }
}
