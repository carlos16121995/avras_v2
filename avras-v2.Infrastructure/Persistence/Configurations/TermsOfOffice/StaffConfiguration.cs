using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.TermsOfOffice
{
    using avras_v2.Domain.Entities.TermsOfOffice;

    internal class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder
                .ToTable(nameof(Staff), nameof(TermsOfOffice));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
               .Property((b) => b.Description)
               .HasMaxLength(120)
               .IsUnicode(false);

            builder
                .Property(e => e.StartedAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.EndedAt)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .HasOne(staff => staff.TermOfOffice)
                .WithMany(termOfOffice => termOfOffice.Staff);

            builder
                .HasOne(staff => staff.Title)
                .WithMany(title => title.Staff);

            builder
                .HasOne(staff => staff.User)
                .WithMany(user => user.Staff);

            builder
                .Configure();
        }
    }
}
