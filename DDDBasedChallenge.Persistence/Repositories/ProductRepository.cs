using DDDBasedChallenge.Application.Interfaces.Repositories;
using DDDBasedChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DDDBaseChallengeContext _context;

        public ProductRepository(DDDBaseChallengeContext context)
        {
            this._context = context;
        }

        public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken)
        {
            var addedProduct = (await this._context.Products.AddAsync(product, cancellationToken)).Entity;

            return addedProduct;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await this._context.Products.FindAsync(id);
        }
    }
}
