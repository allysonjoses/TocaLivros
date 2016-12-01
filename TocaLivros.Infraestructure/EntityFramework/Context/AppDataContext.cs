using System.Data.Entity.ModelConfiguration.Conventions;
using TocaLivros.Infraestructure.EntityFramework.Map;
using TocaLivros.Domain.Models;
using System.Data.Entity;

namespace TocaLivros.Infraestructure.EntityFramework.Context
{
    public class AppDataContext : DbContext
    {
        public AppDataContext() : base("name = ConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDataContext, Configuration>());
        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Conventions

            modelBuilder.Conventions.Remove(new ManyToManyCascadeDeleteConvention());
            modelBuilder.Conventions.Remove(new OneToManyCascadeDeleteConvention());
            modelBuilder.Conventions.Remove(new PluralizingTableNameConvention());

            #endregion

            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
