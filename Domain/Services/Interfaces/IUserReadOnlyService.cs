using Domain.Entities;

namespace Domain.Services.Interfaces
{
    public interface IUserReadOnlyService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task<User> GetUserByCpf(string cpf);
    }
}
