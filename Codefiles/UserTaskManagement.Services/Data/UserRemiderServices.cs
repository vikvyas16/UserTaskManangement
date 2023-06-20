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
    public class UserRemainderServices : IUserRemainderServices
    {

        private readonly IUserRemainder _userRemainderRepository;

        public UserRemainderServices(IUserRemainder userRemiander)
        {
            _userRemainderRepository = userRemiander;

        }
        public async Task AddUserRemider(UserRemainder userRemider)
        {
            await _userRemainderRepository.AddUserRemiderAsync(userRemider);
        }

        public async Task<IEnumerable<UserRemainder>> GetUserRemiderAsync(string userId)
        {
           return await _userRemainderRepository.GetUserRemider(userId);
        }
    }
}
