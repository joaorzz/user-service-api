using Application.Commands;
using Application.Handlers.Commands;
using Domain.Exceptions;
using Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Tests.Application.Handlers.Commands
{
    public class DeleteUserCommandHandlerTest
    {
        [Fact]
        public async Task Handle_ValidId_DeletesUserAndLogs()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            Mock<IUserWritableService> userWritableServiceMock = new Mock<IUserWritableService>();
            Mock<ILogger<DeleteUserCommandHandler>> loggerMock = new Mock<ILogger<DeleteUserCommandHandler>>();

            DeleteUserCommandHandler handler = new DeleteUserCommandHandler(userWritableServiceMock.Object, loggerMock.Object);
            DeleteUserCommand command = new DeleteUserCommand(userId);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            userWritableServiceMock.Verify(service => service.DeleteUser(userId), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidId_DoesNotDeleteUserOrLog()
        {
            // Arrange
            Guid userId = Guid.Empty;
            Mock<IUserWritableService> userWritableServiceMock = new Mock<IUserWritableService>();
            userWritableServiceMock.Setup(x => x.DeleteUser(It.IsAny<Guid>())).ThrowsAsync(new UserNotFoundException());
            Mock<ILogger<DeleteUserCommandHandler>> loggerMock = new Mock<ILogger<DeleteUserCommandHandler>>();

            DeleteUserCommandHandler handler = new DeleteUserCommandHandler(userWritableServiceMock.Object, loggerMock.Object);
            DeleteUserCommand command = new DeleteUserCommand(userId);

            // Act
            Func<Task> task = async () => await handler.Handle(command, CancellationToken.None);

            // Assert
            await Assert.ThrowsAsync<UserNotFoundException>(task);
        }
    }
}
