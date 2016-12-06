using TocaLivros.Infraestructure.EntityFramework.Context;
using TocaLivros.Domain.Contracts;
using System.Collections.Generic;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using System;

namespace TocaLivros.Infraestructure.EntityFramework.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDataContext _context;

        public PedidoRepository(AppDataContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pedido>> GetAllAsync(int id)
        {
            return await _context.Pedido.Where(x => x.UsuarioId.Equals(id)).ToListAsync();
        }

        public async Task<Pedido> GetAsync(int id)
        {
            return await _context.Pedido.FindAsync(id);
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedido.Attach(pedido);
            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync(); throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
