using System.Data.Entity.Infrastructure.Annotations;
using System;
using System.Data.Entity;
using System.Reflection;
using System.Linq;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entity.AccessControl;

namespace Configuration
{


    public partial class InsuranceEntities : DbContext
    {

        public InsuranceEntities(string nameOrConnectionString, int? timeout = null)
            : base(nameOrConnectionString)
        {
            this.Database.Log = Logger.Log;
            Database.SetInitializer(new CreateDatabaseIfNotExists<InsuranceEntities>());
            // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.NullDatabaseInitializer<AutomationContext>());
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !String.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

    static class Logger
    {
        public static void Log(string msg)
        {
        }
    }
}
