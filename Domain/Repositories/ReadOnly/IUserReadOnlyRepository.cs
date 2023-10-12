using Domain.Entities;

namespace Domain.Repositories.ReadOnly
{
    public interface IUserReadOnlyRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> GetByCpf(string cpf);
    }
}
