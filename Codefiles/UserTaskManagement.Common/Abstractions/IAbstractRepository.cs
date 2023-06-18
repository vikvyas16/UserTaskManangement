using UserTaskManagement.Common.Abstractions;
//using Contrado.Ecommerce.DataAccess.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserTaskManagement.Common.Abstractions
{
    public interface IAbstractRepository<T> where T : ITransactionType
    {
        Task<ICollection<T>> GetByIdAsync(int Id);
        Task<ICollection<T>> GetByIdAsync(long Id);
        Task<ICollection<T>> GetAsync(T DomainEntity);
        Task<ICollection<T>> GetAllAsync();
        Task<T> UpdateAsync(T cTransaction);
        Task<T> AddAsync(T cTransaction);
        Task<bool> DeleteAsync(T cTransaction);
    }
}
