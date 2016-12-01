using System.Collections.Generic;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System;

namespace TocaLivros.Domain.Contracts
{
    public interface IProdutoRepository : IDisposable
    {
        /// <summary>
        /// Realiza a busca por todos os produtos
        /// </summary>
        /// <returns>Lista de Produtos</returns>
        Task<List<Produto>> GetAllAsync();

        /// <summary>
        /// Realiza a busca por um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Objeto Produtos</returns>
        Task<Produto> GetAsync(int id);

        /// <summary>
        /// Cria um produto
        /// </summary>
        /// <param name="username">Nome do Usuario</param>
        Task CreateAsync(string username);

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="produto">Produto com as alterações realizadas</param>
        Task UpdateAsync(Produto produto);
    }
}
