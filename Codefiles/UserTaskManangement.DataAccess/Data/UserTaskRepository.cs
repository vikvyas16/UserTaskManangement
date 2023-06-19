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
    public class UserTaskRepository : AsyncDbRepository,IUserTaskRepository
    {

        private readonly IAppSetting _configuration;

        public UserTaskRepository(
           IAppSetting configuration,
           IDbConnectionFactory connectionFactory) : base(connectionFactory)
        {
            if (connectionFactory == null) throw new ArgumentNullException(nameof(connectionFactory));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task AddUserTaskAsync(UserTask user)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@TaskTile", user.TaskTitle);
            queryParameters.Add("@DueDate", user.DueDate);
            queryParameters.Add("@comment", user.Comment);
            queryParameters.Add("@AssineeId", user.AssigneeId);
            queryParameters.Add("@CeratedBy", user.CreatedBy);
            queryParameters.Add("@TaskStatus", user.TaskStatus);
            queryParameters.Add("@TaskPriority", user.TaskPriority);
            await WithConnection(async c => await c.ExecuteAsync(sql: _configuration.AddUserTask, param: queryParameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<IEnumerable<UserTask>> GetUsersTask(string userId)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Id", userId);
            var userTaskList= (await WithConnection(async c => await c.QueryAsync<UserTask>(sql: _configuration.GetUserTask, param: queryParameters, commandType: CommandType.StoredProcedure)));
            return userTaskList;
        }
    }
}
