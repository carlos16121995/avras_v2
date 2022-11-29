using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Products
{
    using avras_v2.Domain.Entities.Products;

    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .ToTable(nameof(Product), nameof(Products));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
               .Property((b) => b.Name)
               .IsRequired()
               .HasMaxLength(60)
               .IsUnicode(false);

            builder
                .Property(e => e.SaleValue)
                .HasPrecision(18, 2);

            builder
                .HasOne(product => product.ProductCategory)
                .WithMany(productType => productType.Products);

            builder
                .Configure();
        }
    }
}
