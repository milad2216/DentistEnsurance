using Entity.AccessControl;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Configuration.MapConfiguration.AccessControl
{
    class PersonalConfig : EntityTypeConfiguration<Personal>
    {
        public PersonalConfig()
        {
            ToTable("Personal");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.NationalNo).IsUnicode(true);
            Property(p => p.NationalNo).HasMaxLength(10);
            Property(p => p.PersonalNo).HasMaxLength(12);
            HasMany(p => p.Users).WithRequired().HasForeignKey(WFS => WFS.PersonalId);
            HasMany(p => p.Childrens).WithRequired().HasForeignKey(WFS => WFS.ParentId);
        }
    }
}
