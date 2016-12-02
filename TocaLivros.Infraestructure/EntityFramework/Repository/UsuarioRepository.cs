using TocaLivros.Infraestructure.EntityFramework.Context;
using TocaLivros.Domain.Contracts;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System.Data.Entity;
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

        public async Task CreateAsync(string username)
        {
            var user = await _context.Usuario.SingleOrDefaultAsync(x => x.UserName.Equals(username));

            if (user == null)
            {
                _context.Usuario.Add(new Usuario { UserName = username });
                await _context.SaveChangesAsync();
            }
            else throw new Exception("Username já utilizado!");
        }

        public async Task<Usuario> LoginAsync(string username)
        {
            return await _context.Usuario.SingleOrDefaultAsync(x => x.UserName.Equals(username));
        }

        public async Task<Usuario> GetAsync(int id)
        {
            return await _context.Usuario.Include("Pedidos").
                FirstOrDefaultAsync(x => x.UsuarioId.Equals(id));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
