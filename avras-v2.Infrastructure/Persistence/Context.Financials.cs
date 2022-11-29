using avras_v2.Domain.Entities.Financials;
using Microsoft.EntityFrameworkCore;

namespace avras_v2.Infrastructure.Persistence
{
    public partial class Context
    {
        public virtual DbSet<CashControl> CashControls { get; set; } = null!;
        public virtual DbSet<CashFlow> CashFlows { get; set; } = null!;
        public virtual DbSet<CashWithdrawal> CashWithdrawals { get; set; } = null!;
        public virtual DbSet<Charge> Charges { get; set; } = null!;
        public virtual DbSet<Fund> Funds { get; set; } = null!;
    }
}
