using Npgsql;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sacraldotnet
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM " + typeof(T).Name;
                return await connection.QueryAsync<T>(query);
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "SELECT * FROM " + typeof(T).Name + " WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
            }
        }

        public async Task<int> InsertAsync(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "INSERT INTO " + typeof(T).Name + " VALUES (@Id, @Name)";
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(T entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "UPDATE " + typeof(T).Name + " SET Name = @Name WHERE Id = @Id";
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var query = "DELETE FROM " + typeof(T).Name + " WHERE Id = @Id";
                return await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}