using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Common.Models;

namespace UserTaskManagement.Common.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task<User> GetUserByEmail(string email);

        Task<IEnumerable<User>> GetUsers();
    }
}
