using System.Collections.Generic;

namespace TocaLivros.Domain.Models
{
    public class Pedido
    {
        public Pedido()
        {
            Produtos = new HashSet<Produto>();
        }

        public int PedidoId { get; set; }
        public double Valor { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
