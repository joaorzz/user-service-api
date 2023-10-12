using Application.Commands;
using Xunit;

namespace Tests.Application.Commands
{
    public class CreateUserCommandTest
    {
        [Fact]
        public void CreateUserCommand_ShouldCreateInstance()
        {
            // Arrange
            const string name = "Fred Simpson";
            const string address = "456 Elm St";
            const string cep = "98765-432";
            const string email = "fredsimpson@example.com";
            const string cpf = "987.654.321-00";
            const string phone = "(987) 654-3210";
            const string city = "Othertown";
            const string state = "NY";

            // Act
            var createUserCommand = new CreateUserCommand(name, address, cep, email, cpf, phone, city, state);

            // Assert
            Assert.NotNull(createUserCommand);
            Assert.Equal(name, createUserCommand.Name);
            Assert.Equal(address, createUserCommand.Address);
            Assert.Equal(cep, createUserCommand.CEP);
            Assert.Equal(email, createUserCommand.Email);
            Assert.Equal(cpf, createUserCommand.Cpf);
            Assert.Equal(phone, createUserCommand.Phone);
            Assert.Equal(city, createUserCommand.City);
            Assert.Equal(state, createUserCommand.State);
        }
    }
}
