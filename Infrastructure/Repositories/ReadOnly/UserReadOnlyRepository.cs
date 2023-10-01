using Dapper;
using Domain.Entities;
using Domain.Repositories.ReadOnly;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.ReadOnly
{
    public class UserReadOnlyRepository : IUserReadOnlyRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public UserReadOnlyRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (IDbConnection connection = _dbConnectionFactory.CreateConnection())
            {
                const string query = "SELECT * FROM \"User\"";

                return await connection.QueryAsync<User>(query);
            }
        }

        public async Task<User> GetById(Guid id)
        {
            using (IDbConnection connection = _dbConnectionFactory.CreateConnection())
            {
                const string query = "SELECT * FROM \"User\" WHERE \"Id\" = @UserId";

                return await connection.QueryFirstAsync<User>(query, new { UserId = id });
            }
        }

        public async Task<User> GetByCpf(string cpf)
        {
            using (IDbConnection connection = _dbConnectionFactory.CreateConnection())
            {
                const string query = "SELECT * FROM \"User\" WHERE \"Cpf\" = @Cpf";

                return await connection.QueryFirstAsync<User>(query, new { Cpf = cpf });
            }
        }
    }
}
