using NewspapperAPI.Models.Entities.BlogEntities;

namespace NewspapperAPI.Models.Interfaces
{
    public interface IArticleService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        

    }
}


