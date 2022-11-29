namespace avras_v2.Domain.Entities.Patrimonies
{
    public class PatrimonyType : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public virtual ICollection<Patrimony> Patrimonies { get; set; } = new HashSet<Patrimony>();
    }
}
