using System.Collections.Generic;

namespace TocaLivros.Domain.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int UsuarioId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
