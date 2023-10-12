using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Writable;
using Moq;
using Xunit;

namespace Tests.Infrastructure.Repositories.Writable
{
    public class UserWritableRepositoryTest
    {
        [Fact]
        public async Task Create_Should_Execute_Insert_Query_With_User()
        {
            // Arrange
            User user = new User { Name = "TestUser" };

            Mock<IDbService> dbServiceMock = SetupDbServiceMock(user);
            UserWritableRepository userRepository = new UserWritableRepository(dbServiceMock.Object);

            // Act
            var result = await userRepository.Create(user);

            // Assert
            AssertResults(user, dbServiceMock, result);
        }

        [Fact]
        public async Task Delete_Should_Execute_Delete_Query_With_Id()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Mock<IDbService> dbServiceMock = new Mock<IDbService>();
            dbServiceMock.Setup(service => service.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(1);
            UserWritableRepository userRepository = new UserWritableRepository(dbServiceMock.Object);

            // Act
            int result = await userRepository.Delete(userId);

            // Assert
            dbServiceMock.Verify(service => service.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
            Assert.Equal(1, result);
        }

        private Mock<IDbService> SetupDbServiceMock<T>(T param)
        {
            Mock<IDbService> dbServiceMock = new Mock<IDbService>();
            dbServiceMock.Setup(service => service.ExecuteAsync(It.IsAny<string>(), param)).ReturnsAsync(1);

            return dbServiceMock;
        }

        private void AssertResults<T>(T param, Mock<IDbService> dbServiceMock, int result)
        {
            dbServiceMock.Verify(service => service.ExecuteAsync(It.IsAny<string>(), param), Times.Once);
            Assert.Equal(1, result);
        }
    }
}
