using DDDBasedChallenge.Application.Interfaces.Repositories;
using DDDBasedChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DDDBasedChallengeContext _context;

        public CategoryRepository(DDDBasedChallengeContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category category, CancellationToken cancellationToken)
        {
            var addedCategory = (await this._context.Categories.AddAsync(category, cancellationToken)).Entity;

            await this._context.SaveChangesAsync(cancellationToken);

            return addedCategory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await this._context.Categories.Include(c => c.Products).ToListAsync(cancellationToken);
        }
    }
}
