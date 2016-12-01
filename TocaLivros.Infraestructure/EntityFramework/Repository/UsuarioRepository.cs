using TocaLivros.Infraestructure.EntityFramework.Context;
using TocaLivros.Domain.Contracts;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System.Data.Entity;

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
            _context.Usuario.Add(new Usuario { UserName = username});
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetAsync(string username)
        {
            return await _context.Usuario.Include("Pedidos").
                SingleOrDefaultAsync(x => x.UserName.Equals(username));
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
