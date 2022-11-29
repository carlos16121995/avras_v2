using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Financials
{
    using avras_v2.Domain.Entities.Financials;

    internal class ChargeConfiguration : IEntityTypeConfiguration<Charge>
    {
        public void Configure(EntityTypeBuilder<Charge> builder)
        {
            builder
                .ToTable(nameof(Charge), nameof(Financials));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            builder
               .Property((b) => b.Name)
               .IsRequired()
               .HasMaxLength(60)
               .IsUnicode(false);

            builder
               .Property((b) => b.Description)
               .HasMaxLength(256)
               .IsUnicode(false);

            builder
                .Property(e => e.DueDate)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.PaidAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.CanceledAt)
                .HasDefaultValueSql("GetUtcDate()");


            builder
                .HasOne(charge => charge.CashFlow)
                .WithOne(cashFlow => cashFlow.Charge);

            builder
                .Configure();
        }
    }
}
