using Application.DTOs;
using Domain.Entities;
using Xunit;

namespace Tests.Application.DTOs
{
    public class UserDTOTest
    {
        [Fact]
        public void UserDTO_Constructor_ShouldMapPropertiesCorrectly()
        {
            // Arrange
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = "Alice Smith",
                Email = "alice.smith@example.com",
                City = "San Francisco",
                State = "CA",
                CreatedAt = DateTime.UtcNow
            };

            // Act
            UserDTO userDTO = new UserDTO(user);

            // Assert
            Assert.Equal(user.Id, userDTO.Id);
            Assert.Equal(user.Name, userDTO.Name);
            Assert.Equal(user.Email, userDTO.Email);
            Assert.Equal(user.City, userDTO.City);
            Assert.Equal(user.State, userDTO.State);
            Assert.Equal(user.CreatedAt, userDTO.CreatedAt);
        }
    }
}
