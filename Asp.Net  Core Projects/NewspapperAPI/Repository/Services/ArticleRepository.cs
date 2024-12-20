using NewspapperAPI.Models.Entities.BlogEntities;
using NewspapperAPI.Models.Interfaces;

namespace NewspapperAPI.Repository.Services
{
    public interface IArticleRepository : IArticleService<Article>
    {
        // Add custom methods if needed
    }



    public class ArticleRepository : ArticleService<Article>, IArticleRepository
    {
        public ArticleRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }


}
