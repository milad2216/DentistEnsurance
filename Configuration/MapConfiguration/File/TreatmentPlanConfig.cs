using Entity.File;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.MapConfiguration.File
{
    public class TreatmentPlanConfig : EntityTypeConfiguration<TreatmentPlan>
    {
        public TreatmentPlanConfig()
        {
            ToTable("TreatmentPlan");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Date).IsRequired();
            Property(p => p.Description).HasMaxLength(500);
            Property(p => p.Cost).IsRequired();
        }
    }
}
