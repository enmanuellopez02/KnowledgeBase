using KnowledgeBase.Server.Configurations;
using KnowledgeBase.Server.Models;
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
            new UserProfileEntityTypeConfiguration().Configure(modelBuilder.Entity<UserProfile>());
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}