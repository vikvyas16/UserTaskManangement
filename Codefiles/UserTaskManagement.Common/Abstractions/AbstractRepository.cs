using UserTaskManagement.Common.Abstractions;
//using Contrado.Ecommerce.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserTaskManagement.Common.Abstractions
{
    public abstract class AbstractRepository<T> : IAbstractRepository<T> where T : ITransactionType
    {
       
        public abstract Task<ICollection<T>> GetAllAsync();


        public abstract Task<ICollection<T>> GetAsync(T hmsDomainEntity);


        public abstract Task<ICollection<T>> GetByIdAsync(int Id);


        public abstract Task<ICollection<T>> GetByIdAsync(long Id);

        public abstract Task<T> UpdateAsync(T cTransaction);
        public abstract Task<T> AddAsync(T cTransaction);
        public abstract Task<bool> DeleteAsync(T cTransaction);

    }




}
