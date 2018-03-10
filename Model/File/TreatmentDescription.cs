using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.File
{
    public class TreatmentDescription : BaseEntityClass
    {
        public int FileId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public long Cost { get; set; }

        public long? Received { get; set; }

        public long Remainder { get; set; }

        public bool Reported { get; set; }

        public virtual PersonalFile File { get; set; }
    }
}
