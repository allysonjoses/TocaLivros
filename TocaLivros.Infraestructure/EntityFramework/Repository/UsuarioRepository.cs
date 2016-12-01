using TocaLivros.Domain.Contracts;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System;

namespace TocaLivros.Infraestructure.EntityFramework.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task CreateAsync(string username)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
