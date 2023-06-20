using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Common.Models;

namespace UserTaskManagement.Common.Repositories
{
    public interface IUserRemainder
    {
        Task AddUserRemiderAsync(UserRemainder user);

        Task<IEnumerable<UserRemainder>> GetUserRemider(string userId);
    }
}
