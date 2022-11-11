using avras_v2.Domain.Entities.Sales;
using avras_v2.Domain.Entities.Users;

namespace avras_v2.Domain.Entities.Financials
{
    public class CashControl : BaseEntity<int>
    {
        public Guid UserOpeningId { get; private set; }
        public Guid? UserClosingId { get; private set; }
        public decimal OpenAmount { get; private set; }
        public DateTime OpeningDate { get; private set; }
        public decimal? ClosingAmount { get; private set; }
        public DateTime? ClosingDate { get; private set; }
        public string? Details { get; private set; }

        public virtual ApplicationUser? UserOpening { get; set; }
        public virtual ApplicationUser? UserClosing { get; set; }
        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();

        public void OpenCashier(Guid userOpeningId, decimal openAmount, string? details)
        {
            UserOpeningId = userOpeningId;
            OpenAmount = openAmount;
            Details = details;
            OpeningDate = DateTime.UtcNow;
        }

        public void CloseCashier(Guid userClosingId, decimal closingAmount, string? details)
        {
            UserClosingId = userClosingId;
            ClosingAmount = closingAmount;
            Details = details;
            ClosingDate = DateTime.UtcNow;
        }
    }
}
