using Entity.AccessControl;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.MapConfiguration
{
    class MenuConfig : EntityTypeConfiguration<Menu>
    {
        public MenuConfig()
        {
            ToTable("Menu");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Property(actionType => actionType.Title).HasColumnName("TITLE").HasMaxLength(100);
            //HasMany(actionType => actionType.WorkflowStepActions).WithRequired().HasForeignKey(WFS => WFS.WFActionTypeId);



        }
    }
}
