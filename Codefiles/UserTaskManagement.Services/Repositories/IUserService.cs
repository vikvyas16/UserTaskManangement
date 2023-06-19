using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Common.Models;

namespace UserTaskManagement.Services.Repositories
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
        //Task<IEnumerable<Category>> GetProductCategoryAsync();
        Task AddUser(User user);
        Task<IEnumerable<User>> GetUsers();
    }
}
