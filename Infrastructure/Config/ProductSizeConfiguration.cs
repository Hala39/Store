using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.Property(ps => ps.ProductId).IsRequired();
            builder.Property(ps => ps.SizeId).IsRequired();
            builder.HasKey(ps => new {
                ps.ProductId, ps.SizeId
            });
        }
    }
}