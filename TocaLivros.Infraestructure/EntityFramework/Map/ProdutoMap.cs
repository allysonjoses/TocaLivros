using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TocaLivros.Domain.Models;

namespace TocaLivros.Infraestructure.EntityFramework.Map
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            Property(x => x.ProdutoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).HasMaxLength(50).IsRequired();

            HasMany<Pedido>(x => x.Pedidos).WithMany(x => x.Produtos).Map(x =>
            {
                x.MapLeftKey("ProdutoId");
                x.MapRightKey("PedidoId");
                x.ToTable("PedidoItens");
            });
        }
    }
}
