using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.File
{
    public class TreatmentPlan : BaseEntityClass
    {
        public int FileId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public long Cost { get; set; }

        public virtual PersonalFile File { get; set; }
    }
}
