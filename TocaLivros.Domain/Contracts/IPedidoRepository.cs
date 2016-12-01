using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System;

namespace TocaLivros.Domain.Contracts
{
    public interface IPedidoRepository : IDisposable
    {
        /// <summary>
        /// Realiza a busca por um pedido
        /// </summary>
        /// <param name="id">Id do pedido</param>
        /// <returns>Objeto Pedido</returns>
        Task<Pedido> GetAsync(int id);

        /// <summary>
        /// Cria um pedido
        /// </summary>
        /// <param name="pedido">Pedido a ser criado</param>
        Task CreateAsync(Pedido pedido);

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="pedido">pedido com as alterações realizadas</param>
        Task UpdateAsync(Pedido pedido);
    }
}
