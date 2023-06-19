using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Common.Models;

namespace UserTaskManagement.Services.Repositories
{
    public interface IUserTaskService
    {
        //Task<User> GetUserTaskByID(string userID);
        //Task<IEnumerable<Category>> GetProductCategoryAsync();
        Task AddUserTask(UserTask userTask);
        Task<List<UserTask>> GetUserTaskByUserID(string userId);
    }
}
