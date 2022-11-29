using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Users.Addresses
{
    using avras_v2.Domain.Entities.Users.Addresses;

    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .ToTable(nameof(City), nameof(Users));

            builder.Property((c) => c.Id)
                .ValueGeneratedNever();

            builder
               .Property((b) => b.Name)
               .HasMaxLength(60)
               .IsRequired()
               .IsUnicode(false);

            builder
                .HasIndex(e => e.UF);

            builder
                .Property(e => e.UF)
                .HasMaxLength(2)
                .IsFixedLength()
                .IsRequired()
                .IsUnicode(false);

            builder
                .HasOne(city => city.State)
                .WithMany(state => state.Cities)
                .HasForeignKey(c => c.UF);

            builder
                .Configure();
        }
    }
}
