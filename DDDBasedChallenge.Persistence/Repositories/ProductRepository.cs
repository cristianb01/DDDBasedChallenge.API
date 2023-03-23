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
        private readonly DDDBasedChallengeContext _context;

        public ProductRepository(DDDBasedChallengeContext context)
        {
            this._context = context;
        }

        public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken)
        {
            var addedProduct = (await this._context.Products.AddAsync(product, cancellationToken)).Entity;

            await this._context.SaveChangesAsync(cancellationToken);

            return addedProduct;
        }

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Products.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await this._context.Products.FindAsync(id, cancellationToken);
        }
        public async Task<bool> Delete(Product product)
        {
            try
            {
                this._context.Products.Remove(product);
                await this._context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<Product> Update(Product product)
        {
            var updatedProduct = this._context.Update(product).Entity;
            await this._context.SaveChangesAsync();

            return updatedProduct;
        }
    }
}
