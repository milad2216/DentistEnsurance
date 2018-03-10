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
    public class PersonalFileConfig : EntityTypeConfiguration<PersonalFile>
    {
        public PersonalFileConfig()
        {
            ToTable("PersonalFile");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.FileNo).HasMaxLength(50).IsRequired();
            Property(p => p.SpecialDisease).HasMaxLength(200);
            Property(p => p.InsuranceType).HasMaxLength(100);
            Property(p => p.MedicalAlert).HasMaxLength(300);
            HasMany(p => p.TreatmentPlans).WithOptional().HasForeignKey(WFS => WFS.FileId);
            HasMany(p => p.TreatmentDescriptions).WithOptional().HasForeignKey(WFS => WFS.FileId);
        }
    }
}
