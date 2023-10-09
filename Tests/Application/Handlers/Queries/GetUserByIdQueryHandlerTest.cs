using Application.DTOs;
using Application.Handlers.Queries;
using Application.Queries;
using Domain.Entities;
using Domain.Services.Interfaces;
using Moq;
using Xunit;

namespace Tests.Application.Handlers.Queries
{
    public class GetUserByIdQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ValidId_ReturnsUserDTO()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            User user = new User { Id = userId, Name = "Julian Alves" };
            Mock<IUserReadOnlyService> mockUserReadOnlyService = new Mock<IUserReadOnlyService>();
            mockUserReadOnlyService.Setup(x => x.GetUserById(userId)).ReturnsAsync(user);
            GetUserByIdQuery query = new GetUserByIdQuery(userId);
            GetUserByIdQueryHandler handler = new GetUserByIdQueryHandler(mockUserReadOnlyService.Object);

            // Act
            UserDTO result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Name, result.Name);
        }
    }
}
