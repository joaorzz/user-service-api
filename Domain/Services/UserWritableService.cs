using Domain.Entities;
using Domain.Repositories.Writable;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class UserWritableService : IUserWritableService
    {
        private readonly IUserWritableRepository _userWritableRepository;

        public UserWritableService(IUserWritableRepository userWritableRepository)
        {
            _userWritableRepository = userWritableRepository;
        }

        public Task<int> CreateUser(User user)
        {
            return _userWritableRepository.Create(user);
        }

        public Task<int> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
