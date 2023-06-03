using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
  public class ProductConfiguration : IEntityTypeConfiguration<Product>
  {
    public void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.Property(p => p.Id).IsRequired();
      builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
      builder.Property(p => p.Description).IsRequired().HasMaxLength(180);
      builder.Property(p => p.Care).IsRequired().HasMaxLength(180);
      builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
      builder.HasOne(b => b.ProductType).WithMany()
          .HasForeignKey(p => p.ProductTypeId);
      builder.HasOne(b => b.Pot).WithMany()
          .HasForeignKey(p => p.PotId);
      builder.HasOne(b => b.Images).WithMany()
          .HasForeignKey(p => p.ImagesId);
    }
  }
}