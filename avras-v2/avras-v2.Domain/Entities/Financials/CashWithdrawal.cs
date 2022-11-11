using avras_v2.Domain.Entities.Users;

namespace avras_v2.Domain.Entities.Financials
{
    public class CashWithdrawal : BaseEntity<int>
    {
        public long CashFlowId { get; set; }
        public Guid UserId { get; set; }
        public string Reason { get; set; } = string.Empty;

        public virtual CashFlow? CashFlow {get;set;}
        public virtual ApplicationUser? User {get;set;}
    }
}
