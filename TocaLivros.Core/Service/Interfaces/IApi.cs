using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TocaLivros.Domain.Models;

namespace TocaLivros.Core.Service
{
    public interface IApi
    {
        Task<string> LoginAsync(string usuario, string password);

        Task<Usuario> GetUsuarioAsync();
        Task CreateUsuarioAsync(Usuario usuario);

        Task<List<Produto>> GetProdutoAsync();
        Task<Produto> GetProdutoAsync(int id);
        Task CreateProdutoAsync(Produto produto);
        Task UpdateProdutoAsync(Produto produto);

        Task<List<Pedido>> GetPedidoAsync();
        Task<Pedido> GetPedidoAsync(int id);
        Task CreatePedidoAsync(Pedido pedido);
        Task UpdatePedidoAsync(Produto pedido);
    }
}
