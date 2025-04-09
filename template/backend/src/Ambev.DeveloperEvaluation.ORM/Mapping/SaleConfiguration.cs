using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.SaleNumber).IsRequired();
        builder.Property(u => u.Date).IsRequired();
        builder.Property(u => u.CustomerID).IsRequired().HasMaxLength(40);
        builder.Property(u => u.CustomerName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.BranchID).IsRequired().HasMaxLength(40);
        builder.Property(u => u.BranchName).IsRequired().HasMaxLength(100);
        builder.Property(s => s.IsCancelled).IsRequired();
        builder.Property(s => s.CancelledAt);

        builder.Ignore(s => s.TotalAmount);

        builder.Metadata
            .FindNavigation(nameof(Sale.Items))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasMany(typeof(ItemSale), "_items")
            .WithOne("Sale")
            .HasForeignKey("SaleID")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
