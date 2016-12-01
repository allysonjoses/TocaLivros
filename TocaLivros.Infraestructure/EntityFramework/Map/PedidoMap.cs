using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TocaLivros.Domain.Models;

namespace TocaLivros.Infraestructure.EntityFramework.Map
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedido");

            Property(x => x.PedidoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired<Usuario>(x => x.Usuario).WithMany
                (x => x.Pedidos).HasForeignKey(x => x.UsuarioId);
        }
    }
}
