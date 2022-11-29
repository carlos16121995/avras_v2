using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Financials
{
    using avras_v2.Domain.Entities.Financials;

    internal class CashControlConfiguration : IEntityTypeConfiguration<CashControl>
    {
        public void Configure(EntityTypeBuilder<CashControl> builder)
        {
            builder
                .ToTable(nameof(CashControl), nameof(Financials));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.OpenAmount)
                .IsRequired()
                .HasPrecision(18, 2);

            builder
                .Property(e => e.OpeningDate)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.ClosingAmount)
                .HasPrecision(18, 2);

            builder
                .Property((b) => b.Details)
                .HasMaxLength(256)
                .IsUnicode(false);

            builder
                .HasOne(cashControl => cashControl.UserOpening)
                .WithMany(user => user.OpeningCashierControl);

            builder
                .HasOne(cashControl => cashControl.UserClosing)
                .WithMany(user => user.ClosingCashierControl);

            builder
                .Configure();
        }
    }
}
