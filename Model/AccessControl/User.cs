using Entity.Duties;
using System.Collections.Generic;

namespace Entity.AccessControl
{
    public class User : BaseEntityClass
    {
        public User()
        {
            Personal = new Personal();
        }
        public int PersonalId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Salary { get; set; }

        public int UserType { get; set; }

        public virtual Personal Personal { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }

        public virtual ICollection<UserPayment> UserPayments { get; set; }
    }
}
