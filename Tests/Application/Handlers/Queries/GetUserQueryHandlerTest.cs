using Application.DTOs;
using Application.Handlers.Queries;
using Application.Queries;
using Domain.Entities;
using Domain.Services.Interfaces;
using Moq;
using Xunit;

namespace Tests.Application.Handlers.Queries
{
    public class GetUserQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ReturnsUsersResultDTO_WithListOfUsers()
        {
            // Arrange
            List<User> expectedUsers = new List<User>
            {
                new User { Id = Guid.NewGuid(), Name = "User1" },
                new User { Id = Guid.NewGuid(), Name = "User2" }
            };
            Mock<IUserReadOnlyService> userReadOnlyServiceMock = new Mock<IUserReadOnlyService>();
            userReadOnlyServiceMock.Setup(x => x.GetAllUsers()).ReturnsAsync(expectedUsers);
            GetUserQuery query = new GetUserQuery();
            GetUserQueryHandler handler = new GetUserQueryHandler(userReadOnlyServiceMock.Object);

            // Act
            UsersResultDTO result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsType<UsersResultDTO>(result);
            Assert.Equal(expectedUsers.Count, result.Users.Count);
        }
    }
    
}
