using System;
using KnowledgeBase.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeBase.Server.Configurations
{
    public class ArticleEntityTypeConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Body).IsRequired();
            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Property(a => a.CategoryId).IsRequired();
            builder.Property(a => a.UserProfileDetailId).IsRequired();
        }
    }
}
