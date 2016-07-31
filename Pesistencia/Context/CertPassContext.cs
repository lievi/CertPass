namespace Persistencia.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Modelo;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class CertPassContext : DbContext
    {
        public CertPassContext() : base("name=CertPassContext")
        {
            Database.SetInitializer<CertPassContext>(new MigrateDatabaseToLatestVersion<CertPassContext, Pesistencia.Migrations.Configuration>());
        }

        public DbSet<Perguntas> Perguntas { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
