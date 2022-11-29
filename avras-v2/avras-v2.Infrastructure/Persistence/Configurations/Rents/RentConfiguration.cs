using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Rents
{
    using avras_v2.Domain.Entities.Rents;
    internal class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder
                .ToTable(nameof(Rent), nameof(Rents));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.BookingDate)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.CanceledAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.ApprovedIn)
                .HasDefaultValueSql("GetUtcDate()");

            builder
               .Property((b) => b.Observation)
               .HasMaxLength(256)
               .IsUnicode(false);

            builder
               .HasOne(rent => rent.Customer)
               .WithMany(user => user.RentalRequests);

            builder
                .HasOne(rent => rent.User)
                .WithMany(user => user.Rents);

            builder
                .HasOne(rent => rent.Charge)
                .WithOne(charge => charge.Rent);

            builder
                .HasOne(rent => rent.RentType)
                .WithMany(user => user.Rents);

            builder
                .Configure();
        }
    }
}
