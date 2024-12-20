namespace NewspapperAPI.Repository.Services
{
    public class ArticleService<T> : IArticleService<T> where T : class
    {
        private readonly DatabaseContext _databaseContext;
        private readonly DbSet<T> _dbSet;

        public ArticleService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task AddAsync(T entityAdd)
        {
            await _dbSet.AddAsync(entityAdd);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _databaseContext.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
