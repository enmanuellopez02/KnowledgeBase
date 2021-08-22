using System;
using KnowledgeBase.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeBase.Server.Configurations
{
    public class FeedbackEntityTypeConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.Property(f => f.Helpful).IsRequired();
            builder.Property(f => f.Comments).IsRequired();
            builder.Property(f => f.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Property(f => f.ArticleId).IsRequired();
            builder.Property(f => f.UserProfileDetailId).IsRequired();
        }
    }
}
