using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System;

namespace TocaLivros.Domain.Contracts
{
    public interface IUsuarioRepository : IDisposable
    {
        /// <summary>
        /// Realiza a busca por um usuario
        /// </summary>
        /// <param name="username">Nome do Usuario</param>
        /// <returns>Objeto Usuario</returns>
        Task<Usuario> GetAsync(string username);

        /// <summary>
        /// Cria um usuario
        /// </summary>
        /// <param name="username">Nome do Usuario</param>
        Task CreateAsync(string username);
    }
}
