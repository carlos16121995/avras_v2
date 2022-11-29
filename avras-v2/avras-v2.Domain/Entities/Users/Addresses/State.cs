namespace avras_v2.Domain.Entities.Users.Addresses
{
    public class State : BaseEntityWithoutId
    {
        public string Name { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
