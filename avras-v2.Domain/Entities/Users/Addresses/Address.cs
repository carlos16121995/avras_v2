namespace avras_v2.Domain.Entities.Users.Addresses
{
    public class Address : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }

        public int CityId { get; set; }

        public string? ZipCode { get; set; }

        public string Street { get; set; } = string.Empty;

        public string Neighborhood { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string? Complement { get; set; } = string.Empty;

        public virtual ApplicationUser? User { get; set; }

        public virtual City? City { get; set; }
    }
}
