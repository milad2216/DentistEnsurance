using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AccessControl
{
    public class User : BaseEntityClass
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalNo { get; set; }

        public string PersonalNo { get; set; }
    }
}
