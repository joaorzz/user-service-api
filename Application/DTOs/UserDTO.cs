using Domain.Entities;

namespace Application.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string City { get; }
        public string State { get; }
        public DateTime CreatedAt { get; }

        public UserDTO(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            City = user.City;
            State = user.State;
            CreatedAt = user.CreatedAt;
        }
    }
}
