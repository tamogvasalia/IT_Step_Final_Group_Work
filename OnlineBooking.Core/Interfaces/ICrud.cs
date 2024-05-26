using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Interfaces
{
    public interface ICrud<T,K> where T:class // first for   class type and second for primary key
    {
        Task AddAsync(T entity);
        Task DeleteAsync(K id);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
