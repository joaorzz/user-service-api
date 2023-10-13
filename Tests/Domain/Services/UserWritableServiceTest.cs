using Domain.Entities;
using Domain.Repositories.Writable;
using Domain.Services;
using Domain.Services.Interfaces;
using Moq;
using Xunit;

namespace Tests.Domain.Services
{
    public class UserWritableServiceTest
    {
        private Mock<IUserWritableRepository> userRepositoryMock;
        private Mock<IUserReadOnlyService> userReadOnlyServiceMock;
        private UserWritableService userWritableService;

        public UserWritableServiceTest()
        {
            userRepositoryMock = new Mock<IUserWritableRepository>();
            userReadOnlyServiceMock = new Mock<IUserReadOnlyService>();
            userWritableService = new UserWritableService(userRepositoryMock.Object, userReadOnlyServiceMock.Object);
        }

        [Fact]
        public async Task CreateUser_Should_Call_Create_Method_In_Repository()
        {
            // Arrange
            User user = new User { Id = Guid.NewGuid(), Name = "TestUser" };

            // Act
            await userWritableService.CreateUser(user);

            // Assert
            userRepositoryMock.Verify(repo => repo.Create(user), Times.Once);
        }

        [Fact]
        public async Task DeleteUser_With_Existing_User_Should_Call_Delete_Method_In_Repository()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            userRepositoryMock.Setup(repo => repo.Delete(userId)).ReturnsAsync(1);
            userReadOnlyServiceMock.Setup(service => service.GetUserById(userId)).ReturnsAsync(new User { Id = userId });

            // Act
            await userWritableService.DeleteUser(userId);

            // Assert
            userRepositoryMock.Verify(repo => repo.Delete(userId), Times.Once);
        }
    }
}
