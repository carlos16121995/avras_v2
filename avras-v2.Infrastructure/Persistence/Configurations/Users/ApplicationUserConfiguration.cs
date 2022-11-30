using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Users
{
    using avras_v2.Domain.Entities.Users;

    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder
                .ToTable(nameof(ApplicationUser), nameof(Users));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .HasIndex(e => e.NormalizedEmail, "EmailIndex")
                .IsUnique();

            builder
                .HasIndex(e => e.Email, "IX_ApplicationUser_Email")
                .IsUnique()
                .HasFilter("([Email] IS NOT NULL)");

            builder
                .HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique();

            builder
                .Property(e => e.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            builder
               .Property(e => e.AccessToken)
               .HasMaxLength(50)
               .IsUnicode(false);

            builder
                .Property((e) => e.UpdateAt)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.DateAcceptedTermUse)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.ExpirationDatePassword)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.BirthDate)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(false);

            builder
                .Property(e => e.PasswordHash)
                .IsRequired()
                .HasMaxLength(2000)
                .IsUnicode(false);

            builder
                .Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(16)
                .IsUnicode(false);

            builder
                .Property(e => e.SecurityStamp)
                .IsRequired()
                .HasMaxLength(64)
                .IsUnicode(false);
        }
    }
}
