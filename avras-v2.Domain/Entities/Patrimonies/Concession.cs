
namespace avras_v2.Domain.Entities.Patrimonies
{
    using avras_v2.Domain.Entities.Users;
    using avras_v2.Domain.Enuns.Patrimonies;
    using System.Runtime.InteropServices;

    public class Concession : BaseEntity<Guid>
    {
        public Guid PatrimonyId { get; set; }
        public Guid ApplicantId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? RequestDetails { get; set; }
        public Guid? GrantorId { get; set; }
        public DateTime? GrantDate { get; set; }
        public string? GrantDetails { get; set; }
        public DateTime DevolveDate { get; set; }
        public DateTime? CanceledAt { get; set; }
        public DateTime? DevolvedIn { get; set; }
        public int Amount { get; set; }
        public EPatrimonyStatus PatrimonyStatus { get; set; }


        public virtual Patrimony? Patrimony { get; set; }
        public virtual ApplicationUser? Applicant { get; set; }
        public virtual ApplicationUser? Grantor { get; set; }
    }
}
