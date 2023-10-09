using Application.DTOs;
using Domain.Entities;
using Xunit;

namespace Tests.Application.DTOs
{
    public class UsersResultDTOTest
    {
        [Fact]
        public void UsersResultDTO_ShouldCreateUserDTOList_WhenGivenUserList()
        {
            // Arrange
            const string user1Name = "Alice Smith";
            const string user1mail = "alice.smith@example.com";
            const string user2Name = "Bob Johnson";
            const string user2mail = "bob.johnson@example.com";
            List<User> users = new List<User>
            {
                new User { Id = Guid.NewGuid(), Name = user1Name, Email = user1mail },
                new User { Id = Guid.NewGuid(), Name = user2Name, Email = user2mail }
            };

            // Act
            UsersResultDTO usersResultDTO = new UsersResultDTO(users);

            // Assert
            Assert.Equal(2, usersResultDTO.Users.Count);
            Assert.Equal(user1Name, usersResultDTO.Users[0].Name);
            Assert.Equal(user1mail, usersResultDTO.Users[0].Email);
            Assert.Equal(user2Name, usersResultDTO.Users[1].Name);
            Assert.Equal(user2mail, usersResultDTO.Users[1].Email);
        }
    }
}