namespace avras_v2.Domain.Entities.Users
{
    public class AssociationTime : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }

        public virtual ApplicationUser? User { get; set; }
    }
}
