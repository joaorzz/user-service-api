using Domain.Entities;
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
            if (await UserExists(id))
            {
                await _userWritableRepository.Delete(id);
            }    
        }

        private async Task<bool> UserExists(Guid id)
        {
            User user = await _userReadOnlyService.GetUserById(id);

            if (user is null)
                throw new Exception("User not found UserNotFoundException");

            return true;
        }
    }
}
