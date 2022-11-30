using Microsoft.AspNetCore.Identity;

namespace avras_v2.Domain.Entities.Users
{
    using avras_v2.Domain.Entities.Financials;
    using avras_v2.Domain.Entities.Patrimonies;
    using avras_v2.Domain.Entities.Rents;
    using avras_v2.Domain.Entities.Sales;
    using avras_v2.Domain.Entities.TermsOfOffice;
    using avras_v2.Domain.Entities.Users.Addresses;
    using avras_v2.Domain.Enuns.Users;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? CPF { get; set; }
        public string? Information { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DateAcceptedTermUse { get; set; }
        public DateTime? ExpirationDatePassword { get; set; }
        public int? CodigoAlteracaoSenha { get; set; }
        public EUserType UserType { get; private set; }
        private bool Activated { get; set; } = true;
        private bool Deleted { get; set; } = false;
        public DateTime UpdateAt { get; set; }
        public DateTime CreatedAt { get; set; }


        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public virtual ICollection<AssociationTime> AssociationsTime { get; set; } = new HashSet<AssociationTime>();
        public virtual ICollection<Concession> Grant { get; set; } = new HashSet<Concession>();
        public virtual ICollection<Concession> Applicant { get; set; } = new HashSet<Concession>();
        public virtual ICollection<Staff> Staff { get; set; } = new HashSet<Staff>();
        public virtual ICollection<CashWithdrawal> CashWithdrawal { get; set; } = new HashSet<CashWithdrawal>();
        public virtual ICollection<Sale> Purchases { get; set; } = new HashSet<Sale>();
        public virtual ICollection<Sale> Sales { get; set; } = new HashSet<Sale>();
        public virtual ICollection<CashControl> OpeningCashierControl { get; set; } = new HashSet<CashControl>();
        public virtual ICollection<CashControl> ClosingCashierControl { get; set; } = new HashSet<CashControl>();
        public virtual ICollection<Rent> Rents { get; set; } = new HashSet<Rent>();
        public virtual ICollection<Rent> RentalRequests { get; set; } = new HashSet<Rent>();

        public virtual void Delete()
        {
            Activated = false;
            Deleted = true;
            UpdateAt = DateTime.UtcNow;
        }
        public virtual void Inactivate()
        {
            Activated = !Activated;
            UpdateAt = DateTime.UtcNow;
        }

        public void UpdateUserType(EUserType userType)
        {
            var date = DateTime.UtcNow;

            if (UserType.HasFlag(EUserType.ASSOCIATE) && !userType.HasFlag(EUserType.ASSOCIATE)) // Finaliza sociedade
            {
                var associationTime = AssociationsTime.Last();
                associationTime.EndAssociation(date);
            }

            if (!UserType.HasFlag(EUserType.ASSOCIATE) && userType.HasFlag(EUserType.ASSOCIATE)) // Inicia sociedade
            {
                var associationTime = new AssociationTime();
                associationTime.StartAssociation(date);
                AssociationsTime.Add(associationTime);
            }

            UserType = userType;
        }
    }
}
