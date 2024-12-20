using NewspapperAPI.Models.Entities.BlogEntities;

namespace NewspapperAPI.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? ProfileImageUrl { get; set; } = string.Empty;

    }
}
