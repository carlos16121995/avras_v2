namespace avras_v2.Domain.Entities.Patrimonies
{
    public class Patrimony : BaseEntity<Guid>
    {
        public int PatrimonyTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Amount { get; set; }
        
        public decimal RefundAmount { get; set; }

        public decimal PurchaseValue { get; set; }

        public bool Availability { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime? LossDate { get; set; }



        public virtual PatrimonyType PatrimonyType { get; set; } = new();
        public virtual ICollection<Concession> Concessions { get; set; } = new HashSet<Concession>();
    }
}
