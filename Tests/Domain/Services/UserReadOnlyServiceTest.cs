using Domain.Entities;
using Domain.Repositories.ReadOnly;
using Domain.Services;
using Moq;
using Xunit;

namespace Tests.Domain.Services
{
    public class UserReadOnlyServiceTest
    {
        private readonly UserReadOnlyService _userService;
        private readonly User _expectedUser;
        public UserReadOnlyServiceTest()
        {
            _expectedUser = new User { Id = Guid.NewGuid(), Name = "User1", Cpf = "1234567890" };
     
            Mock<IUserReadOnlyRepository> userRepositoryMock = SetupUserReadOnlyRepositoryMock();

            _userService = new UserReadOnlyService(userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllUsers_Should_Return_List_Of_Users()
        {
            // Arrange
            List<User> expectedUsers = new List<User>() { _expectedUser };

            // Act
            var result = await _userService.GetAllUsers();

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

            // Act
            var result = await _userService.GetUserById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public async Task GetUserByCpf_Should_Return_User_With_Given_Cpf()
        {
            // Arrange
            string expectedCpf = _expectedUser.Cpf;

            // Act
            var result = await _userService.GetUserByCpf(expectedCpf);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCpf, result.Cpf);
        }

        private Mock<IUserReadOnlyRepository> SetupUserReadOnlyRepositoryMock()
        {
            Mock<IUserReadOnlyRepository> userRepositoryMock = new Mock<IUserReadOnlyRepository>();

            userRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(new List<User>() { _expectedUser });
            userRepositoryMock.Setup(repo => repo.GetById(_expectedUser.Id)).ReturnsAsync(_expectedUser);
            userRepositoryMock.Setup(repo => repo.GetByCpf(_expectedUser.Cpf)).ReturnsAsync(_expectedUser);

            return userRepositoryMock;
        }
    }
}
