using Domain.Entities;

namespace Domain.Repositories.Writable
{
    public interface IUserWritableRepository
    {
        Task<int> Create(User user);
        Task<int> Update(User user);
        Task<int> Delete(Guid id);
    }
}
