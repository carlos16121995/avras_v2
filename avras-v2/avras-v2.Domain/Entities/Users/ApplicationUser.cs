using Microsoft.AspNetCore.Identity;

namespace avras_v2.Domain.Entities.Users
{
    using avras_v2.Domain.Entities.Patrimonies;
    using avras_v2.Domain.Entities.Users.Addresses;
    using avras_v2.Domain.Enuns.Users;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? CPF { get; set; }
        public DateTime? Birthdate { get; set; }
        private EUserType UserType { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public virtual ICollection<AssociationTime> AssociationsTime { get; set; } = new HashSet<AssociationTime>();
        public virtual ICollection<Concession> Grant { get; set; } = new HashSet<Concession>();
        public virtual ICollection<Concession> Applicant { get; set; } = new HashSet<Concession>();

        public void UpdateUserType(EUserType userType)
        {
            var date = DateTime.UtcNow;

            if (UserType.HasFlag(EUserType.ASSOCIATE) && !userType.HasFlag(EUserType.ASSOCIATE)) // Finaliza sociedade
            {
                var associationTime = AssociationsTime.Last();
                associationTime.EndDate = date;
                associationTime.UpdateDate = date;
            }

            if (!UserType.HasFlag(EUserType.ASSOCIATE) && userType.HasFlag(EUserType.ASSOCIATE)) // Inicia sociedade
                AssociationsTime.Add(new()
                {
                    StartDate = date,
                    UpdateDate = date,
                });

            UserType = userType;
        }
    }
}
