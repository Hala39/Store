using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.NewPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Description).IsRequired().HasMaxLength(150);
            builder.Property(p => p.EntryYear).IsRequired();
            builder.Property(p => p.EntryMonth).IsRequired();
            builder.Property(p => p.EntryDay).IsRequired();
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.Property(p => p.Offer).IsRequired();
            builder.HasOne(c => c.Category).WithMany()
                .HasForeignKey(p => p.CategoryId);
        }


    }
}