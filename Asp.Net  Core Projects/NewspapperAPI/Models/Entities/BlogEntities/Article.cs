namespace NewspapperAPI.Models.Entities.BlogEntities
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; }=string.Empty;
        public DateTime PublishedOn { get; set; }
        public string Author { get; set; }
        
    }
}

