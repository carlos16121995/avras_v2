using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avras_v2.Domain.Entities.Patrimonies
{
    public class Patrimony : BaseEntity<int>
    {
        public int PatrimonyTypeId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Amount { get; set; }
        
        public decimal SaleValue { get; set; }

        public decimal PurchaseValue { get; set; }

        public bool Availability { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public DateTime? LossDate { get; set; }

        public virtual PatrimonyType PatrimonyType { get; set; } = new();
    }
}
