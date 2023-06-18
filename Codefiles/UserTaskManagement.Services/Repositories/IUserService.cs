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
        //Task<Product> GetProductByIdAsync(int id);
        //Task<IEnumerable<Category>> GetProductCategoryAsync();
        Task AddUser(User user);
    }
}
