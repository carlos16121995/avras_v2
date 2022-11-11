namespace avras_v2.Domain.Entities.Rents
{
    public class RentType : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } 

        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();
    }
}
