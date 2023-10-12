using Domain.Entities;
using Domain.Repositories.Writable;
using Infrastructure.Data;

namespace Infrastructure.Repositories.Writable
{
    public class UserWritableRepository : IUserWritableRepository
    {
        private readonly IDbService _dbService;

        public UserWritableRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<int> Create(User user)
        {
            const string query = "INSERT INTO \"User\" (\"Name\", \"Address\", \"CEP\", \"Email\", \"Cpf\", \"Phone\", \"City\", \"State\") " +
                         "VALUES (@Name, @Address, @CEP, @Email, @Cpf, @Phone, @City, @State)";

            return await _dbService.ExecuteAsync(query, user);
        }

        public async Task<int> Delete(Guid id)
        {
            const string query = "DELETE FROM \"User\" WHERE \"Id\" = @UserId";

            var parameters = new { UserId = id };

            return await _dbService.ExecuteAsync(query, parameters);
        }        
    }
}
