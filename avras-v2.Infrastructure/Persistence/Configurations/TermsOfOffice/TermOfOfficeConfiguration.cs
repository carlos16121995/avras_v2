using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.TermsOfOffice
{
    using avras_v2.Domain.Entities.TermsOfOffice;

    internal class TermOfOfficeConfiguration : IEntityTypeConfiguration<TermOfOffice>
    {
        public void Configure(EntityTypeBuilder<TermOfOffice> builder)
        {
            builder
                .ToTable(nameof(TermOfOffice), nameof(TermsOfOffice));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
               .Property((b) => b.Name)
               .HasMaxLength(60)
               .IsRequired()
               .IsUnicode(false);

            builder
               .Property((b) => b.Summary)
               .HasMaxLength(120)
               .IsUnicode(false);

            builder
               .Property((b) => b.UrlImage)
               .HasMaxLength(120)
               .IsUnicode(false);

            builder
                .Property(e => e.StartAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.EndAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Configure();
        }
    }
}
