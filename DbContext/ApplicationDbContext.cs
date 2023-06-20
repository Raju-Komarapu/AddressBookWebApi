using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AddressBookWebApi.DbContext
{
    public class ApplicationDbContext
    {
        private IDbConnection _connection;

        public ApplicationDbContext(IConfiguration configuration)
        {
            this._connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            return this._connection.GetAll<T>();
        }

        public T Get<T>(Guid id) where T : class
        {
            return this._connection.Get<T>(id);
        }

        public T ExecuteScalar<T>(string query, object? parameters)
        {
            return this._connection.ExecuteScalar<T>(query, parameters);
        }

        public void Execute(string query, object? parameters)
        {
            this._connection.Execute(query, parameters);
        }

        public bool Update<T>(T entity) where T : class
        {
            return this._connection.Update(entity);
        }

        public bool Delete<T>(T entity) where T : class
        {
            return this._connection.Delete<T>(entity);
        }
    }
}
