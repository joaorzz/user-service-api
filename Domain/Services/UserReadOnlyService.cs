using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories.ReadOnly;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class UserReadOnlyService : IUserReadOnlyService
    {
        private readonly IUserReadOnlyRepository _userRepository;

        public UserReadOnlyService(IUserReadOnlyRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            IEnumerable<User> users = await _userRepository.GetAll();
            return users.ToList();
        }

        public async Task<User> GetUserById(Guid id)
        {
            User user = await _userRepository.GetById(id);
            CheckIfUserExists(user);
            return user;
        }

        public async Task<User> GetUserByCpf(string cpf)
        {
            User user = await _userRepository.GetByCpf(cpf);
            CheckIfUserExists(user);
            return user;
        }

        public void CheckIfUserExists(User user)
        {
            if (user is null)
                throw new UserNotFoundException();
        }
    }
}
