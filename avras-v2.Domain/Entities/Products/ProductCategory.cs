namespace avras_v2.Domain.Entities.Products
{
    public class ProductCategory : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Url { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
