using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IUserWritableService
    {
        Task<int> CreateUser(User user);
        Task<int> UpdateUser(User user);
        Task<int> DeleteUser(Guid id);
    }
}
