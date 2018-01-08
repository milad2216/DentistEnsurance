using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AccessControl
{
    [Table("Menu")]
    public class Menu : BaseEntityClass
    {
        public string Action { get; set; }
        public string Title { get; set; }
        public string Style { get; set; }

    }
}
