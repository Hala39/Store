using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}