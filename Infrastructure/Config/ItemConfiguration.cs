using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");
            builder.Property(i => i.Category).IsRequired();
            builder.Property(i => i.Color).IsRequired();
            builder.Property(i => i.Quantity).IsRequired();
        }
    }
}