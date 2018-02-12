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
    class ReserveConfig : EntityTypeConfiguration<Reserve>
    {
        public ReserveConfig()
        {
            ToTable("Reserve");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.RequestMessage).HasMaxLength(500);
        }
    }
}
