using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Patrimonies
{
    using avras_v2.Domain.Entities.Patrimonies;

    internal class ConcessionConfiguration : IEntityTypeConfiguration<Concession>
    {
        public void Configure(EntityTypeBuilder<Concession> builder)
        {
            builder
                .ToTable(nameof(Concession), nameof(Patrimonies));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            builder
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();

            builder
               .Property((b) => b.RequestDetails)
               .HasMaxLength(256)
               .IsUnicode(false);

            builder
                .Property(e => e.GrantDate)
                .HasDefaultValueSql("GetUtcDate()");

            builder
               .Property((b) => b.GrantDetails)
               .HasMaxLength(256)
               .IsUnicode(false);

            builder
                .Property(e => e.DevolveDate)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.CanceledAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.DevolvedIn)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .HasOne(concession => concession.Applicant)
                .WithMany(user => user.Applicant);

            builder
                .HasOne(concession => concession.Grantor)
                .WithMany(user => user.Grant);

            builder
                .HasOne(concession => concession.Patrimony)
                .WithMany(patrimony => patrimony.Concessions);

            builder
                .Configure();
        }
    }
}
