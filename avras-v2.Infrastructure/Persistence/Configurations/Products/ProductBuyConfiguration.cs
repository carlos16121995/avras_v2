using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Products
{
    using avras_v2.Domain.Entities.Products;

    internal class ProductBuyConfiguration : IEntityTypeConfiguration<ProductPurchase>
    {
        public void Configure(EntityTypeBuilder<ProductPurchase> builder)
        {
            builder
                .ToTable(nameof(ProductPurchase), nameof(Products));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.PurchaseValue)
                .HasPrecision(18, 2);

            builder
                .HasOne(productBuy => productBuy.Product)
                .WithMany(Product => Product.ProductsPurchases);

            builder
                .Property(e => e.BoughtIn)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Configure();
        }
    }
}
