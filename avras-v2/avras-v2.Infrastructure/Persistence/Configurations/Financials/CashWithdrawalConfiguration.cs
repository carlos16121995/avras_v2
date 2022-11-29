using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace avras_v2.Infrastructure.Persistence.Configurations.Financials
{
    using avras_v2.Domain.Entities.Financials;
 
    internal class CashWithdrawalConfiguration : IEntityTypeConfiguration<CashWithdrawal>
    {
        public void Configure(EntityTypeBuilder<CashWithdrawal> builder)
        {
            builder
                .ToTable(nameof(CashWithdrawal), nameof(Financials));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
               .Property((b) => b.Reason)
               .IsRequired()
               .HasMaxLength(256)
               .IsUnicode(false);

            builder
                .HasOne(cashWithdrawal => cashWithdrawal.User)
                .WithMany(user => user.CashWithdrawal);

            builder
                .HasOne(cashWithdrawal => cashWithdrawal.CashFlow)
                .WithOne(cashFlow => cashFlow.CashWithdrawal);

            builder
                .Configure();
        }
    }
}
