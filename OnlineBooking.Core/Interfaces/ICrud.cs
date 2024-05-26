namespace OnlineStore.Core.Interfaces
{
    public interface ICrud<T,K> where T:class // first for   class type and second for primary key
    {
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
