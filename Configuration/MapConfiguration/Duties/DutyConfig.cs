using Entity.Duties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.MapConfiguration.Duties
{
    class DutyConfig : EntityTypeConfiguration<Duty>
    {
        public DutyConfig()
        {
            ToTable("Duty");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Name).HasMaxLength(50).IsRequired();
            Property(p => p.Description).HasMaxLength(500);
            Property(p => p.Cost).IsRequired();
            Property(p => p.IsActive).IsRequired();
            HasMany(p => p.Reserves).WithRequired().HasForeignKey(WFS => WFS.ServiceId);
        }
    }
}
