using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Patrimonies
{
    using avras_v2.Domain.Entities.Patrimonies;
    
    internal class PatrimonyTypeConfiguration : IEntityTypeConfiguration<PatrimonyType>
    {
        public void Configure(EntityTypeBuilder<PatrimonyType> builder)
        {
            builder
                .ToTable(nameof(PatrimonyType), nameof(Patrimonies));

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
                .Configure();
        }
    }
}
