using TocaLivros.Infraestructure.EntityFramework.Context;
using TocaLivros.Domain.Contracts;
using System.Collections.Generic;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TocaLivros.Infraestructure.EntityFramework.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDataContext _context;

        public ProdutoRepository(AppDataContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(Produto produto)
        {
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Produto>> GetAllAsync()
        {
            return await _context.Produto.ToListAsync();
        }

        public async Task<Produto> GetAsync(int id)
        {
            return await _context.Produto.FindAsync(id);
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produto.Attach(produto);
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
