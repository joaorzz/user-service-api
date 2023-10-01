using Dapper;
using Domain.Entities;
using Domain.Repositories.Writable;
using Infrastructure.Data;
using System.Data;

namespace Infrastructure.Repositories.Writable
{
    public class UserWritableRepository : IUserWritableRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public UserWritableRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<int> Create(User user)
        {
            using (IDbConnection connection = _dbConnectionFactory.CreateConnection())
            {
                const string query = "INSERT INTO \"User\" (\"Name\", \"Address\", \"CEP\", \"Email\", \"Cpf\", \"Phone\", \"City\", \"State\") " +
                             "VALUES (@Name, @Address, @CEP, @Email, @Cpf, @Phone, @City, @State)";

                return await connection.ExecuteAsync(query, user);
            }
        }

        public Task<int> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
