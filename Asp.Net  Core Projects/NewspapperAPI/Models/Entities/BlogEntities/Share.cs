using System.ComponentModel.DataAnnotations.Schema;

namespace NewspapperAPI.Models.Entities.BlogEntities
{
    public class Share
    {
            public Guid ShareId { get; set; }
            public bool Shared { get; set; }
            public DateTime SharedOn { get; set; }


            [ForeignKey("Article")]
            public Guid ArticleId { get; set; }
            public Article Article { get; set; }
    }
}
