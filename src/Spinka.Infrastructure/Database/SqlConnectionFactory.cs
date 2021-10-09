using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Spinka.Infrastructure.Options;

namespace Spinka.Infrastructure.Database
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly IOptions<SqlOption> _sqlOption;
        private IDbConnection _connection;

        public SqlConnectionFactory(IOptions<SqlOption> sqlOption)
        {
            _sqlOption = sqlOption;
        }

        public IDbConnection GetOpenConnection()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_sqlOption.Value.ConnectionString);
                _connection.Open();
            }

            return _connection;
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Dispose();
            }
        }
    }
}