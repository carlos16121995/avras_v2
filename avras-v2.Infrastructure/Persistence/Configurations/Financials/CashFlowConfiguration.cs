using avras_v2.Domain.Entities.Financials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Financials
{
    internal class CashFlowConfiguration : IEntityTypeConfiguration<CashFlow>
    {
        public void Configure(EntityTypeBuilder<CashFlow> builder)
        {
            builder
                .ToTable(nameof(CashFlow), nameof(Financials));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            builder
                .Configure();
        }
    }
}
