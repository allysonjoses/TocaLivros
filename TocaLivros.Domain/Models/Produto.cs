using System.Collections.Generic;
using Newtonsoft.Json;

namespace TocaLivros.Domain.Models
{
    public class Produto
    {
        public Produto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        [JsonIgnore]
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
