using Domain.Entities;

namespace Application.DTOs
{
    public class UsersResultDTO
    {
        public UsersResultDTO(List<User> users)
        {
            Users = new List<UserDTO>();

            foreach(User user in users)
            {
                Users.Add(new UserDTO(user));
            }
        }

        public List<UserDTO> Users { get; }
    }
}
