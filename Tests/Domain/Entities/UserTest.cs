using Domain.Entities;
using Xunit;

namespace Tests.Domain.Entities
{
    public class UseTest
    {
        [Fact]
        public void User_WithValidData_ShouldCreate()
        {
            // Arrange
            const string name = "João Silva";
            const string address = "Rua das Flores, 123";
            const string cep = "12345-678";
            const string email = "joaosilva@example.com";
            const string cpf = "123.456.789-00";
            const string phone = "(12) 3456-7890";
            const string city = "São Paulo";
            const string state = "SP";


            // Act
            User user = new User(name, address, cep, email, cpf, phone, city, state);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(name, user.Name);
            Assert.Equal(address, user.Address);
            Assert.Equal(cep, user.CEP);
            Assert.Equal(email, user.Email);
            Assert.Equal(cpf, user.Cpf);
            Assert.Equal(phone, user.Phone);
            Assert.Equal(city, user.City);
            Assert.Equal(state, user.State);
        }
    }
}
