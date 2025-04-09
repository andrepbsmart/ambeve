using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ItemSaleConfiguration : IEntityTypeConfiguration<ItemSale>
{
    public void Configure(EntityTypeBuilder<ItemSale> builder)
    {
        builder.ToTable("ItemsSales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.HasKey(e => new { e.SaleID, e.ProductID });

        builder.Property(e => e.ProductName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Quantity).IsRequired();
        builder.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(e => e.Discount).HasColumnType("decimal(18,2)");

        builder.Ignore(e => e.Total);

        builder.HasOne(e => e.Sale)
              .WithMany(s => s.Items)
              .HasForeignKey(e => e.SaleID)
              .OnDelete(DeleteBehavior.Cascade);
    }
}
