using System;
using KnowledgeBase.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KnowledgeBase.Server.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);

            builder.HasData(
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Pay"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Order"
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Invoice"
                }
            );
        }
    }
}
