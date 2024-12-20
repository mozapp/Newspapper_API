using NewspapperAPI.Models.Entities.BlogEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewspapperAPI.Models.Entities.BlogEntities
{
    public class Like
    {
        public Guid LikeId { get; set; }
        public bool Liked { get; set; }
        public string UserName { get; set; }


        [ForeignKey("Article")]
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
    }
}