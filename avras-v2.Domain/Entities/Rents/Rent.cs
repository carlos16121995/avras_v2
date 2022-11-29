using avras_v2.Domain.Entities.Financials;
using avras_v2.Domain.Entities.Users;
using avras_v2.Domain.Enuns.Rents;

namespace avras_v2.Domain.Entities.Rents
{
    public class Rent : BaseEntity<Guid>
    {
        public Guid ChargeId { get; set; }
        public Guid CustomerId { get; set; }
        public int RentTypeId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime? ApprovedIn { get; set; }
        public ERentStatus RentStatusId { get; set; }
        public string? Observation { get; set; }

        public virtual ApplicationUser? Customer { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual RentType? RentType { get; set; }
        public virtual Charge? Charge { get; set; }
    }
}
