using Entity.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.File
{
    public class PersonalFile : BaseEntityClass
    {
        public int PersonalId { get; set; }

        public string FileNo { get; set; }

        public string SpecialDisease { get; set; }

        public string InsuranceType { get; set; }

        public string MedicalAlert { get; set; }

        public string Description { get; set; }

        public virtual Personal Personal { get; set; }

        public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; }

        public virtual ICollection<TreatmentDescription> TreatmentDescriptions { get; set; }
    }
}
