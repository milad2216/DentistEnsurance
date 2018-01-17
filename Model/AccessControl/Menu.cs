using System.ComponentModel.DataAnnotations.Schema;

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
