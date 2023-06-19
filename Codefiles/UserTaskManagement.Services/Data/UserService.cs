using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UserTaskManagement.Common.Repositories;
using UserTaskManagement.Services.Repositories;
using UserTaskManagement.Common.Models;

namespace UserTaskManagement.Services.Data
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository productRepository)
        {
            _userRepository = productRepository;
           
        }
        public async Task AddUser(User user)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    await _userRepository.AddUserAsync(user);
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    transaction.Complete();
                }

            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
           var user= await _userRepository.GetUserByEmail(email);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var user = await _userRepository.GetUsers();

            return user;
        }
    }
}
