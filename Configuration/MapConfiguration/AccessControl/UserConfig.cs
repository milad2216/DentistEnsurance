using Entity.AccessControl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.MapConfiguration.AccessControl
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("User");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(actionType => actionType.NationalNo).HasMaxLength(10);
            Property(p => p.Username).IsUnicode(true);
            //HasMany(actionType => actionType.WorkflowStepActions).WithRequired().HasForeignKey(WFS => WFS.WFActionTypeId);



        }
    }
}
