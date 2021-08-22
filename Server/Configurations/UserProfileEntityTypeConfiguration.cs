using System;
using KnowledgeBase.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeBase.Server.Configurations
{
    public class UserProfileEntityTypeConfiguration : IEntityTypeConfiguration<UserProfileDetail>
    {
        public void Configure(EntityTypeBuilder<UserProfileDetail> builder)
        {
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.City).IsRequired();
            builder.Property(u => u.Country).IsRequired();
            builder.Property(u => u.CreateSince).HasDefaultValue(DateTime.UtcNow);
        }
    }
}
