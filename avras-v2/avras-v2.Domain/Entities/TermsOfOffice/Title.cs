namespace avras_v2.Domain.Entities.TermsOfOffice
{
    public class Title : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public virtual ICollection<Staff> Staff { get; set; } = new HashSet<Staff>();
    }
}
