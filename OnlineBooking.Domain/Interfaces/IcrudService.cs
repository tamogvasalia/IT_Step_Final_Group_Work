using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooking.Domain.Interfaces
{
    public interface IcrudService<T,K> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
