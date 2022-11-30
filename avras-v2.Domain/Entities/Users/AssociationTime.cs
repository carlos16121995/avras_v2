namespace avras_v2.Domain.Entities.Users
{
    public class AssociationTime : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime StartedAt { get; private set; }
        public DateTime? EndedAt { get; private set; }

        public void StartAssociation(DateTime startedAt)
        {
            StartedAt = startedAt;
            UpdateAt = DateTime.UtcNow;
        }
        public void EndAssociation(DateTime endedAt)
        {
            EndedAt = endedAt;
            UpdateAt = DateTime.UtcNow;
        }

        public virtual ApplicationUser? User { get; set; }
    }
}
