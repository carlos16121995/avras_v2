using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Users
{
    using avras_v2.Domain.Entities.Users;

    internal class AssociationTimeConfiguration : IEntityTypeConfiguration<AssociationTime>
    {
        public void Configure(EntityTypeBuilder<AssociationTime> builder)
        {
            builder
                .ToTable(nameof(AssociationTime), nameof(Users));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property(e => e.StartedAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.EndedAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .HasOne(associationTime => associationTime.User)
                .WithMany(user => user.AssociationsTime);

            builder
                .Configure();
        }
    }
}
