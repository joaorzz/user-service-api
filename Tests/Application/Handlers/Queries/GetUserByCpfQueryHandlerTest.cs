using Application.DTOs;
using Application.Handlers.Queries;
using Application.Queries;
using Domain.Entities;
using Domain.Services.Interfaces;
using Moq;
using Xunit;

namespace Tests.Application.Handlers.Queries
{
    public class GetUserByCpfQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ValidCpf_ReturnsUserDto()
        {
            // Arrange
            const string cpf = "12345678900";
            User user = new User { Name = "UserTest", Cpf = cpf };
            UserDTO expectedUserDto = new UserDTO(user);
            GetUserByCpfQuery query = new GetUserByCpfQuery(cpf);
            Mock<IUserReadOnlyService> mockUserReadOnlyService = new Mock<IUserReadOnlyService>();
            mockUserReadOnlyService.Setup(x => x.GetUserByCpf(cpf)).ReturnsAsync(user);
            GetUserByCpfQueryHandler handler = new GetUserByCpfQueryHandler(mockUserReadOnlyService.Object);

            // Act
            UserDTO result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedUserDto.Name, result.Name);
        }
    }
}
