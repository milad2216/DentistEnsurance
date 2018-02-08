using Entity.AccessControl;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Configuration.MapConfiguration.AccessControl
{
    class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("User");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Username).IsUnicode(true);
            HasMany(p => p.Reserves).WithRequired().HasForeignKey(WFS => WFS.UserId);
            HasMany(p => p.UserPayments).WithRequired().HasForeignKey(WFS => WFS.UserId);
        }
    }
}
