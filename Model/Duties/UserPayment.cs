using Entity.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Duties
{
    public class UserPayment : BaseEntityClass
    {
        public int UserId { get; set; }
        public long Amount { get; set; }
        public DateTime DfDate { get; set; }
        public virtual User User { get; set; }
    }
}
