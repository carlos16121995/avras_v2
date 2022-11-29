using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Rents
{
    using avras_v2.Domain.Entities.Rents;

    internal class RentTypeConfiguration : IEntityTypeConfiguration<RentType>
    {
        public void Configure(EntityTypeBuilder<RentType> builder)
        {
            builder
                .ToTable(nameof(RentType), nameof(Rents));

            builder
               .Property((b) => b.Name)
               .IsRequired()
               .HasMaxLength(60)
               .IsUnicode(false);

            builder
                .Property(e => e.Price)
                .HasPrecision(18, 2);

            builder
                .Configure();
        }
    }
}
