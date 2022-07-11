using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T :class,IEntityBase,new()
    {   // generic repository interface that contains declaration of all methods that perform Crud Operation 
        Task<IEnumerable<T>> GetAllAsync();
        Task <IEnumerable<T>> GetAllAsync(params Expression<Func<T,object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
