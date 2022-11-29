using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Products
{
    using avras_v2.Domain.Entities.Products;

    internal class ProductBuyConfiguration : IEntityTypeConfiguration<ProductBuy>
    {
        public void Configure(EntityTypeBuilder<ProductBuy> builder)
        {
            builder
                .ToTable(nameof(ProductBuy), nameof(Products));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.PurchaseValue)
                .HasPrecision(18, 2);

            builder
                .HasOne(productBuy => productBuy.Product)
                .WithMany(Product => Product.ProductsBuy);

            builder
                .Property(e => e.BoughtIn)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Configure();
        }
    }
}
