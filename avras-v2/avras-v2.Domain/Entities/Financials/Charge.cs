using avras_v2.Domain.Entities.Rents;
using avras_v2.Domain.Entities.Sales;
using avras_v2.Domain.Enuns.Financials;

namespace avras_v2.Domain.Entities.Financials
{
    public class Charge : BaseEntity<long>
    {
        public long? CashFlowId { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? CanceledAt { get; set; }
        public EChargeStatus ChargeStatusId { get; set; }  
        public EChargeType EChargeTypeId { get; set; }  



        public virtual CashFlow? CashFlow { get; set; }
        public virtual Sale? Sale { get; set; } 
        public virtual Rent? Rent { get; set; } 
    }
}
