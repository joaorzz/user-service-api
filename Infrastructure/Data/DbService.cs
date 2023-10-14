using Dapper;
using System.Data;

namespace Infrastructure.Data
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _connection;

        public DbService(IDbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.CreateConnection();
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            return await _connection.QueryAsync<T>(sql, param);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null)
        {
            return await _connection.QueryFirstOrDefaultAsync<T>(sql, param);
        }

        public async Task<int> ExecuteAsync(string sql, object param = null)
        {
            return await _connection.ExecuteAsync(sql, param);
        }
    }
}
