using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.ReadOnly;
using Moq;
using Xunit;

namespace Tests.Infrastructure.Repositories.ReadOnly
{
    public class UserReadOnlyRepositoryTest
    {
        private readonly Mock<IDbService> _dbServiceMock;
        private readonly UserReadOnlyRepository _userRepository;

        public UserReadOnlyRepositoryTest()
        {
            _dbServiceMock = new Mock<IDbService>();
            _userRepository = new UserReadOnlyRepository(_dbServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_Should_Return_List_Of_Users()
        {
            // Arrange
            List<User> expectedUsers = CreateExpectedUsers();
            SetupDbServiceQueryAsync(expectedUsers);

            // Act
            IEnumerable<User> result = await _userRepository.GetAll();

            // Assert
            AssertNotNullAndIsAssignable(result, expectedUsers);
        }

        [Fact]
        public async Task GetById_Should_Return_User_With_Given_Id()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            User expectedUser = new User { Id = userId, Name = "User1", Cpf = "1234567890" };
            SetupDbServiceQueryFirstAsync(expectedUser);

            // Act
            User result = await _userRepository.GetById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.Id);
        }

        [Fact]
        public async Task GetByCpf_Should_Return_User_With_Given_Cpf()
        {
            // Arrange
            const string expectedCpf = "1234567890";
            User expectedUser = new User { Id = Guid.NewGuid(), Name = "User1", Cpf = expectedCpf };
            SetupDbServiceQueryFirstAsync(expectedUser);

            // Act
            User result = await _userRepository.GetByCpf(expectedCpf);

            // Assert
            AssertNotNullAndIsAssignable(result.Cpf, expectedCpf);
        }

        private List<User> CreateExpectedUsers()
        {
            return new List<User>
        {
            new User { Id = Guid.NewGuid(), Name = "User1", Cpf = "1234567890" },
            new User { Id = Guid.NewGuid(), Name = "User2", Cpf = "0987654321" }
        };
        }

        private void SetupDbServiceQueryAsync<T>(IEnumerable<T> expectedResult)
        {
            _dbServiceMock
                .Setup(service => service.QueryAsync<T>(It.IsAny<string>(), null))
                .ReturnsAsync(expectedResult);
        }

        private void SetupDbServiceQueryFirstAsync<T>(T expectedResult)
        {
            _dbServiceMock
                .Setup(service => service.QueryFirstAsync<T>(It.IsAny<string>(), It.IsAny<object>()))
                .ReturnsAsync(expectedResult);
        }

        private void AssertNotNullAndIsAssignable<T>(T result, T expected)
        {
            Assert.NotNull(result);
            Assert.IsAssignableFrom<T>(result);
            Assert.Equal(expected, result);
        }
    }
}
