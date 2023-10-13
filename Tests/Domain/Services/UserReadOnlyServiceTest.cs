using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories.ReadOnly;
using Domain.Services;
using Moq;
using Xunit;

namespace Tests.Domain.Services
{
    public class UserReadOnlyServiceTest
    {
        private readonly User _expectedUser;

        public UserReadOnlyServiceTest()
        {
            _expectedUser = new User { Id = Guid.NewGuid(), Name = "User1", Cpf = "1234567890" };
        }

        [Fact]
        public async Task GetAllUsers_Should_Return_List_Of_Users()
        {
            // Arrange
            List<User> expectedUsers = new List<User>() { _expectedUser };
            Mock<IUserReadOnlyRepository> userRepositoryMock = SetupUserReadOnlyRepositoryMock();
            UserReadOnlyService userService = new UserReadOnlyService(userRepositoryMock.Object);

            // Act
            var result = await userService.GetAllUsers();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<User>>(result);
            Assert.Equal(expectedUsers.Count, result.Count);
        }

        [Fact]
        public async Task GetUserById_Should_Return_User_With_Given_Id()
        {
            // Arrange
            Guid userId = _expectedUser.Id;
            Mock<IUserReadOnlyRepository> userRepositoryMock = SetupUserReadOnlyRepositoryMock();
            UserReadOnlyService userService = new UserReadOnlyService(userRepositoryMock.Object);

            // Act
            var result = await userService.GetUserById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public async Task GetUserById_With_NonExisting_User_Should_Throws_Exception()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Mock<IUserReadOnlyRepository> userRepositoryMock = SetupUserReadOnlyRepositoryMockWithException();
            UserReadOnlyService userService = new UserReadOnlyService(userRepositoryMock.Object);

            // Act
            async Task Result() => await userService.GetUserById(userId);

            // Assert
            await Assert.ThrowsAsync<UserNotFoundException>(Result);
        }

        [Fact]
        public async Task GetUserByCpf_Should_Return_User_With_Given_Cpf()
        {
            // Arrange
            string expectedCpf = _expectedUser.Cpf;
            Mock<IUserReadOnlyRepository> userRepositoryMock = SetupUserReadOnlyRepositoryMock();
            UserReadOnlyService userService = new UserReadOnlyService(userRepositoryMock.Object);

            // Act
            var result = await userService.GetUserByCpf(expectedCpf);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCpf, result.Cpf);
        }

        [Fact]
        public async Task GetUserByCpf_With_NonExisting_User_Should_Throws_Exception()
        {
            // Arrange
            string expectedCpf = _expectedUser.Cpf;
            Mock<IUserReadOnlyRepository> userRepositoryMock = SetupUserReadOnlyRepositoryMockWithException();
            UserReadOnlyService userService = new UserReadOnlyService(userRepositoryMock.Object);

            // Act
            async Task Result() => await userService.GetUserByCpf(expectedCpf);

            // Assert
            await Assert.ThrowsAsync<UserNotFoundException>(Result);
        }

        private Mock<IUserReadOnlyRepository> SetupUserReadOnlyRepositoryMock()
        {
            Mock<IUserReadOnlyRepository> userRepositoryMock = new Mock<IUserReadOnlyRepository>();

            userRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(new List<User>() { _expectedUser });
            userRepositoryMock.Setup(repo => repo.GetById(_expectedUser.Id)).ReturnsAsync(_expectedUser);
            userRepositoryMock.Setup(repo => repo.GetByCpf(_expectedUser.Cpf)).ReturnsAsync(_expectedUser);

            return userRepositoryMock;
        }

        private Mock<IUserReadOnlyRepository> SetupUserReadOnlyRepositoryMockWithException()
        {
            Mock<IUserReadOnlyRepository> userRepositoryMock = new Mock<IUserReadOnlyRepository>();

            userRepositoryMock.Setup(repo => repo.GetById(_expectedUser.Id)).ReturnsAsync(default(User));
            userRepositoryMock.Setup(repo => repo.GetByCpf(_expectedUser.Cpf)).ReturnsAsync(default(User));


            return userRepositoryMock;
        }
    }
}
