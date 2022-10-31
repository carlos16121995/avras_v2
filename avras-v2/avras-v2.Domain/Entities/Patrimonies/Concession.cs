
namespace avras_v2.Domain.Entities.Patrimonies
{
    using avras_v2.Domain.Entities.Users;
    using avras_v2.Domain.Enuns.Patrimonies;

    public class Concession : BaseEntity<Guid>
    {
        public int PatrimonyId { get; set; }

        public Guid ApplicantId { get; set; }

        public DateTime ApplicationDate { get; set; }

        public string? RequestDetails { get; set; }

        public Guid? GrantorId { get; set; }

        public DateTime? GrantDate { get; set; }

        public string? GrantDetails { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int Amount { get; set; }

        public EPatrimonyStatus PatrimonyStatus { get; set; }


        public virtual Patrimony Patrimony { get; set; } = new();
        public virtual ApplicationUser Applicant { get; set; } = new();
        public virtual ApplicationUser Grantor { get; set; } = new();
    }
}
