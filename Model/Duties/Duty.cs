using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Duties
{
    public class Duty : BaseEntityClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Cost { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
