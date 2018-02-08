using Entity.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.MapConfiguration.Services
{
    class UserPaymentConfig : EntityTypeConfiguration<UserPayment>
    {
        public UserPaymentConfig()
        {
            ToTable("UserPayment");
            HasKey(t => t.ID);
            Property(t => t.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Amount).IsRequired();
            Property(p => p.DfDate).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
}
