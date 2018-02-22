using Entity.Duties;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.AccessControl
{
    [Table("Personal")]
    public class Personal : BaseEntityClass
    {
        public Personal()
        {
            Users = new HashSet<User>();
            Childrens = new HashSet<Personal>();
        }
        public int ParentId { get; set; }
        public string PersonalNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relation { get; set; }
        public string NationalNo { get; set; }
        public string Unit { get; set; }


        public virtual Personal Parent { get; set; }

        public ICollection<User> Users { get; set; }

        public virtual ICollection<Personal> Childrens { get; set; }

        public virtual ICollection<Reserve> Reserves { get; set; }
    }
}
