using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Common.Models;
using UserTaskManagement.Common.Repositories;
using UserTaskManagement.Services.Repositories;

namespace UserTaskManagement.Services.Data
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUserTaskRepository _userTaskRepository;

        public UserTaskService(IUserTaskRepository userTaskRepository)
        {
            _userTaskRepository = userTaskRepository;

        }
        public async Task AddUserTask(UserTask userTask)
        {
           await  _userTaskRepository.AddUserTaskAsync(userTask);
        }

        public async Task<List<UserTask>> GetUserTaskByUserID(string userId)
        {
           var userTask= await _userTaskRepository.GetUsersTask(userId);
            return userTask.ToList();
        }
    }
}
