using System;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using UserTaskManagement.Common.Abstractions;
using UserTaskManagement.Common.Configuration;

namespace UserTaskManagement.Common.Factories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString = "";

        public DbConnectionFactory(IAppSetting configuration)
        {
            _connectionString = configuration.DbConnection;
        }

        public DbConnection GetConnection()
        {
            var connectionString = _connectionString;

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new Exception($"Could not create a connection string");

            return new SqlConnection(connectionString);
        }
    }
}
