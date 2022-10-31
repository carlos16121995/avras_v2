namespace avras_v2.Domain.Entities.Users
{
    public class AssociationTime : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ApplicationUser User { get; set; } = new();
    }
}
