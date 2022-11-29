using avras_v2.Domain.Entities.Users;

namespace avras_v2.Domain.Entities.TermsOfOffice
{
    public class Staff : BaseEntity<Guid>
    {
        public Guid TermOfOfficeId { get; set; }
        public Guid TitleId { get; set; }
        public Guid UserId { get; set; }
        public string? Description { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        public virtual TermOfOffice? TermOfOffice { get; set; }
        public virtual Title? Title { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
