using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskManagement.Common.Models;

namespace UserTaskManagement.Services.Repositories
{
    public interface IUserRemainderServices
    {
        Task<IEnumerable<UserRemainder>> GetUserRemiderAsync(string email);
        Task AddUserRemider(UserRemainder userRemider);
    }
}
