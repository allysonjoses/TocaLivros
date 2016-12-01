using TocaLivros.Infraestructure.EntityFramework.Context;
using TocaLivros.Domain.Contracts;
using System.Collections.Generic;
using TocaLivros.Domain.Models;
using System.Threading.Tasks;
using System;

namespace TocaLivros.Infraestructure.EntityFramework.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDataContext _context;

        public ProdutoRepository(AppDataContext context)
        {
            this._context = context;
        }

        public Task CreateAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
