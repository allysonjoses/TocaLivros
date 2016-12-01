using System.Collections.Generic;
using Newtonsoft.Json;

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
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
