using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories.Writable;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class UserWritableService : IUserWritableService
    {
        private readonly IUserWritableRepository _userWritableRepository;
        private readonly IUserReadOnlyService _userReadOnlyService;

        public UserWritableService(IUserWritableRepository userWritableRepository, IUserReadOnlyService userReadOnlyService)
        {
            _userWritableRepository = userWritableRepository;
            _userReadOnlyService = userReadOnlyService;
        }

        public async Task CreateUser(User user)
        {
            await _userWritableRepository.Create(user);
        }

        public async Task DeleteUser(Guid id)
        {
            User user = await _userReadOnlyService.GetUserById(id);

            await _userWritableRepository.Delete(user.Id);
        }
    }
}
