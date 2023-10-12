using Infrastructure.Configuration;
using Npgsql;
using System.Data;

namespace Infrastructure.Data
{
    public class NpgsqlDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public NpgsqlDbConnectionFactory(ConnectionStrings connectionStrings)
        {
            _connectionString = connectionStrings.UserConnection;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
