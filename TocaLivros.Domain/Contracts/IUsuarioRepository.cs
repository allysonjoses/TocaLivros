using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System;

namespace TocaLivros.Domain.Contracts
{
    public interface IUsuarioRepository : IDisposable
    {
        /// <summary>
        /// Realiza a busca por um usuario pelo nome
        /// </summary>
        /// <param name="username">Nome do Usuario</param>
        /// <returns>Objeto Usuario</returns>
        Task<Usuario> LoginAsync(string username);

        /// <summary>
        /// Realiza a busca por um usuario pelo Id
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        /// <returns>Objeto Usuario</returns>
        Task<Usuario> GetAsync(int id);

        /// <summary>
        /// Cria um usuario
        /// </summary>
        /// <param name="username">Nome do Usuario</param>
        Task CreateAsync(string username);
    }
}
