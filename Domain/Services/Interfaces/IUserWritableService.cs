using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IUserWritableService
    {
        Task CreateUser(User user);
        Task DeleteUser(Guid id);
    }
}
