using Application.Commands;
using Application.Handlers.Commands;
using Domain.Entities;
using Domain.Services.Interfaces;
using Moq;
using Xunit;

namespace Tests.Application.Handlers.Commands
{
    public class CreateUserCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldCreateUserAndReturnId()
        {
            // Arrange
            Mock<IUserWritableService> userWritableServiceMock = new Mock<IUserWritableService>();

            CreateUserCommand command = new CreateUserCommand("John Silva", "Rua 1", "07101-010", "john.silva@example.com",
                "123.456.789-00", "(123) 456-7890", "Anytown", "CA");

            CreateUserCommandHandler handler = new CreateUserCommandHandler(userWritableServiceMock.Object);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            userWritableServiceMock.Verify(x => x.CreateUser(It.IsAny<User>()), Times.Once);
        }
    }
}