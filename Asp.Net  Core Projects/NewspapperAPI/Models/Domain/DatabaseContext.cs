using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NewspapperAPI.Models.Entities.BlogEntities;

namespace NewspapperAPI.Models.Domain
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){}
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Share> Shares { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    builder.Entity<User_Article>().HasOne(a => a.Article)
        //        .WithMany(u => u.User_Article).HasForeignKey(at => at.Article);
        //}

    }
}
