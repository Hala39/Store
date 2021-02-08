using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> builder)
        {
            builder.Property(pc => pc.ColorId).IsRequired();
            builder.Property(pc => pc.ProductId).IsRequired();
            builder.HasKey(pc => new {
                pc.ProductId, pc.ColorId
            });
        }
    }
}