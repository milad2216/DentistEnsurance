using Entity.Duties;
using System.Collections.Generic;

namespace Entity.AccessControl
{
    public class User : BaseEntityClass
    {
        public User()
        {
            Reserves = new HashSet<Reserve>();
            UserPayments = new HashSet<UserPayment>();
        }
        public int PersonalId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Salary { get; set; }

        public int UserType { get; set; }

        public Personal Personal { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }

        public virtual ICollection<UserPayment> UserPayments { get; set; }
    }
}
