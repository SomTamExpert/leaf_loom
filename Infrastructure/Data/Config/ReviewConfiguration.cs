using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Rating).IsRequired();
            builder.Property(p => p.Comment).IsRequired().HasMaxLength(180);
            builder.HasOne(b => b.Product).WithMany()
                .HasForeignKey(p => p.ProductId);
        }
    }
}