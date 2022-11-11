using avras_v2.Domain.Entities.Financials;
using avras_v2.Domain.Entities.Users;

namespace avras_v2.Domain.Entities.Sales
{
    public class Sale : BaseEntity<Guid>
    {
        public int CashControlId { get; set; }
        public long ChargeId { get; set; }
        public Guid UserId { get; set; }
        public Guid? CostumerId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ApplicationUser? Costumer { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual CashControl? CashControl { get; set; }
        public virtual Charge? Charge { get; set; }
    }
}
