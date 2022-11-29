using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Financials
{
using avras_v2.Domain.Entities.Financials;
    internal class FundConfiguration : IEntityTypeConfiguration<Fund>
    {
        public void Configure(EntityTypeBuilder<Fund> builder)
        {
            builder
                .ToTable(nameof(Fund), nameof(Financials));

            builder
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            builder
                .Configure();
        }
    }
}
