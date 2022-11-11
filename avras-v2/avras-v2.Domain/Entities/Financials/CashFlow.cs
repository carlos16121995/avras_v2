namespace avras_v2.Domain.Entities.Financials
{
    public class CashFlow : BaseEntity<long>
    {
        public int FundId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public virtual CashWithdrawal? CashWithdrawal { get; set; }
        public virtual Charge? Charge { get; set; }
        public virtual Fund? Fund { get; set; }

        public void GenerateCashFlow(Fund fund, decimal amount)
        {
            Fund = fund;
            FundId = fund.Id;
            Amount = amount;
            CreatedAt = DateTime.UtcNow;
            Fund.UpdateValue(amount);
        }
    }
}