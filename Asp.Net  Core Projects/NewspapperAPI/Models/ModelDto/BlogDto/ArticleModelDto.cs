using System.ComponentModel.DataAnnotations;

namespace NewspapperAPI.Models.ModelDto.BlogDto
{
    public class ArticleModelDto
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(9000)]
        public string Body { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Today;
        
        [Required]
        public string Author { get; set; }
    }
}
