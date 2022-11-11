using avras_v2.Domain.Entities.Financials;

namespace avras_v2.Domain.Entities.Sponsores
{
    public class Sponsor : BaseEntity<int>
    {
        public long ChargeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public decimal Amount { get; set; }
        public int Installments { get; set; }
        public string? Url { get; set; }
        public string? Descriptions { get; set; }

        public virtual Charge? Charge { get; set; }
    }
}
