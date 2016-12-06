using System.Collections.Generic;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System;

namespace TocaLivros.Domain.Contracts
{
    public interface IPedidoRepository : IDisposable
    {
        /// <summary>
        /// Retorna todos os pedidos do usuario
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <returns>List<Pedido></Pedido></returns>
        Task<List<Pedido>> GetAllAsync(int id);

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
