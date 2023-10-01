using Domain.Entities;
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
            return await _userRepository.GetById(id);
        }
        
        public async Task<User> GetUserByCpf(string cpf)
        {
            return await _userRepository.GetByCpf(cpf);
        }
    }
}
