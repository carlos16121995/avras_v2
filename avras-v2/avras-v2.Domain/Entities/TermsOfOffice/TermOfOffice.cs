namespace avras_v2.Domain.Entities.TermsOfOffice
{
    public class TermOfOffice : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Summary { get; set; }
        public string? UrlImage { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

        public virtual ICollection<Staff> Staff { get; set; } = new HashSet<Staff>();
    }
}
