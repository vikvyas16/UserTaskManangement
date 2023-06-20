using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using UserTaskManagement.Common.Abstractions;
using UserTaskManagement.Common.Configuration;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Common.Repositories;

namespace UserTaskManangement.DataAccess.Data
{
    public class UserRemiderRepository : AsyncDbRepository, IUserRemainder
    {

        private readonly IAppSetting _configuration;

        public UserRemiderRepository(
           IAppSetting configuration,
           IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
            if (connectionFactory == null) throw new ArgumentNullException(nameof(connectionFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async  Task AddUserRemiderAsync(UserRemainder user)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@RemiderMessage ", user.RemainderMessage);
            queryParameters.Add("@RemiderDate", user.RemainderDate);
            queryParameters.Add("@UserId", user.UserId);
            queryParameters.Add("@MessageActive", user.MessageActive);
            // queryParameters.Add("@id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await WithConnection(async c => await c.ExecuteAsync(sql: _configuration.AddUserRemider, param: queryParameters, commandType: CommandType.StoredProcedure));
        }

        public async  Task<IEnumerable<UserRemainder>> GetUserRemider(string userId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@UserId ", userId);

            return (await WithConnection(async c => await c.QueryAsync<UserRemainder>(sql: _configuration.getUserRemider, param: queryParameters, commandType: CommandType.StoredProcedure)));
        }
    }
}
