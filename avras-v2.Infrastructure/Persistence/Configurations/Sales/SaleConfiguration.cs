using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Sales
{
    using avras_v2.Domain.Entities.Sales;

    internal class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
                .ToTable(nameof(Sale), nameof(Sales));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.CreatedDate)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();

            builder
               .HasOne(rent => rent.Customer)
               .WithMany(user => user.Purchases);

            builder
                .HasOne(rent => rent.User)
                .WithMany(user => user.Sales);

            builder
                .HasOne(sale => sale.CashControl)
                .WithMany(cashControl => cashControl.Sales)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(sale => sale.Charge)
                .WithOne(charge => charge.Sale);

            builder
                .Configure();
        }
    }
}
