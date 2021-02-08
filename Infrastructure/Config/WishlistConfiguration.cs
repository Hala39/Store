using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class WishlistConfiguration : IEntityTypeConfiguration<Wish>
    {
        public void Configure(EntityTypeBuilder<Wish> builder)
        {
            builder.Property(i => i.Price).HasColumnType("decimal(18,2)");
            builder.Property(i => i.OPrice).HasColumnType("decimal(18,2)");
            builder.Property(i => i.Category).IsRequired();
        }
    }
}