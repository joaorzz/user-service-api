namespace Infrastructure.Data
{
    public interface IDbService
    {
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
        Task<T> QueryFirstAsync<T>(string sql, object param = null);
        Task<int> ExecuteAsync(string sql, object param = null);
    }
}
