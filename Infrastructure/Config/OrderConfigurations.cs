using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderStatus) Enum.Parse(typeof(OrderStatus), o)
                );
            builder.Property(o => o.Cost).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasMany(o => o.Items).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}