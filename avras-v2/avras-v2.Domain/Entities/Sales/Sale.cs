using avras_v2.Domain.Entities.Financials;
using avras_v2.Domain.Entities.Users;

namespace avras_v2.Domain.Entities.Sales
{
    public class Sale : BaseEntity<Guid>
    {
        public Guid CashControlId { get; set; }
        public Guid ChargeId { get; set; }
        public Guid UserId { get; set; }
        public Guid? CostumerId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ApplicationUser? Customer { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual CashControl? CashControl { get; set; }
        public virtual Charge? Charge { get; set; }
        public virtual ICollection<SaleItems> SaleItems { get; set; } = new HashSet<SaleItems>();
    }
}
