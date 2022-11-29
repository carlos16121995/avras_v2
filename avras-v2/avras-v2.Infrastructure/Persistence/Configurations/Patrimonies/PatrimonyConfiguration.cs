using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Patrimonies
{
    using avras_v2.Domain.Entities.Patrimonies;

    internal class PatrimonyConfiguration : IEntityTypeConfiguration<Patrimony>
    {
        public void Configure(EntityTypeBuilder<Patrimony> builder)
        {
            builder
                .ToTable(nameof(Patrimony), nameof(Patrimonies));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

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
                .Property(e => e.RefundAmount)
                .HasPrecision(18, 2);

            builder
               .Property(e => e.PurchaseValue)
               .HasPrecision(18, 2);

            builder
                .Property(e => e.AcquisitionDate)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.LossDate)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .HasOne(patrymony => patrymony.PatrimonyType)
                .WithMany(patrimonyType => patrimonyType.Patrimonies);

            builder
                .Configure();
        }
    }
}
