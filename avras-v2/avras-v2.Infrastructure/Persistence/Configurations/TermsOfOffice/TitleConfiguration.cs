using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.TermsOfOffice
{
    using avras_v2.Domain.Entities.TermsOfOffice;

    internal class TitleConfiguration : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> builder)
        {
            builder
                .ToTable(nameof(Title), nameof(TermsOfOffice));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
               .Property((b) => b.Name)
               .HasMaxLength(60)
               .IsRequired()
               .IsUnicode(false);

            builder
               .Property((b) => b.Description)
               .HasMaxLength(120)
               .IsUnicode(false);

            builder
                .Configure();
        }
    }
}
