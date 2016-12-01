using TocaLivros.Infraestructure.EntityFramework.Context;
using TocaLivros.Domain.Contracts;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System;

namespace TocaLivros.Infraestructure.EntityFramework.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDataContext _context;

        public UsuarioRepository(AppDataContext context)
        {
            this._context = context;
        }

        public Task CreateAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetAsync(string username)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
