using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using Dapper;
using UserTaskManagement.Common.Abstractions;
using UserTaskManagement.Common.Configuration;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Common.Repositories;

namespace UserTaskManangement.DataAccess.Data
{
    public class UserRepository : AsyncDbRepository, IUserRepository
    {
        private readonly IAppSetting _configuration;

        public UserRepository(
           IAppSetting configuration,
           IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
            if (connectionFactory == null) throw new ArgumentNullException(nameof(connectionFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async  Task AddUserAsync(User user)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@FirstName", user.FirstName);
            queryParameters.Add("@LastName", user.LastName);
            queryParameters.Add("@Password", user.Password);
            queryParameters.Add("@Email", user.Email);
            queryParameters.Add("@Gender", user.Gender);
            queryParameters.Add("@Phone", user.Phone);
            // queryParameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await WithConnection(async c => await c.ExecuteAsync(sql: _configuration.AddUser, param: queryParameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@email", email);
            return (await WithConnection(async c => await c.QueryAsync<User>(sql: _configuration.GetUser, param: queryParameters, commandType: CommandType.StoredProcedure)))?.ToList()?.FirstOrDefault();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var queryParameters = new DynamicParameters();

            return (await WithConnection(async c => await c.QueryAsync<User>(sql: _configuration.GetUsers, param: queryParameters, commandType: CommandType.StoredProcedure)));
        }
    }
}
