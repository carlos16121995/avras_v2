using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Sponsores
{
    using avras_v2.Domain.Entities.Sponsores;

    internal class SponsorConfiguration : IEntityTypeConfiguration<Sponsor>
    {
        public void Configure(EntityTypeBuilder<Sponsor> builder)
        {
            builder
                .ToTable(nameof(Sponsor), nameof(Sponsores));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
               .Property((b) => b.Name)
               .IsRequired()
               .HasMaxLength(60)
               .IsUnicode(false);

            builder
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            builder
               .Property((b) => b.Url)
               .HasMaxLength(60)
               .IsUnicode(false);


            builder
               .Property((b) => b.Descriptions)
               .HasMaxLength(60)
               .IsUnicode(false);

            builder
                .HasOne(sponsor => sponsor.Charge)
                .WithOne(charge => charge.Sponsor);

            builder
                .Configure();
        }
    }
}
