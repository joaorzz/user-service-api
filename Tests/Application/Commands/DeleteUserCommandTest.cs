using Application.Commands;
using Xunit;

namespace Tests.Application.Commands
{
    public class DeleteUserCommandTest
    {
        [Fact]
        public void DeleteUserCommand_Constructor_SetsProperties()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            DeleteUserCommand command = new DeleteUserCommand(id);

            // Assert
            Assert.Equal(id, command.Id);
        }
    }
}
