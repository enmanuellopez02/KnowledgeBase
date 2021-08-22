using KnowledgeBase.Server.Configurations;
using KnowledgeBase.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeBase.Server.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserProfileEntityTypeConfiguration().Configure(modelBuilder.Entity<UserProfileDetail>());
            new ArticleEntityTypeConfiguration().Configure(modelBuilder.Entity<Article>());
            new CategoryEntityTypeConfiguration().Configure(modelBuilder.Entity<Category>());
            new FeedbackEntityTypeConfiguration().Configure(modelBuilder.Entity<Feedback>());
        }

        public DbSet<UserProfileDetail> UserProfiles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}