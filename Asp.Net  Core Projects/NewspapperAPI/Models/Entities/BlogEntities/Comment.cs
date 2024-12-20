using NewspapperAPI.Models.Entities.BlogEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewspapperAPI.Models.Entities.BlogEntities
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Text { get; set; }

        [ForeignKey("Article")]
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}