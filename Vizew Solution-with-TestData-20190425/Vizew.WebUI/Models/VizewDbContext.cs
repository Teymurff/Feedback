using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Vizew.WebUI.Migrations;
using Vizew.WebUI.Models.Entity;

namespace Vizew.WebUI.Models
{
    public class VizewDbContext : DbContext
    {
        public VizewDbContext()
            :base("name=cString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VizewDbContext,Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<VizewDatabaseGeneratedAttribute, string>("VizewDatabaseGenerated", (p, attributes) => attributes.Single().DefaultValueSql));
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<VizewSqlDefaultValueAttribute, string>("VizewSqlDefaultValue", (p, attributes) => attributes.Single().DefaultValueSql));

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Info> Info { get; set; }
    }
}