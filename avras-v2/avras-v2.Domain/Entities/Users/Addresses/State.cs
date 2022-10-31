using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avras_v2.Domain.Entities.Users.Addresses
{
    public class State : BaseEntitWithoutId
    {
        public string Name { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
