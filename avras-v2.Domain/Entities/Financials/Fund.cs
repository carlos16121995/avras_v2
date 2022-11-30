namespace avras_v2.Domain.Entities.Financials
{
    public class Fund : BaseEntity<int>
    {
        public decimal Amount { get; private set; }

        public virtual ICollection<CashFlow> CashFlows { get; set; } = new HashSet<CashFlow>();

        public void UpdateValue(decimal amount)
        {
            Amount += amount;
            UpdateDate = DateTime.UtcNow;
        }
    }
}
