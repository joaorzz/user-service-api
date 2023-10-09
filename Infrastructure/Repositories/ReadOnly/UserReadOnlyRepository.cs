using Domain.Entities;
using Domain.Repositories.ReadOnly;
using Infrastructure.Data;

namespace Infrastructure.Repositories.ReadOnly
{
    public class UserReadOnlyRepository : IUserReadOnlyRepository
    {
        private readonly IDbService _dbService;

        public UserReadOnlyRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            const string query = "SELECT * FROM \"User\"";
            return await _dbService.QueryAsync<User>(query);
        }

        public async Task<User> GetById(Guid id)
        {
            const string query = "SELECT * FROM \"User\" WHERE \"Id\" = @UserId";
            return await _dbService.QueryFirstAsync<User>(query, new { UserId = id });
        }

        public async Task<User> GetByCpf(string cpf)
        {
            const string query = "SELECT * FROM \"User\" WHERE \"Cpf\" = @Cpf";
            return await _dbService.QueryFirstAsync<User>(query, new { Cpf = cpf });
        }
    }
}
