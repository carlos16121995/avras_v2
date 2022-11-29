using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Sales
{
    using avras_v2.Domain.Entities.Sales;

    internal class SaleItemsConfiguration : IEntityTypeConfiguration<SaleItems>
    {
        public void Configure(EntityTypeBuilder<SaleItems> builder)
        {
            builder
                .ToTable(nameof(SaleItems), nameof(Sales));

            builder.HasKey(b => new { b.ProductId, b.SaleId });

            builder
               .Property(e => e.SaleValue)
               .HasPrecision(18, 2);

            builder
               .HasOne(rent => rent.Sale)
               .WithMany(sale => sale.SaleItems);

            builder
               .HasOne(rent => rent.Product)
               .WithMany(sale => sale.SaleItems);
        }
    }
}
