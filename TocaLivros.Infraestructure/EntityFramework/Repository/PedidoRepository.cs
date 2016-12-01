using TocaLivros.Infraestructure.EntityFramework.Context;
using TocaLivros.Domain.Contracts;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
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

        public Task CreateAsync(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Task<Pedido> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
